using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _agent;
    private float _time;
    private bool _isBusy = false;
    private Vector3 _newPosition;

    // Start is called before the first frame update
    private void Start()
    {
           _time = Random.Range(3,10);
    }

    // Update is called once per frame
    private void Update()
    {
        _time -= Time.deltaTime;
        if (_time <= 0 && !_isBusy)
        {
            NewTarget();
            _animator.SetBool("Walk",true);
            _agent.SetDestination(_newPosition);
            _time = Random.Range(3, 10);
            _isBusy = true;
        }
        if((_agent.transform.position - _newPosition).sqrMagnitude < 10)
        {
            NewTarget();
        }

        //if(_agent.transform.position == _newPosition)
        //{
        //    _animator.SetBool("Walk", false);
        //    _isBusy = false;
        //}
        //else
        //{
        //    _isBusy = true;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        NewTarget();
    }

    private void NewTarget()
    {
        _newPosition = _agent.transform.position + new Vector3(Random.Range(3, 10), transform.position.y, Random.Range(3, 10));
    }
}
