using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheel Colliders")]
    public List<WheelCollider> Front_Wheels; 
    public List<WheelCollider> Back_Wheels; 

    [Header("Wheel Transforms")]
    public List<Transform> Front_Wheel_Transforms; 
    public List<Transform> Back_Wheel_Transforms;

    [Header("Wheel Transforms Rotations")]
    public List<Vector3> Front_Wheel_Rotation;
    public List<Vector3> Back_Wheel_Rotation;

    [Header("Car Info")]
    public AxleInfo[] _carAxis = new AxleInfo[2];

    public float _carSpeed;
    public float _steerAngel;

    float _horInput;
    float _verInput;


    public void Update()
    {
        var pos = Vector3.zero; 
        var rot = Quaternion.identity;

        for (int i = 0; i < (Back_Wheels.Count); i++)
        {
            Back_Wheels[i].GetWorldPose(out pos, out rot); //get the world rotation & position of the wheel colliders
            Back_Wheel_Transforms[i].position = pos; //Set the wheel transform positions to the wheel collider positions
            Back_Wheel_Transforms[i].rotation = rot * Quaternion.Euler(Back_Wheel_Rotation[i]); //Rotate the wheel transforms to the rotation of the wheel collider(s) and the rotation offset
        }

        for (int i = 0; i < (Front_Wheels.Count); i++)
        {
            Front_Wheels[i].GetWorldPose(out pos, out rot); //get the world rotation & position of the wheel colliders
            Front_Wheel_Transforms[i].position = pos; //Set the wheel transform positions to the wheel collider positions
            Front_Wheel_Transforms[i].rotation = rot * Quaternion.Euler(Front_Wheel_Rotation[i]); //Rotate the wheel transforms to the rotation of the wheel collider(s) and the rotation offset
        }
    }

    private void FixedUpdate()
    {
        _horInput = Input.GetAxis("Horizontal");
        _verInput = Input.GetAxis("Vertical");

        Accelerate();
    }


    void Accelerate()
    {
        foreach(AxleInfo axle in _carAxis)
        {
            if (axle._steering)
            {
                axle._rightWheel.steerAngle = _steerAngel * _horInput;
                axle._leftWheel.steerAngle = _steerAngel * _horInput;
            }

            if (axle.motor)
            {
                axle._rightWheel.motorTorque = _carSpeed * _verInput;
                axle._leftWheel.motorTorque = _carSpeed * _verInput;
            }

            VisualWheelsToColliders(axle._rightWheel, axle._visRightWheel);
            VisualWheelsToColliders(axle._leftWheel, axle._visLeftWheel);
        }
    }

    void VisualWheelsToColliders(WheelCollider _Col, Transform _visWheel)
    {
        Vector3 position;
        Quaternion rotation;

        _Col.GetWorldPose(out position, out rotation);

        _visWheel.position = position;
        _visWheel.rotation = rotation;
    }

}

[System.Serializable]
public class AxleInfo
{
    public WheelCollider _rightWheel;
    public WheelCollider _leftWheel;

    public Transform _visRightWheel;
    public Transform _visLeftWheel;

    public bool _steering;
    public bool motor;



}