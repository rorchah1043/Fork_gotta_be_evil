using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : MonoBehaviour
{
    //[SerializeField] AudioClip _podskazka;
    //[SerializeField] AudioSource _player;
    [SerializeField] KarmaManager karma;
    public GameObject[] chicken;
    public GameObject[] crow;
    private static int _value, _tmp, _tmpBad;
    private int _goal = 3;
    private static FirstQuest _internal;

    public static FirstQuest Internal
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
        _tmp = 0;
        _tmpBad = 0;
        foreach (GameObject obj in chicken)
        {
            if (!obj.activeSelf)
            {
                _tmp++;
            }
            
            if (_tmp == _goal)
            {
                _value = 2; // цель достигнута
                enabled = false;
            }
        }
        foreach (GameObject obj in crow)
        {
            if (!obj.activeSelf)
            {
                _tmpBad++;
            }

            if (_tmpBad == _goal)
            {
                _value = 3; // цель достигнута
                enabled = false;
            }
        }
    }
    public void SetInActive()
    {
        _value ++;
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
       
        _value = 1; // квест активен
        enabled = true;
        //_player.PlayOneShot(_podskazka);
        foreach (GameObject obj in crow)
        {
            obj.SetActive(true);
        }
        foreach (GameObject obj in chicken)
        {
            obj.SetActive(true);
        }
    }
    

    void SetCompleteQuest()
    {
        foreach (GameObject obj in crow)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in chicken)
        {
            obj.SetActive(false);
        }
        if(_value == 2)
        {
            karma.ChangeKarma(30);
            _value = 665;
        }
        if(_value == 3)
        {
            karma.ChangeKarma(-30);
            _value = 777;
        }
        enabled = false;
    }

    void ResetQuest()
    {
        enabled = false;
        _value = 0;
        foreach (GameObject obj in crow)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in chicken)
        {
            obj.SetActive(false);
        }
    }
}
