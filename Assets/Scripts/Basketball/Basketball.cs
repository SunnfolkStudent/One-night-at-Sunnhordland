using UnityEngine;
using UnityEngine.SceneManagement;

namespace Basketball
{
    public class Basketball : MonoBehaviour
    {
        private GameObject _pointer;
        private SleepMeter _sleepMeter;
        private Rigidbody2D _rigidbody2D;
        private LineRenderer _lineRenderer;
        
        [SerializeField] private float timeGainedFromPints;
        [SerializeField] private float throwingPower = 2;
        [SerializeField] private float drawMax = 12.5f;
        [SerializeField] private Vector2 ballVelocity;
        
        private Vector3 _startPosition;
        private bool _isDragging;
        private bool _fired;

        private void Start()
        {
            _sleepMeter = GameObject.Find("SleepBar").gameObject.GetComponent<SleepMeter>();
            _pointer = FindAnyObjectByType<FollowPointer>().gameObject;
            _lineRenderer = FindAnyObjectByType<LineRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _startPosition = transform.position;
            _rigidbody2D.gravityScale = 0;
            _fired = false;
        }

        private void Update()
        {
            if (_isDragging)
            {
                _lineRenderer.SetPosition(1, _pointer.transform.position);
            }
        }

        private void OnMouseDown()
        {
            Debug.Log("mouse down");
            if (!_fired)
            {
                StartDrawLine();
            }
        }
    
        private void OnMouseUp()
        {
            StopDrawLine();
            
            if (_fired)
            {
                Debug.Log("Ball already fired");
                return;
            }
            
            FireBall();
        }

        private void StartDrawLine()
        {
            _isDragging = true;
            _lineRenderer.enabled = true;
            _lineRenderer.SetPosition(0, transform.position);
        }

        private void StopDrawLine()
        {
            _isDragging = false;
            _lineRenderer.enabled = false;
        }

        private void FireBall()
        {
            _rigidbody2D.gravityScale = 1;
            var mousePos = GetMousePosition();
            ballVelocity = CalculateVelocity(mousePos);
            _rigidbody2D.velocity = ballVelocity;
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Wall")) return;
            if (other.gameObject.CompareTag("Basket"))
            {
                Debug.Log("hit!");
                GainTime(timeGainedFromPints);
                SceneManager.LoadScene("MainOffice");
            }
            else if (other.gameObject.CompareTag("Ground"))
            {
                Debug.Log("Ground!");
            }
            Instantiate(gameObject, _startPosition, new Quaternion(0,0,0,0));
            Destroy(gameObject);
        }

        private void GainTime(float time)
        {
            time *= _sleepMeter.energySeconds;
            _sleepMeter.IncreaseTimer(time);
        }
    }
}
