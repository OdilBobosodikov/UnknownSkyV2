using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullingObject : MonoBehaviour
{
    public Transform holdPosition; 
    public float pullSpeed = 5f; 
    private bool isPulling = false; 

    private void Update()
    {
        if (isPulling)
        {
            transform.position = Vector3.MoveTowards(transform.position, holdPosition.position, pullSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, holdPosition.position) < 0.1f)
            {
                isPulling = false;
            }
        }
    }

    public void StartPulling()
    {
        isPulling = true;
    }
}
