using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGame : MonoBehaviour
{
    public GameObject _gameStarter;
    [SerializeField] camera _scriptCamera;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _LeftArm;
    [SerializeField] GameObject _RightArm;

    Animator _animCamera;
    Animator _playerAnim;
    walk _scriptWalk;
    playerGun _scriptCar;
    arms _scriptLeft;
    arms _scriptRight;

    void Start()
    {
        _scriptCamera = gameObject.GetComponent<camera>();
        _animCamera = gameObject.GetComponent<Animator>();

        _playerAnim = _player.GetComponent<Animator>();

        _scriptWalk = _player.GetComponent<walk>();
        _scriptCar = _player.GetComponent<playerGun>();
        _scriptLeft = _LeftArm.GetComponent<arms>();
        _scriptRight = _RightArm.GetComponent<arms>();
    }


    void GameOn()
    {
        _gameStarter.SetActive(true);
    }

    void ScriptOn()
    {
        _scriptCamera.enabled = true;
        _animCamera.enabled = false;

        _scriptWalk.enabled = true;
        _scriptCar.enabled = true;
        _scriptLeft.enabled = true;
        _scriptRight.enabled = true;

        _playerAnim.enabled = true;
    }
}
