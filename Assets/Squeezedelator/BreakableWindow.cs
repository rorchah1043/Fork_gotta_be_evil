using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWindow : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material _brokenGlassMaterial;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _audioClips;
 
    private bool _isBroken = false;

    private void Awake()
    {
        _audioSource.clip = _audioClips[Random.Range(0,_audioClips.Length)];
    }

    public void ChangeMaterial()
    {
        if (!_isBroken)
        {
             _meshRenderer.material = _brokenGlassMaterial;
             _audioSource.Play();
            _isBroken = true;
        }
         
    }
}
