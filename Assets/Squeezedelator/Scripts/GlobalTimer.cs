using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalTimer : MonoBehaviour
{
    public static event Action OnTimeEvent;
    [SerializeField] private float _multiplier = 1f;
    [SerializeField] private AudioSource _player;
    [SerializeField] private AudioClip _audio1;
    [SerializeField] private AudioClip _audio2;
    [SerializeField] private AudioClip _audio3;
    [SerializeField] private AudioClip _audio4;

    private int _pointer = 0;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, -1f);
        StartCoroutine(RotateArrow());
    }

    private IEnumerator RotateArrow()
    {
        while (transform.rotation.eulerAngles.z > 1)
        {
            transform.Rotate(0,0,-Time.deltaTime * _multiplier);
            if (transform.rotation.eulerAngles.z < 270 && _pointer == 0)
            {
                _player.PlayOneShot(_audio1);
                OnTimeEvent?.Invoke();
                _pointer++;
            }
            else if (transform.rotation.eulerAngles.z < 180 && _pointer == 1)
            {
                _player.PlayOneShot(_audio2);
                OnTimeEvent?.Invoke();
                _pointer++;
            }
            else if (transform.rotation.eulerAngles.z < 90 && _pointer == 2)
            {
                _player.PlayOneShot(_audio3);
                OnTimeEvent?.Invoke();
                _pointer++;
            }
            else if (transform.rotation.eulerAngles.z < 30 && _pointer == 3)
            {
                _player.PlayOneShot(_audio4);
                OnTimeEvent?.Invoke();
                _pointer++;
            }
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
