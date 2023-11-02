using UnityEngine;

namespace ClickableObjects
{
    public class Coffeescript : MonoBehaviour
    {
        private SleepMeter _sleepMeter;
        [SerializeField] private float coffeeTimeRegeneration;
        private bool _coffeeAvailable;

        private void Start()
        {
            _sleepMeter = GameObject.Find("SleepBar").gameObject.GetComponent<SleepMeter>();
        }

        private void OnMouseDown()
        {
            if (_coffeeAvailable == false) return;
            
            _sleepMeter.IncreaseTimer(5);
            _coffeeAvailable = false;
        }
    }
}
