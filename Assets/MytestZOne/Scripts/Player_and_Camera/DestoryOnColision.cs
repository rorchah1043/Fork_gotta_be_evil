using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOnColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Chiken"))
        {
            Destroy(gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Crow"))
        {
            Destroy(gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Wolf"))
        {
            Destroy(gameObject);
            other.GetComponent<WolfHP>().Damage();
        }
        else if (other.CompareTag("Window"))
        {
            other.GetComponent<BreakableWindow>().ChangeMaterial();
        }
        
        Destroy(gameObject);
    }
}
