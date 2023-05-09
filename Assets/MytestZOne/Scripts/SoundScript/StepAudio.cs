using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioStep;
    private AudioSource audioPlayer;

    void FootStep()
    {
        GetComponentInParent<AudioSource>().PlayOneShot(audioStep[Random.Range(0, audioStep.Length)]);
    }
}
