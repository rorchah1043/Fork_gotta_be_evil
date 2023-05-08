using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private float _fadeTimeMultiplier = 2f;
    [SerializeField] private CharacterController _characterController;

    private void Awake()
    {
        _characterController.detectCollisions = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Water"))
        {            
            Vector3 respawnPosition = (_characterController.transform.position - collision.collider.ClosestPoint(_characterController.transform.position)) * 10;
            StartCoroutine(FadeIn(respawnPosition));
        }

    }
    
    private IEnumerator FadeIn(Vector3 respawnPosition)
    {
        _characterController.Move(Vector3.zero);
        _characterController.enabled = false;
        while (_image.color.a < 1)
        {
            Color newColor = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a + Time.deltaTime * _fadeTimeMultiplier);
            _image.color = newColor;
            Debug.Log("FadingOUT");
            yield return null;
        }
        _characterController.enabled = true;
        _characterController.Move(respawnPosition);
        _characterController.enabled = false;
        
        while (_image.color.a > 0)
        {
            Color newColor = new Color(_image.color.r, _image.color.g, _image.color.b, _image.color.a - Time.deltaTime * _fadeTimeMultiplier);
            _image.color = newColor;
            yield return null;
        }
        _characterController.enabled = true;

    }
}
