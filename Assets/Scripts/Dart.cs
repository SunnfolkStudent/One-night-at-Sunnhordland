using UnityEngine;
using UnityEngine.SceneManagement;

public class Dart : MonoBehaviour
{
    [SerializeField] private GameObject dart;
    [SerializeField] private GameObject pointer;
    [SerializeField] private float timeGainedFromDartHit;
    
    private SleepMeter _sleepMeter;

    private void Start()
    {
        _sleepMeter = GameObject.Find("SleepBar").gameObject.GetComponent<SleepMeter>();
        pointer = GameObject.Find("Pointer").gameObject;
        
        Invoke(nameof(ReturnToMainOffice), 3);
    }

    private void OnMouseDown()
    {
        Instantiate(dart, pointer.transform.position, Quaternion.identity);
        _sleepMeter.IncreaseTimer(timeGainedFromDartHit);
    }

    private void ReturnToMainOffice()
    {
        SceneManager.LoadScene("MainOffice");
    }
}
