using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowAnimator : MonoBehaviour
{
    private Animator _animator;
    private float _time = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;
        if(_time < 0)
        {
            _time = Random.Range(1,8);
            _animator.SetTrigger("Walk");
        }
    }
}
