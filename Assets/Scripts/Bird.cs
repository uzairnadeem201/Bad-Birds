using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private Vector2 startPosition;
    Rigidbody2D rigidBody;
    SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float maxAllowedDistance = 2.0f;
    public bool isDragging;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = GetComponent<Rigidbody2D>().position;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }
    private void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        isDragging = true;
    }
    private void OnMouseUp()
    {
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = -currentPosition + startPosition;
        direction.Normalize();
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddForce(direction * speed);
        

        GetComponent <SpriteRenderer>().color = Color.white;
        isDragging=false;
        
    }
    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector2 desiredPosition = mousePosition;
        
        float distance = Vector2.Distance( desiredPosition, startPosition );
        if(distance > maxAllowedDistance)
        {
            Vector2 direction = desiredPosition - startPosition;
            direction.Normalize();
            
            desiredPosition = direction*maxAllowedDistance + startPosition;
        }
        if (desiredPosition.x > startPosition.x)
        {
            desiredPosition = startPosition;
        }
        rigidBody.position = desiredPosition;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());

    }
    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
            GetComponent<Rigidbody2D>().position = startPosition;
            GetComponent<Rigidbody2D>().isKinematic = true;
            rigidBody.velocity = Vector2.zero;
        
    }
}
