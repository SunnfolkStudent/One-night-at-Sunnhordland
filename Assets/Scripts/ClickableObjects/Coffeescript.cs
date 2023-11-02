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
            _coffeeAvailable = true;
            _sleepMeter = GameObject.Find("SleepBar").gameObject.GetComponent<SleepMeter>();
        }

        private void OnMouseDown()
        {
            if (_coffeeAvailable == false)
            {
                Debug.Log("coffee not available");
                return;
            }
            
            _sleepMeter.IncreaseTimer(5);
            _coffeeAvailable = false;
            Invoke(nameof(SetCoffeeAvailible), coffeeTimeRegeneration);
        }

        private void SetCoffeeAvailible()
        {
            _coffeeAvailable = true;
        }
    }
}
