using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed = 7.5f;
    [SerializeField] private float _walkSpeed = 3.5f;
    [SerializeField] private float _jumpSpeed = 8.0f;
    [SerializeField] private float _gravity = 20.0f;
    [SerializeField] private Transform _playerCameraParent;
    [SerializeField] private float _lookSpeed = 2.0f;
    [SerializeField] private float _lookXLimit = 60.0f;

    private CharacterController _characterController;
    private Vector3 _moveDirection = Vector3.zero;
    private Vector2 _rotation = Vector2.zero;

    [HideInInspector]
    public static bool _canMove = true;
    private Animator _animator;


    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _rotation.y = transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (_characterController.isGrounded)
        {
            // We are grounded, so recalculate move direction based on axes
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                _speed = _runSpeed;
            }
            else
            {
                _speed = _walkSpeed;
            }

            float curSpeedX = _canMove ? _speed * Input.GetAxis("Vertical") : 0;
            float curSpeedY = _canMove ? _speed * Input.GetAxis("Horizontal") : 0;

            _moveDirection = (forward * curSpeedX) + (right * curSpeedY);
            
            



            
            if (Input.GetButton("Jump") && _canMove)
            {
                Jump();
                _moveDirection.y = _jumpSpeed;
            }
            if (_moveDirection == Vector3.zero)
            {
                Idle();
            }
            else if (_moveDirection != Vector3.zero && _speed == _runSpeed)
            {
                Run();
            }else if(_moveDirection != Vector3.zero && _speed == _walkSpeed)
            {
                Walk();
            }
           
        }
        

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        _moveDirection.y -= _gravity * Time.deltaTime;

        // Move the controller
        _characterController.Move(_moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (_canMove && !DialogueManager.isActive)
        {
            _rotation.y += Input.GetAxis("Mouse X") * _lookSpeed;
            _rotation.x += -Input.GetAxis("Mouse Y") * _lookSpeed;
            _rotation.x = Mathf.Clamp(_rotation.x, -_lookXLimit, _lookXLimit);
            _playerCameraParent.localRotation = Quaternion.Euler(_rotation.x, 0, 0);
            transform.eulerAngles = new Vector2(_rotation.x, _rotation.y);
        }
    }

    private void Idle()
    {
        
        _animator.SetFloat("Speed", 0f, 0.1f, Time.deltaTime);
        
    }

    private void Walk()
    {
        _animator.SetFloat("Speed", 0.3f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        _animator.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }
    private void Jump()
    {
        _animator.SetTrigger("Jump");
    }
}
