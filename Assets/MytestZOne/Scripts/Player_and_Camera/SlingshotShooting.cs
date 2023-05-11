using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunPos;
    [SerializeField] private TrajectoryRenderer Trajectory;
    [SerializeField] private AudioClip _stretchAudio;
    [SerializeField] private AudioClip _shootAudio;
    [SerializeField] private bool _isReadyToShoot = true;
    [SerializeField] private Animator boy;

    private bool pressed;
    
    private float power = 10f;

    const float powerConst = 10f;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = boy.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController._canMove && _isReadyToShoot)
        {
            CheckPress();
        }
    }

    void CheckPress()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StretchAnim();
            Trajectory.gameObject.SetActive(true);
            pressed = true;
            GetComponent<AudioSource>().PlayOneShot(_stretchAudio, 0.5f);
        }
        if (Input.GetMouseButtonUp(0) && pressed)
        {
            ShootAnim();
            GetComponent<AudioSource>().PlayOneShot(_shootAudio, 0.5f);
            Trajectory.gameObject.SetActive(false);
            Shoot(power);
            pressed = false;
            power = powerConst;
            _isReadyToShoot = false;
            StartCoroutine(WaitToShoot());
        }

        if (pressed)
        {
            if (power < 50f)
            {
                power += power * Time.deltaTime;
                Trajectory.ShowTrajectory(gunPos.transform.position, gunPos.transform.forward * power);
            }
            else
            {
                Trajectory.ShowTrajectory(gunPos.transform.position, gunPos.transform.forward * power);
            }
            
        }
    }

    void Shoot(float power)
    {
        GameObject bullet = Instantiate(bulletPrefab, gunPos.transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.Impulse);
    }

    void StretchAnim()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 1);
        _animator.SetBool("Stretch", true);
    }

    void ShootAnim()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack Layer"), 0);
        _animator.SetBool("Stretch", false);
    }


    IEnumerator WaitToShoot()
    {
        yield return new WaitForSeconds(2);
        _isReadyToShoot = true;
    }

}
