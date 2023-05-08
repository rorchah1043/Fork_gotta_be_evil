using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWarner : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
    private int _clipNumber = 0;

    private void PlaySound()
    {
        Debug.Log(_audioSource);

        if (!_audioSource.isPlaying && _audioSource != null)
        {
            _audioSource.PlayOneShot(_audioClips[_clipNumber]);
            _clipNumber++;
        }       
    }

    private void OnEnable()
    {
        GlobalTimer.OnTimeEvent += PlaySound;
    }

    private void OnDisable()
    {
        GlobalTimer.OnTimeEvent -= PlaySound;
    }
}
