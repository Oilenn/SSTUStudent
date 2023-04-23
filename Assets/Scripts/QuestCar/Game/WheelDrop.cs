using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelDrop : MonoBehaviour
{
    [SerializeField] GameObject _first;
    [SerializeField] GameObject _second;
    [SerializeField] GameObject _third;

    // Update is called once per frame
    void Update()
    {
        
    }

    void FirstReplic()
    {
        _first.SetActive(true);
    }

    void SecondReplic()
    {
        _first.SetActive(false);
        _second.SetActive(true);
    }

    void ThirdReplic()
    {
        _second.SetActive(false);
        _third.SetActive(true);
    }

    void offReplic()
    {
        _third.SetActive(false);
    }
}
