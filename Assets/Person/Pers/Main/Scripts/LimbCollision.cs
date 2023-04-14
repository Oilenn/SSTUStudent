using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public Jump _playerController;
    void Start()
    {
        _playerController = GameObject.FindObjectOfType<Jump>().GetComponent<Jump>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _playerController._isGrounded = true;
    }
}
