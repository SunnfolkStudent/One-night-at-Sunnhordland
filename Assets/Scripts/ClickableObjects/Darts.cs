using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClickableObjects
{
    public class Darts : MonoBehaviour
    {
        private void OnMouseDown()
        {
            SceneManager.LoadScene("Darts");
        }
    }
}