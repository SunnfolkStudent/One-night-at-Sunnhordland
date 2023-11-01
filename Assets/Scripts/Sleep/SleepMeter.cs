using UnityEngine;

namespace Sleep
{
    public class SleepMeter : MonoBehaviour
    {
        public float sleepLevel = 1;
        public float energySeconds;
        private int _state = 0;
        private RectTransform _rectTransform;
        private Vector3 _standardPositionBar;
        
        [Header("SleepMeterSegments")]
        [SerializeField] private GameObject hours;
        [SerializeField] private GameObject[] sleepBarSegments;

        private void Start()
        {
            sleepLevel = 1;
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
            }
            else
            {
                // Loose
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
            if (!(sleepLevel < 1 - (_state + 1) * 0.125f)) return;
            _state++;
            Debug.Log(_state);
            Destroy(sleepBarSegments[8 - _state].gameObject);
        }

        public void IncreaseTimer(float amount)
        {
            float maxEnergyForStage = 1 - (_state + 1) * 0.125f;
            Debug.Log(maxEnergyForStage);
            Mathf.Clamp(sleepLevel, 0, maxEnergyForStage);
            sleepLevel += amount;
            Debug.Log(sleepLevel);
        }
    }
}
