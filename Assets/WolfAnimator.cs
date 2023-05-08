using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfAnimator : MonoBehaviour
{
    [SerializeField] NavMeshAgent _navMeshAgent;
    private Animator _animator;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (_navMeshAgent.velocity != Vector3.zero)
        {
            _animator.SetBool("Run",true);
        }
        
    }
}
