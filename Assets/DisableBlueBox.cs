using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBlueBox : MonoBehaviour
{
   public GameObject playerObj;
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == playerObj)
        {
            player.GetComponent<PlayerSwapper>().enabled = false;
        }
        
    }
}
