using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
    public PlayerControlle _playerController;
    void Start()
    {
        _playerController = GameObject.FindObjectOfType<PlayerControlle>().GetComponent<PlayerControlle>();
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        _playerController._isGrounded = true;
    }*/
}
