using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardQuest : MonoBehaviour
{
    [SerializeField] private GameObject[] _mannequins;
    private static int _value, _tmp;
    private bool _isTrapActive = false;
    private static GuardQuest _internal;

    public static GuardQuest Internal
    {
        get { return _internal; }
    }

    void Awake()
    {
        ResetQuest();

        _value = 0; // начальное значение статуса

        _internal = this;
        enabled = false;
    }

    void LateUpdate()
    {
        _tmp = _mannequins.Length;
        foreach(GameObject obj in _mannequins)
        {
            if(obj.GetComponent<Mannequin>().GetIsTrapActive())
            {
                _isTrapActive = obj.GetComponent<Mannequin>().GetIsTrapActive();
            }
            if (obj.GetComponent<Mannequin>().GetIsGuardClose())
            {
                _tmp--;
                Debug.Log(_tmp);
            }
        }
        if(_tmp == 0)
        {
            foreach (GameObject obj in _mannequins)
            {
                obj.GetComponent<Mannequin>().ActivateTrap();
            }
            _value = 666;
            SetCompleteQuest();

        }
    }

    public static int questValue
    {
        get { return _value; }
    }

    public void QuestStatus(QuestManager.Status status)
    {
        switch (status)
        {
            case QuestManager.Status.Active:
                SetActiveQuest();
                break;
            case QuestManager.Status.Complete:
                SetCompleteQuest();
                break;
            case QuestManager.Status.Disable:
                ResetQuest();
                break;
        }
    }

    void SetActiveQuest()
    {
        _tmp = _mannequins.Length;
        _value = 1; // квест активен
        enabled = true;
    }


    void SetCompleteQuest()
    {
        if (_value == 666)
        {
            Debug.Log("Bad sucsses quest");
        }
        enabled = false;
    }

    void ResetQuest()
    {
        enabled = false;
        _value = 0;
    }
}
