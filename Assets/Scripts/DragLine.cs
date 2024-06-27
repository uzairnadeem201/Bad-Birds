using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLine : MonoBehaviour
{
    private LineRenderer LineRender;
    private Bird bird;

    // Start is called before the first frame update
    void Start()
    {
        LineRender = GetComponent<LineRenderer>();
        bird = FindAnyObjectByType<Bird>();
    }

    // Update is called once per frame
    void Update()
    {   if (bird.isDragging)
        {
            LineRender.SetPosition(1, bird.transform.position);
            LineRender.enabled = true;
        }
    else
        {
            LineRender.enabled = false;
        }
        
    }
}
