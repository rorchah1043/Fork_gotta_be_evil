using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepAudio : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioStep;
    [SerializeField] private AudioSource audioPlayer;

    void FootStep()
    {
        GetComponentInParent<PlayerSound>().PlaySoundOneShot(audioStep[Random.Range(0, audioStep.Length)]);
    }
}
