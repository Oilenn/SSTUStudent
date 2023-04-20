using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float _acceleration;
    public float _maxSteeringAngel;
    public Wheel[] _fontWheels;
    public Wheel[] _backWheels;

    [Range(-1, 1)]
    public float _forward;

    [Range(-1, 1)]
    public float _turn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(var wheel in _fontWheels)
        {
            wheel._collider.motorTorque = _forward * _acceleration;
            wheel._collider.steerAngle = Mathf.Lerp(wheel._collider.steerAngle, _turn * _maxSteeringAngel, 0.5f);
        }
    }
}
