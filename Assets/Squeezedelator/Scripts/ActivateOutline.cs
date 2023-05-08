using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOutline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    { 
        if (other.CompareTag("NPC"))
        { 
            other.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            other.GetComponent<Outline>().enabled = false;
        }
    }


}
