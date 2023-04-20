using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGame : MonoBehaviour
{
    public GameObject _gameStarter;


    void Start()
    {
        

    }


    void GameOn()
    {
        _gameStarter.SetActive(true);
    }
}
