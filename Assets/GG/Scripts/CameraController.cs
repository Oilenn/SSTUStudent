using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float _rotationSpeed = 1f;
    public Transform _root;
    public ConfigurableJoint _hipJoint, _stomachJoint;

    float _mouseX, _mouseY;

    public float _stomachOffset;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CamControll();
    }

    void CamControll()
    {
        _mouseX += Input.GetAxis("Mouse X") * _rotationSpeed;
        _mouseY -= Input.GetAxis("Mouse Y") * _rotationSpeed;
        _mouseY = Mathf.Clamp(_mouseY, -35, 60);

        Quaternion _rootRotation = Quaternion.Euler(_mouseY, _mouseX, 0);

        _root.rotation = _rootRotation;

        _hipJoint.targetRotation = Quaternion.Euler(0, _mouseX, 0);
        _stomachJoint.targetRotation = Quaternion.Euler(-_mouseY + _stomachOffset, 0, 0);
    }
}
