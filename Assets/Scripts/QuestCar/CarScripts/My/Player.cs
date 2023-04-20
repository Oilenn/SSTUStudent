using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Car _car { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        _car = GetComponent<Car>();
    }

    // Update is called once per frame
    void Update()
    {
        _car._forward = Input.GetAxis("Vertical");
        _car._turn = Input.GetAxis("Horizontal");
    }
}
