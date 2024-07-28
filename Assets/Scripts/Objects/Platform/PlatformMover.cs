using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public Transform pointA; 
    public Transform pointB; 
    public float speed = 5f; 
    public float acceleration = 2f; 
    public float deceleration = 2f; 

    private Vector3 currentTarget;
    private bool movingToB = true; 
    private float currentSpeed;

    private void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("PointA and PointB must be assigned.");
            return;
        }

        currentTarget = pointB.position;
        currentSpeed = speed;
    }

    private void Update()
    {
        MoveObject();
    }

    private void MoveObject()
    {
       
        float distance = Vector3.Distance(transform.position, currentTarget);

        if (distance > 0.5f) 
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else if (distance < 0.5f) 
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }

        currentSpeed = Mathf.Max(currentSpeed, 0);

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, currentSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget) < 0.01f)
        {
            movingToB = !movingToB;
            currentTarget = movingToB ? pointB.position : pointA.position;
            currentSpeed = speed; 
        }
    }
}