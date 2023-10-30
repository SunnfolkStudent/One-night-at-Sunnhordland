using UnityEngine;
using UnityEngine.Serialization;

public class BasketballTest : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Vector2 mousePos;
    [SerializeField] private Vector2 ballVelocity;
    [SerializeField] private float throwingPower = 4;
    [SerializeField] private float drawMin = 0.5f, drawMax = 12.5f;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.gravityScale = 0;
    }

    private void OnMouseDown()
    {
        Debug.Log("mouse down");
    }
    
    private void OnMouseUp()
    {
        _rigidbody2D.gravityScale = 1;
        mousePos = GetMousePosition();
        ballVelocity = CalculateVelocity(mousePos);
        SetVelocity(ballVelocity);
    }

    private static Vector2 GetMousePosition()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.x -= 960;
        mousePosition.y -= 540;
        Debug.Log("mouse pos: " + mousePosition);
        return mousePosition;
    }
    
    private Vector2 CalculateVelocity(Vector2 mousePosition)
    {
        ballVelocity = -(mousePosition / (100 / throwingPower));
        ballVelocity.x = Mathf.Clamp(ballVelocity.x, drawMin, drawMax);
        ballVelocity.y = Mathf.Clamp(ballVelocity.y, drawMin, drawMax);
        Debug.Log("Ball velocity: " + ballVelocity);
        return ballVelocity;
    }

    private void SetVelocity(Vector2 v)
    {
        _rigidbody2D.velocity = v;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Basket"))
        {
            Debug.Log("hit!");
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground!");
            Destroy(gameObject);
        }
    }
}
