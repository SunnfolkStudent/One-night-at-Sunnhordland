using UnityEngine;

namespace ClickableObjects
{
    public class Coffeescript : MonoBehaviour
    {
        private SleepMeter _sleepMeter;
        [SerializeField] private float coffeeTimeRegeneration;

        private void Start()
        {
            _sleepMeter = GameObject.Find("SleepBar").gameObject.GetComponent<SleepMeter>();
        }

        private void OnMouseDown()
        {
            _sleepMeter.IncreaseTimer(5);
        }
    }
}
