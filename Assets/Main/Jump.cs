using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float _jumpForce;
    
    public Rigidbody _body;
    public bool _isGrounded;


    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.LogWarning(_isGrounded);
            if (_isGrounded)
            {
                _body.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
                _isGrounded = false;
            }
        }
    }
}
