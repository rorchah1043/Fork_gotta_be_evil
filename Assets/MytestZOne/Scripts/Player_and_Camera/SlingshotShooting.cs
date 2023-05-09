using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotShooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject gunPos;
    [SerializeField] private TrajectoryRenderer Trajectory;

    private bool pressed;
    
    private float power = 10f;

    const float powerConst = 10f;

    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController._canMove)
        {
            CheckPress();
        }
    }

    void CheckPress()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Trajectory.gameObject.SetActive(true);
            pressed = true;
            StretchAnim();
        }
        if (Input.GetMouseButtonUp(0))
        {
            ShootAnim();
            Trajectory.gameObject.SetActive(false);
            Shoot(power);
            pressed = false;
            power = powerConst;
            
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
        _animator.SetTrigger("Stretch");
    }


    IEnumerator ShootAnim()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack"), 1);
        _animator.SetTrigger("Shoot");

        yield return new WaitForSeconds(0.2f);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Attack"), 0);
    }

}
