using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfQuest : MonoBehaviour
{
    [SerializeField] GameObject _shapka;
    [SerializeField] GameObject _Player;
    [SerializeField] KarmaManager karma;
    [SerializeField] GameObject bringZone;
    [SerializeField] GameObject wolf;
    [SerializeField] GameObject _firstQuest;
    [SerializeField] AudioClip _podskazka;
    [SerializeField] GameObject _GetItemCanvas;
    private static int _value;

    private static WolfQuest _internal;

    public static WolfQuest Internal
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
        if(!wolf.activeSelf)
        {
            _value = 3; // цель убить достигнута достигнута
            enabled = false;
        }
        if(wolf.GetComponent<WolfMove>().GetIsBringToZone())
        {
            _value = 4; // цель добралась до овец
            enabled = false;
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
        _GetItemCanvas.SetActive(true);
        _shapka.SetActive(true);
        _Player.GetComponent<AudioSource>().PlayOneShot(_podskazka);
        _firstQuest.GetComponent<FirstQuest>().SetInActive();
        _value = 1; // квест активен
        enabled = true;
        wolf.SetActive(true);
        bringZone.SetActive(true);
        _Player.GetComponent<SoundMeee>().SetIsMeeSound();
        
    }

    void SetCompleteQuest()
    {
        
        if(_value == 3)
        {

            karma.ChangeKarma(-30);
            _value = 777;
            
        }
        if(_value == 4)
        {
            karma.ChangeKarma(30);
            _value = 666;
            
        }
        wolf.SetActive(false);
        enabled = false;
    }



    void ResetQuest()
    {
        enabled = false;
        _value = 0;
        wolf.SetActive(false);
        bringZone.SetActive(false);
    }
}
