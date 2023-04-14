﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public bool aiming;
    private Transform targetTransform;
    public Transform aimingTarget;
    public Transform notAimingTarget;
    private Camera _Cam;
    public Camera Cam
    {
        get
        {
            if (_Cam == null)
            {
                _Cam = GetComponent<Camera>();
            }
            return _Cam;
        }
    }
    public Vector3 CamOffset = Vector3.zero;
    public Vector3 ZoomOffset = Vector3.zero;
    public float senstivity = 5;
    public float minY = 30;
    public float maxY = 50;
    public bool isZooming;
    private float currentX = 0;
    private float currentY = 1;
    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * senstivity;
        currentY += Input.GetAxis("Mouse Y") * senstivity;
        currentX = Mathf.Repeat(currentX, 360);
        currentY = Mathf.Clamp(currentY, minY, maxY);

        if (aiming)
        {
            targetTransform = aimingTarget;
            CamOffset = new Vector3(0, 0, -8);
        }
        else
        {
            targetTransform = notAimingTarget;
            CamOffset = new Vector3(0, 0, -10);
        }

    }

    void LateUpdate()
    {
        Vector3 dist = isZooming ? ZoomOffset : CamOffset;
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = targetTransform.position + rotation * dist;
        transform.LookAt(targetTransform.position);
    }
    

}
