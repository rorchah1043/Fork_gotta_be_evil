using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class PickingQuest : MonoBehaviour
{
    [SerializeField] private GameObject[] _usefulMashroom;
    [SerializeField] private GameObject[] _notUsefulMashroom;
    private int _goal;
    private bool _isBadPick;

    private static int _value;
    private static PickingQuest _internal;

    public static PickingQuest Internal
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

    private void LateUpdate()
    {
        foreach (GameObject obj in _usefulMashroom)
        {
            if(!obj.activeSelf)
            {
                _goal--;
            }
            if (_goal == 0 & _isBadPick)
            {
                _value = 3;
            }
            if(_goal == 0 & !_isBadPick)
            {
                _value = 3;
            }
        }
        foreach (GameObject obj in _notUsefulMashroom)
        {
            if (!obj.activeSelf)
            {
                _isBadPick = true;
            }
        }
        if(_isBadPick)
        {
            _value = 4;
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
        foreach (GameObject obj in _usefulMashroom)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in _notUsefulMashroom)
        {
            obj.SetActive(true);
        }
        _isBadPick = false;
        _goal = _usefulMashroom.Length;
        _value = 1; // квест активен
        enabled = true;
    }

    void SetCompleteQuest()
    {
        enabled = false;
        if(_isBadPick)
        {
            _value = 666;
        }
        else
        {
            _value = 777;
        }
        foreach (GameObject obj in _usefulMashroom)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in _notUsefulMashroom)
        {
            obj.SetActive(false);
        }
    }

    void ResetQuest()
    {
        foreach (GameObject obj in _usefulMashroom)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in _notUsefulMashroom)
        {
            obj.SetActive(false);
        }
        enabled = false;
        _value = 0;
    }
}
