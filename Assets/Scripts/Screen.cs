using UnityEngine;
using UnityEngine.SceneManagement;

public class Screen : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("BasketballMiniGame");
        Debug.Log("Screen");
    }
}
