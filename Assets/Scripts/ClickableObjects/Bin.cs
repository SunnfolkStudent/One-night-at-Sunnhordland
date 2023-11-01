using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClickableObjects
{
    public class Bin : MonoBehaviour
    {
        private void OnMouseDown()
        {
            SceneManager.LoadScene("BasketballMiniGame");
            Debug.Log("Screen");
        }
    }
}
