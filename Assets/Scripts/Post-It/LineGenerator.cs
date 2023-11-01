using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    
    public Line activeLine;
    private bool _isMouseOverDrawable = false;

    private DialogueTrigger _disable;

    private void Start()
    {
        _disable = FindObjectOfType<DialogueTrigger>();

        if (_disable == null)
        {
            _disable.DisableElement();
        }
    }
    
    private void Update()
    {
        Debug.Log(_isMouseOverDrawable);
        //if (_isMouseOverDrawable)
        //{
            
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            activeLine = newLine.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            activeLine = null;
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos);
        }
        //}
    }

    private void OnMouseExit()
    {
        if (gameObject.CompareTag("Drawable")) _isMouseOverDrawable = false;
    }

    private void OnMouseOver()
    {
        Debug.Log("Mouse is over");
        if (gameObject.CompareTag("Drawable")) _isMouseOverDrawable = true;
    }
    
}

