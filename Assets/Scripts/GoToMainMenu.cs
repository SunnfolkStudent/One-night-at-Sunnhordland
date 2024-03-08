using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(GoToMainMenuScene), 5);
    }

    private void GoToMainMenuScene()
    {
        Cursor.visible = true;
        SceneManager.LoadScene("MenuMain");
    }
}
