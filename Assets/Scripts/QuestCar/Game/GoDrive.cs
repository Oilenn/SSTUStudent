using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDrive : MonoBehaviour
{
    [Header("Cars")]
    [SerializeField] GameObject _carMain;
    [SerializeField] GameObject _car;

    CarController _sciptCarEnabled;
    Animator _carAnim;
    void Start()
    {
        _sciptCarEnabled = _carMain.GetComponent<CarController>();
        _carAnim = _car.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Drive()
    {
        _sciptCarEnabled.enabled = true;
        _carAnim.enabled = true;
    }
}
