using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    [SerializeField] private Rigidbody _rbLeftFoot, _rbRightFoot;

    public Animator anim;
    public GameObject com;
    public Transform cam;
    public HingeJoint leftLeg, rightLeg;

    private float _rotationSpeed = 5110;

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            com.transform.rotation = Quaternion.LookRotation(cam.forward);
        }
        if (Input.GetKey(KeyCode.A))
        {
            com.transform.rotation = Quaternion.LookRotation(-cam.right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            com.transform.rotation = Quaternion.LookRotation(-cam.forward);
        }
        if (Input.GetKey(KeyCode.D))
        {
            com.transform.rotation = Quaternion.LookRotation(cam.right);
        }

        if(!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            anim.Play("idle");
            leftLeg.useSpring = true; rightLeg.useSpring = true;
        }
        else
        {
            anim.Play("walk");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.speed = 2;
                _rbLeftFoot.mass = 0.25f;
                _rbRightFoot.mass = 0.25f;
            }
            else
            {
                anim.speed = 1;
                _rbLeftFoot.mass = 1;
                _rbRightFoot.mass = 1;
            }
            leftLeg.useSpring = false; rightLeg.useSpring = false;
        }
    }
}
