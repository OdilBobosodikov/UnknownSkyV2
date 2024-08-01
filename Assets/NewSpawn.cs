using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawn : MonoBehaviour
{
    public Vector3 newRespawn = new Vector3(-2.7f, 1.33f, 184.66f);
    public Transform oldRespawn;
    private void OnTriggerEnter(Collider other)
    {
       oldRespawn.position = newRespawn;
    }
}
