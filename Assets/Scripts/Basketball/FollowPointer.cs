using UnityEngine;

namespace Basketball
{
    public class FollowPointer : MonoBehaviour
    {
        private Vector3 _point;

        private void Start()
        {
            Cursor.visible = false;
            GetComponent<SpriteRenderer>().enabled = true;
        }

        private void Update()
        {
            if (Camera.main != null)
            {
                _point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.position = new Vector3(_point.x, _point.y, _point.z + 10);
            }
            else
            {
                Debug.LogError("No Main Camera");
            }
        }
    }
}
