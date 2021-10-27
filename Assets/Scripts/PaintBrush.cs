using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBrush : ThrowableObject
{
    public GameObject paintPrefab;
    public Transform paintBrushTip;
    public Material defaultMaterial;

    private GameObject paint;
    private bool isColourSelected;


    void Start()
    {
        isColourSelected = false;
    }

    void Update()
    {
        
    }

    public override void OnGrabEnd()
    {
        base.OnGrabEnd();
        isColourSelected = false;
    }

    public override void OnTriggerStart()
    {
        if (isColourSelected)
        {
            paint = Instantiate(paintPrefab, paintBrushTip.position, paintBrushTip.rotation);
            paint.GetComponent<Renderer>().material = paintBrushTip.GetComponent<Renderer>().material;
        }
        
    }

    public override void OnTriggerEnd()
    {
        if(paint != null)
        {
            paint.transform.position = paint.transform.position;
            paintBrushTip.GetComponent<Renderer>().material = defaultMaterial;
            paint = null;
        }
        
    }

    public override void OnTrigger()
    {
        if(paint != null)
        {
            paint.transform.position = paintBrushTip.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("colour"))
        {
            paintBrushTip.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
            isColourSelected = true;
        }
    }

    
}
