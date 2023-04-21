using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubik2 : MonoBehaviour
{
    [SerializeField] GameObject _Cube;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            gameObject.SetActive(false);
            _Cube.SetActive(true);
        }
    }
}
