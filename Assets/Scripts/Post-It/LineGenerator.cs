using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    
    private Line _activeLine;
    private bool _isMouseOverDrawable = false;
    
    
    private void Update()
    {
        Debug.Log(_isMouseOverDrawable);
        //if (_isMouseOverDrawable)
        //{
            
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newLine = Instantiate(linePrefab);
            _activeLine = newLine.GetComponent<Line>();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _activeLine = null;
        }

        if (_activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _activeLine.UpdateLine(mousePos);
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

