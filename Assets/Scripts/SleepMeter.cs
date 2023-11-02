using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SleepMeter : MonoBehaviour
{
    public float sleepLevel = 1;
    private float _timeTime = 1;
    public float energySeconds;
    private float _timeSeconds;
    [SerializeField] private float missingPercentTime = 0.1f;
    private int _state;
    private RectTransform _rectTransform;
    private Vector3 _standardPositionBar;

    private GameObject _canvas;

    private GameObject _ambiance;
        
    [Header("SleepMeterSegments")]
    [SerializeField] private GameObject hours;
    [SerializeField] private GameObject[] sleepBarSegments;

    private void Start()
    {
        _ambiance = GameObject.Find("Ambiance");
        _canvas = GameObject.Find("Canvas");
        DontDestroyOnLoad(_canvas);
        DontDestroyOnLoad(_ambiance);
        
        _state = 0;
        sleepLevel = 1;
        _timeSeconds = (1 - missingPercentTime) / energySeconds;
        energySeconds = 1 / energySeconds;
        _rectTransform = GetComponent<RectTransform>();
        _standardPositionBar = _rectTransform.anchoredPosition;
        hours = GameObject.Find("Hours").gameObject;
            
        var i = 0;
        foreach (Transform child in hours.transform)
        {
            sleepBarSegments[i] = child.gameObject;
            i++;
        }
    }

    public void Update()
    {
        if (_rectTransform.localScale.x >= 0)
        {
            sleepLevel -= energySeconds * Time.deltaTime;
            _timeTime -= _timeSeconds * Time.deltaTime;
            Debug.Log("timeTime: " + _timeTime);
        }
        else
        {
            SceneManager.LoadScene("Lose");
            Destroy(_ambiance);
            Destroy(_canvas);
        }

        if (_timeTime <= 0)
        {
            SceneManager.LoadScene("Win");
            Destroy(_ambiance);
            Destroy(_canvas);
        }
            
        SetSleepBarLength();
        RemoveSegments();
    }

    private void SetSleepBarLength()
    {
        _rectTransform.localScale = new Vector3(sleepLevel, 1, 1);
        _rectTransform.anchoredPosition = new Vector3( _standardPositionBar.x * sleepLevel, _standardPositionBar.y, 0);
    }

    private void RemoveSegments()
    {
        if (!(_timeTime < 1 - (_state + 1)  * 0.125f)) return;
        _state++;
        Destroy(sleepBarSegments[8 - _state].gameObject);
    }

    public void IncreaseTimer(float amount)
    {
        //var maxEnergyForStage = 1 - (_state + 1) * 0.125f;
        sleepLevel += amount * energySeconds;
    }
    
    public void DecreaseTimer(float amount)
    {
        //var maxEnergyForStage = 1 - (_state + 1) * 0.125f;
        sleepLevel -= amount * energySeconds;
    }
}