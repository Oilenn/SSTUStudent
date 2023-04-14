using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbTrigger : MonoBehaviour
{
    public PlayerControlle _playerController;
    void Start()
    {
        _playerController = GameObject.FindObjectOfType<PlayerControlle>().GetComponent<PlayerControlle>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            _playerController._isGrounded = true;
        }
    }
}
