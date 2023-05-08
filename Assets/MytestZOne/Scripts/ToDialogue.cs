using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDialogue : MonoBehaviour
{

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Debug.Log("Press F to Talk");
            if (Input.GetKeyDown(KeyCode.F))
            {
                DialogueTrigger tr = other.transform.GetComponent<DialogueTrigger>();
                if (tr != null && tr.fileName != string.Empty)
                {
                    DialogueManager.Internal.DialogueStart(tr.fileName);
                }
            }
        }
    }
}