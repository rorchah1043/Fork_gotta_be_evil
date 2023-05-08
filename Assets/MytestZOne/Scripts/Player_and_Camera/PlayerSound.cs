using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private AudioSource audioPlayer;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }

    public void PlaySoundOneShot(AudioClip audio)
    {
        audioPlayer.PlayOneShot(audio);
    }

    public void PlaySound(AudioClip audio)
    {
        if (audioPlayer.isPlaying) return;
        audioPlayer.clip = audio;
        audioPlayer.Play();
    }

    public void StopSound()
    {
        audioPlayer.Stop();
    }
}
