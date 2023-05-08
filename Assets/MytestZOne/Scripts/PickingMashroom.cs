using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingMashroom : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
