using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroundMusicManager : MonoBehaviour
{
    
    [SerializeField] AudioClip defaultAmbient;
    [SerializeField] AudioClip badDefaultAmbient;
    [SerializeField] AudioSource _currentAudio;
    private bool _isPlayingTrack01;

    public static AroundMusicManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        _isPlayingTrack01 = true;
        PlayGood();
    }

    public void PlayGood()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut(defaultAmbient));
    }

    public void PlayBad()
    {
        StopAllCoroutines();
        StartCoroutine(FadeOut(badDefaultAmbient));
    }

    IEnumerator FadeOut(AudioClip newClip)
    {
        float timeToFade = 1.25f;
        float timeElased = 0;
        
        while(timeElased < timeToFade)
        {
            _currentAudio.volume = Mathf.Lerp(0.7f, 0, timeElased / timeToFade);
            timeElased += Time.deltaTime;
            yield return null;
        }
        timeElased = 0;
        _currentAudio.Stop();
        _currentAudio.clip = newClip;
        _currentAudio.Play();
        while (timeElased < timeToFade)
        {
            _currentAudio.volume = Mathf.Lerp(0, 0.7f, timeElased / timeToFade);
            timeElased += Time.deltaTime;
            yield return null;
        }
       

        
    }
}
