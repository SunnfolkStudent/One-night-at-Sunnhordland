using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClickableObjects
{
    public class PostItNotes : MonoBehaviour
    {
        private void OnMouseDown()
        {
            SceneManager.LoadScene("MinigamePostIt");
        }
    }
}
