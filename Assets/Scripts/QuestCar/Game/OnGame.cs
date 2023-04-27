using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGame : MonoBehaviour
{

    public GameObject _gameStarter;
    public GameObject _helpInfo;
    public GameObject _aimCan;
    public GameObject _talkNik;
    [SerializeField] GameObject _door;
    [SerializeField] camera _scriptCamera;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _LeftArm;
    [SerializeField] GameObject _RightArm;
    [SerializeField] GameObject _GameMenu;


    Animator _animCamera;
    Animator _playerAnim;
    walk _scriptWalk;
    playerGun _scriptCar;
    arms _scriptLeft;
    arms _scriptRight;

    AudioSource _steps;

    void Start()
    {
        _scriptCamera = gameObject.GetComponent<camera>();
        _animCamera = gameObject.GetComponent<Animator>();

        _steps = _player.GetComponent<AudioSource>();
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
        _steps.enabled = true;

        _scriptCamera.enabled = true;
        _animCamera.enabled = false;

        _scriptWalk.enabled = true;
        _scriptCar.enabled = true;
        _scriptLeft.enabled = true;
        _scriptRight.enabled = true;

        _playerAnim.enabled = true;

        _LeftArm.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        _RightArm.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        _door.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        _GameMenu.SetActive(true);
        _helpInfo.SetActive(true);
        _aimCan.SetActive(true);
        _talkNik.SetActive(true);
        Invoke("HelpOff", 4f);
    }

    void HelpOff()
    {
        _helpInfo.SetActive(false);
    }
}
