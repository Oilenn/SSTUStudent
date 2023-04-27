using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunning : MonoBehaviour
{
    [SerializeField] private Rigidbody _rbLeftFoot, _rbRightFoot;
    [SerializeField] private Transform _playerTransform;

    public Animator anim;
    public HingeJoint leftLeg, rightLeg;

    //private float _rotationSpeed = 5110;

    private void Start()
    {
        anim.speed = 1.5f;
        _rbLeftFoot.mass = 0.25f;
        _rbRightFoot.mass = 0.25f;
        leftLeg.useSpring = false; rightLeg.useSpring = false;
    }

    void Update()
    {
        if(_playerTransform.position.x > transform.position.x)
        {

        }
    }
}
