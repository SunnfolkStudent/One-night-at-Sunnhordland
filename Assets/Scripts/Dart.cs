using System;
using UnityEngine;

public class Dart : MonoBehaviour
{
    [SerializeField] private GameObject dart;
    [SerializeField] private GameObject pointer;

    private void Start()
    {
        pointer = GameObject.Find("Pointer").gameObject;
    }

    private void OnMouseDown()
    {
        Instantiate(dart, pointer.transform.position, new Quaternion(0, 0, 0, 0));
    }
}
