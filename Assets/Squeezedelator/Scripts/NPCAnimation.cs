using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimation : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        if((_navMeshAgent.velocity).sqrMagnitude == 0)
        {
            _animator.SetFloat("Speed", 0.0f, 0.1f, Time.deltaTime);
        }
        else if ((_navMeshAgent.velocity).sqrMagnitude > 0)
        {
            _animator.SetFloat("Speed", 0.25f, 0.1f, Time.deltaTime);
        }
    }
}
