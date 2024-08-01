using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public float threshold;
    public Transform respawn;
    void FixedUpdate()
    {
        if(transform.position.y < threshold)
        {
            transform.position = respawn.position;
        }
    }
}
