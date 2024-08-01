using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBlueBox : MonoBehaviour
{
    public GameObject blueBox;
    private void OnTriggerEnter(Collider other)
    {
       blueBox.SetActive(true);
    }
}
