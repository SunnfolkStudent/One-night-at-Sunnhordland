using UnityEngine;

namespace Basketball
{
    public class BasketballTest : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private GameObject _pointer;
        private Vector3 _startPosition;
        private bool _fired;
        [SerializeField] private Vector2 ballVelocity;
        [SerializeField] private float throwingPower = 2;
        [SerializeField] private float drawMax = 12.5f;

        private void Start()
        {
            _pointer = FindAnyObjectByType<FollowPointer>().gameObject;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.gravityScale = 0;
            _startPosition = transform.position;
            _fired = false;
        }

        private void OnMouseDown()
        {
            Debug.Log("mouse down");
        }
    
        private void OnMouseUp()
        {
            if (_fired)
            {
                Debug.Log("Ball already fired");
                return;
            }
            _rigidbody2D.gravityScale = 1;
            var mousePos = GetMousePosition();
            ballVelocity = CalculateVelocity(mousePos);
            SetVelocity(ballVelocity);
            _fired = true;

        }

        private Vector2 GetMousePosition()
        {
            var mousePosition = _pointer.transform.position - transform.position;
            Debug.Log("mouse pos: " + mousePosition);
            return mousePosition;
        }
    
        private Vector2 CalculateVelocity(Vector2 mousePosition)
        {
            ballVelocity = -mousePosition * throwingPower;
            ballVelocity.x = Mathf.Clamp(ballVelocity.x, -drawMax, drawMax);
            ballVelocity.y = Mathf.Clamp(ballVelocity.y, -drawMax, drawMax);
            Debug.Log("Ball velocity: " + ballVelocity);
            return ballVelocity;
        }

        private void SetVelocity(Vector2 v)
        {
            _rigidbody2D.velocity = v;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall"))
            {
                return;
            }
            if (other.gameObject.CompareTag("Basket"))
            {
                Debug.Log("hit!");
                
            }
            else if (other.gameObject.CompareTag("Ground"))
            {
                Debug.Log("Ground!");
            }
            Instantiate(gameObject, _startPosition, new Quaternion(0,0,0,0));
            Destroy(gameObject);
        }
    }
}
