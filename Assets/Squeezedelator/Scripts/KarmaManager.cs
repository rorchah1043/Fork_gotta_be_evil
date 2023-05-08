using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KarmaManager : MonoBehaviour
{
    [SerializeField] private Slider _sliderRight;
    [SerializeField] private Slider _sliderLeft;
    private Slider _currentSlider;
    private float _sliderValue = 0;
    private static float _value = 0, _tmp = 0;
    private float _karmaValue = 0f;

    // Start is called before the first frame update
    private void Start()
    {
        //_sliderRight.value = 60;
        _currentSlider = _sliderRight;
    }

    // Update is called once per frame
    private void Update()
    {
        
        if(_value != _tmp)
        {
            ChangeKarma(_value);
            
        }
        CheckSlider();
    }

    public void ChangeKarma(float value)
    {
        _sliderValue += value;  
        _tmp = _value;
    }

    private void CheckSlider()
    {
        if(_sliderValue >= 0 && CheckCurrent())
        {
            _currentSlider.value = _sliderValue;
        }else if(_sliderValue > 0 && !CheckCurrent())
        {
            _currentSlider.value = 0;
            _currentSlider = _sliderRight;
        }

        if(_sliderValue < 0 && !CheckCurrent())
        {
            _currentSlider.value = Mathf.Abs(_sliderValue);
        }else if(_sliderValue < 0 && CheckCurrent())
        {
            _currentSlider.value = 0;
            _currentSlider = _sliderLeft;
        }

    }

    private bool CheckCurrent()
    { 
        if(_currentSlider == _sliderRight)
        {
            return true;
        }
        if(_currentSlider == _sliderLeft)
        {
            return false;
        }
        return true;
    }

    public static void Test(float value)
    {
        _value = value;
    }

   
}
