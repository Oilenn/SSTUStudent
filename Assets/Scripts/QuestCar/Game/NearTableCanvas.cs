using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearTableCanvas : MonoBehaviour
{

    [Header ("Cameras")]
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _gameCamera;


    [Header ("GameObjects")]
    [SerializeField] GameObject _InputCanvas;
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _carMain;
    [SerializeField] GameObject _car;
    [SerializeField] GameObject _LeftHand;
    [SerializeField] GameObject _RightHand;


    Animator _animPlayer;
    Animator _animCamera;

    camera _scriptCamera;
    arms _scriptArm;
    arms _scriptArm2;
    walk _sciptPlayerEnabled1;
    playerGun _sciptPlayerEnabled2;

    bool flag;


    // Start is called before the first frame update
    void Start()
    {
        _animPlayer = _Player.GetComponent<Animator>();
        _animCamera = _mainCamera.GetComponent<Animator>();

        _sciptPlayerEnabled1 = _Player.GetComponent<walk>();
        _sciptPlayerEnabled2 = _Player.GetComponent<playerGun>();
        _scriptArm = _LeftHand.GetComponent<arms>();
        _scriptArm2 = _RightHand.GetComponent<arms>();
        _scriptCamera = _mainCamera.GetComponent<camera>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && flag)
        {
            _InputCanvas.SetActive(false);

            _animCamera.enabled = true;
            _animCamera.Play("MoveToGame");
            _animPlayer.enabled = false;

            _scriptCamera.enabled = false;
            _sciptPlayerEnabled1.enabled = false;
            _sciptPlayerEnabled2.enabled = false;
            _scriptArm.enabled = false;
            _scriptArm2.enabled = false;

            gameObject.SetActive(false);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            flag = true;
            _InputCanvas.SetActive(true);
        }

    }


    private void OnTriggerExit(Collider other)
    {
        flag = false;
        _InputCanvas.SetActive(false);
    }

}
