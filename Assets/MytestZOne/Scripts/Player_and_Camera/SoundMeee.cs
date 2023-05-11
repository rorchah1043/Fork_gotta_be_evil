using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMeee : MonoBehaviour
{
    private bool _isReady = true;
    private bool _isMeeeSound = false;
    [SerializeField] private AudioClip _MeeeSound;
    private AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _isMeeeSound && _isReady)
        {
            PlaySound();
            _isReady = false;
            StartCoroutine(WaitMee());
        }
    }

    public void PlaySound()
    {
        audio.PlayOneShot(_MeeeSound, 0.5f);
    }

    public void SetIsMeeSound()
    {
        _isMeeeSound = true;
    }

    IEnumerator WaitMee()
    {
        yield return new WaitForSeconds(3);
        _isReady = true;
    }
}
