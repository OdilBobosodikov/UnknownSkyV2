using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiTrigger : MonoBehaviour
{
    public string UIEventTag ="UIEventTrigger";
    public UIApperiance uIApperiance;
     private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(UIEventTag))
        {
            uIApperiance.ShowText();
        }
    }
}
