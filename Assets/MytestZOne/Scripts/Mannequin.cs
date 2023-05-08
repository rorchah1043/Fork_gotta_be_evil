using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mannequin : MonoBehaviour
{
    private bool _isTrapActive = false;
    private bool _isGuardClose = false;

    private void OnTriggerStay(Collider other)
    {
        if (QuestManager.GetCurrentValue("GuardQuest") == 1)
        {
            if (other.CompareTag("Guard"))
            {
                _isGuardClose = true;
            }
            if (other.CompareTag("Player"))
            {
                Debug.Log("Press F to active");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    _isTrapActive = true;
                    Debug.Log("Trap Active");
                }
            }
        }
    }



    public void ActivateTrap()
    {   
        _isTrapActive = true;
        transform.rotation = new Quaternion(0, 70, 0, 0);
        Debug.Log("Trap damage guard");
    }

    public bool GetIsGuardClose()
    {
        return _isGuardClose;
    }
    public bool GetIsTrapActive()
    {
        return _isTrapActive;
    }
}
