using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainOffice : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("MainOffice");
    }
}
