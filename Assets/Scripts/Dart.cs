using UnityEngine;
using UnityEngine.SceneManagement;

public class Dart : MonoBehaviour
{
    [SerializeField] private GameObject dart;
    [SerializeField] private GameObject pointer;

    private void Start()
    {
        pointer = GameObject.Find("Pointer").gameObject;
        
        Invoke(nameof(ReturnToMainOffice), 5);
    }

    private void OnMouseDown()
    {
        Instantiate(dart, pointer.transform.position, new Quaternion(0, 0, 0, 0));
    }

    private void ReturnToMainOffice()
    {
        SceneManager.LoadScene("MainOffice");
    }
}
