using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace Sleep
{
    public class SleepMeter : MonoBehaviour
    {
        private float _sleepLevel;
        [SerializeField] private float sleepinessRate = 1;
        private RectTransform _rectTransform;
        
        [Header("SleepMeterSegments")]
        [SerializeField] private GameObject hours;
        [SerializeField] private GameObject[] sleepBarSegments;

        private void Start()
        {
            _sleepLevel = 1;
            _rectTransform = GetComponent<RectTransform>();
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
                _sleepLevel -= sleepinessRate * Time.deltaTime;
            }
            else
            {
                _sleepLevel = 1;
            }
            SetSleepbarLength(_sleepLevel);
            RemoveSegments();


        }

        private void SetSleepbarLength(float length)
        {
            _rectTransform.localScale = new Vector3(length, 1, 1);
            _rectTransform.anchoredPosition = new Vector3( 756.5f * length, -90, 0);
        }

        private void RemoveSegments()
        {
            for (var i = 0; i < sleepBarSegments.Length; i++)
            {
                if (_sleepLevel < 1 - (i + 1) * 0.125f)
                {
                    Destroy(sleepBarSegments[7 - i].gameObject);
                }
            }
        }
    }
}
