using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _fadeTimeMultiplier = 2f;
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private Transform _respawnTransform;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _characterController.detectCollisions = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Water"))
        {            
            _audioSource.PlayOneShot(_audioSource.clip);
            StartCoroutine(FadeIn(_respawnTransform.position));
        }
    }
    
    private IEnumerator FadeIn(Vector3 respawnPosition)
    {
        _characterController.enabled = false;
        _animator.SetTrigger("Swim");
        yield return new WaitForSeconds(1.1f);
        while (_image.color.a < 1)
        {
            Color newColor = new(_image.color.r, _image.color.g, _image.color.b, _image.color.a + Time.deltaTime * _fadeTimeMultiplier);
            _image.color = newColor;
            Debug.Log("FadingOUT");
            yield return null;
        }
        _characterController.transform.position = respawnPosition;
        _animator.SetFloat("Speed", 0.1f);
        _characterController.enabled = true;
        while (_image.color.a > 0)
        {
            Color newColor = new (_image.color.r, _image.color.g, _image.color.b, _image.color.a - Time.deltaTime * _fadeTimeMultiplier);
            _image.color = newColor;
            yield return null;
        }    
    }
}
