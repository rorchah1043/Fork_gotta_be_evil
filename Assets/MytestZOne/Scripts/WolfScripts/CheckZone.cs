using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckZone : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wolf"))
        {
            other.GetComponent<WolfMove>().SetIsBringToZone(true);
        }
    }
}
