using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateTask : MonoBehaviour
{
    public TextMeshProUGUI  tasksText; 
    public GameObject player;
    public string newTask;
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject == player)
       {
        string[] lines = tasksText.text.Split('\n');

            if (lines.Length == 1)
            {
                tasksText.text += "\n" + newTask;
            }
            else
            {
                lines[lines.Length - 1] = newTask;
                tasksText.text = string.Join("\n", lines);
            }
       }
    }
}
