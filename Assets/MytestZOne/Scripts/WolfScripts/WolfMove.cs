using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfMove : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _spawnPosPlayer;
    [SerializeField] private Transform _spawnPosWolf;

    private NavMeshAgent _bot;
    private bool _bringToZone = false;
    private bool _isStarted = false;
    private bool _isAgred = false;

    // Start is called before the first frame update
    void Start()
    {
        _bot = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_isAgred && (Vector3.Distance(transform.position, _player.position) < 20))
        {
            _bot.SetDestination(_player.position);
        }
        if(_bringToZone && _bringToZone)
        {
            Debug.Log("wolf is come");
        }

        if(Vector3.Distance(transform.position, _player.position) < 5 && !_isStarted)
        {
            _isStarted = true;
            StartCoroutine(jump());
        }
    }

    IEnumerator jump()
    {
        float progress = 0;
        while (Vector3.Distance(transform.position, _player.position) > 2)
        {
            transform.position = Vector3.Lerp(transform.position, _player.position, progress);
            progress += Time.deltaTime;
            yield return null;
        }
        _isStarted = false;
        ResetPos();
    }

    IEnumerator backToSpawn()
    {
        _bot.SetDestination(_spawnPosWolf.position);
        yield return true;
    }

    public void SetPlayerPosToBot()
    {
        _bot.SetDestination(_player.position);
        if (!_isAgred)
        {
            _isAgred = true;
        }
    }

    public bool IsAgreed()
    {
        return _isAgred;
    }

    public bool GetIsBringToZone()
    {
        return _bringToZone;
    }

    public void SetIsBringToZone(bool value)
    {
        StartCoroutine(backToSpawn());
        _bringToZone = value;
    }

    private void ResetPos()
    {
        _isAgred = false;
        gameObject.GetComponentInChildren<WolfHP>().ResetHp();
        _player.transform.position = _spawnPosPlayer.transform.position;
        transform.position = _spawnPosWolf.transform.position;
        _bot.SetDestination(_spawnPosWolf.transform.position);
    }
}
