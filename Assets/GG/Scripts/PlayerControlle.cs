using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControlle : MonoBehaviour
{
    public Animator _Anim;

    public float _speed;
    public float _strafeSpeed;
    public float _jumpForce;

    public Rigidbody _hips;
    public bool _isGrounded;


    void Start()
    {
        _hips = GetComponent<Rigidbody>();    
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        MoveBody();
        
    }

    void MoveBody()
    {
        if (Input.GetAxis("Vertical") > 0)
        {

            if (_isGrounded == true)
            {
                _Anim.SetBool("isWalking", true);
                _hips.AddForce(_hips.transform.forward * _speed, ForceMode.Force);
            }

            else
            {
                _hips.AddForce(0f, 0f, 0f);
            }

        }

        else
        {
            _Anim.SetBool("isWalking", false);
        }

        if (Input.GetAxis("Vertical") < 0)
        {

            if (_isGrounded == true)
            {
                _Anim.SetBool("isWalking", true);
                _hips.AddForce(-_hips.transform.forward * _speed, ForceMode.Force);
            }

            else
            {
                _hips.AddForce(0f, 0f, 0f);
            }

        }

        else if(!Input.GetKey(KeyCode.W))
        {
            _Anim.SetBool("isWalking", false);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {

            if (_isGrounded == true)
            {
                _Anim.SetBool("StrafeRight", true);
                _hips.AddForce(_hips.transform.right * _strafeSpeed, ForceMode.Force);
            }

            else
            {
                _hips.AddForce(0f, 0f, 0f);
            }
        }

        else
        {
            _Anim.SetBool("StrafeRight", false);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {

            if (_isGrounded == true)
            {
                _Anim.SetBool("StrafeLeft", true);
                _hips.AddForce(-_hips.transform.right * _strafeSpeed, ForceMode.Force);
            }

            else
            {
                _hips.AddForce(0f, 0f, 0f);
            }

        }

        else
        {
            _Anim.SetBool("StrafeLeft", false);
        }

        /*if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _hips.AddForce(_hips.transform.forward * _speed * 1.5f, ForceMode.Force);
            }

            _hips.AddForce(_hips.transform.forward * _speed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _hips.AddForce(-_hips.transform.right * _speed * 1.5f, ForceMode.Force);
            }

            _hips.AddForce(-_hips.transform.right * _strafeSpeed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _hips.AddForce(-_hips.transform.forward * _speed * 1.5f, ForceMode.Force);
            }

            _hips.AddForce(-_hips.transform.forward * _speed, ForceMode.Force);
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                _hips.AddForce(_hips.transform.right * _speed * 1.5f, ForceMode.Force);
            }

            _hips.AddForce(_hips.transform.right * _strafeSpeed, ForceMode.Force);
        }*/
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isGrounded)
            {
                _hips.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }
        }
    }
}
