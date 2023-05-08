using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterZone : MonoBehaviour
{
    [SerializeField] GuardQuest quest;
    private bool questStart = false;
    private void Start()
    {
        //quest = GetComponent<GuardQuest>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !questStart)
        {
            quest.QuestStatus(QuestManager.Status.Active);
            Debug.Log("Enter zone");
            questStart = true;
        }
    }
}
