using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearTableCanvas : MonoBehaviour
{
    public Animator _AnimCamera;

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

    camera _scriptCamera;
    arms _scriptArm;
    arms _scriptArm2;
    walk _sciptPlayerEnabled1;
    playerGun _sciptPlayerEnabled2;
    CarController _sciptCarEnabled;
    Animation _animCar;


    // Start is called before the first frame update
    void Start()
    {
        _sciptPlayerEnabled1 = _Player.GetComponent<walk>();
        _sciptPlayerEnabled2 = _Player.GetComponent<playerGun>();
        _sciptCarEnabled = _carMain.GetComponent<CarController>();
        _animCar = _car.GetComponent<Animation>();
        _scriptArm = _LeftHand.GetComponent<arms>();
        _scriptArm2 = _RightHand.GetComponent<arms>();
        _scriptCamera = _mainCamera.GetComponent<camera>();

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            _InputCanvas.SetActive(true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _InputCanvas.SetActive(false);
            _scriptCamera.enabled = false;
            _AnimCamera.enabled = true;
            _sciptPlayerEnabled1.enabled = false;
            _sciptPlayerEnabled2.enabled = false;
            _scriptArm.enabled = false;
            _scriptArm2.enabled = false;

            gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _InputCanvas.SetActive(false);
    }

}
