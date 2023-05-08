using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WolfHP : MonoBehaviour
{
    [SerializeField] private Slider slider;
    private float hp = 100;
    private WolfMove parent;
    // Update is called once per frame
    private void Start()
    {
        parent  = GetComponentInParent<WolfMove>();
        slider.gameObject.SetActive(false);
    }

    void Update()
    {
        slider.value = hp;
        if(parent.IsAgreed())
        {
            slider.gameObject.SetActive(true);
        }
        if(hp == 0)
        {
            parent.gameObject.SetActive(false);
            slider.gameObject.SetActive(false);
        }
    }

    public void ResetHp()
    {
        hp = 100;
        slider.gameObject.SetActive(false);
    }

    public void Damage()
    {
        hp -= 20;
        parent.SetPlayerPosToBot();
    }
}
