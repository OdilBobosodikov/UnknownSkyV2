using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PlayerSwapper : MonoBehaviour
{
    public GameObject companion;
    public KeyCode swapKey = KeyCode.Tab;

    private void Update()
    {
        if (Input.GetKeyDown(swapKey))
        {
            SwapPlayers();
        }
    }

    private void SwapPlayers()
    {
        if (companion != null)
        {
            Vector3 tempPosition = transform.position;
            transform.position = new Vector3(companion.transform.position.x, 1.5f + companion.transform.position.y, companion.transform.position.z);
            companion.transform.position = tempPosition;


            Quaternion tempRotation = transform.rotation;
            transform.rotation = companion.transform.rotation;
            companion.transform.rotation = tempRotation;
        }
        else
        {
            Debug.LogWarning("Companion reference is not set!");
        }
    }
}