using UnityEngine;

public class BasketballTest : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private Vector2 ballVelocity;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        SettVelocity();
    }

    private void SettVelocity()
    {
        _rigidbody2D.velocity = ballVelocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Basket"))
        {
            Debug.Log("hit!");
        }
    }
}
