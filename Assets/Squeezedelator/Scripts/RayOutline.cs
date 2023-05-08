using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayOutline : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        //_camera = Camera.main;
    }

    private void Update()
    {
        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward,out RaycastHit hit,20f))
        {
            Debug.Log("Raycast Hit");
            if (hit.collider.CompareTag("NPC"))
            {
                Debug.Log("HIT NPC");
                hit.transform.GetComponent<Outline>().enabled = true;
            }
        }
        Debug.DrawRay(_camera.transform.position, (transform.position - _camera.transform.position) * 50f, Color.red);
    }

    
}
