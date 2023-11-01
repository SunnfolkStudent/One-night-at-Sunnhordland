using Unity.Mathematics;
using UnityEngine;

public class PlaceSleepMeterPrefab : MonoBehaviour
{
    [SerializeField] private GameObject sleepMeter;
    
    private void Start()
    {
        Instantiate(sleepMeter, Vector3.zero, quaternion.identity);
    }
}
