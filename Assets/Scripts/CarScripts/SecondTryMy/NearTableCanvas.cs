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
    //[SerializeField] GameObject _GameCanvas;
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _carMain;
    [SerializeField] GameObject _car;
    [SerializeField] GameObject _LeftHand;
    [SerializeField] GameObject _RightHand;

    arms _sciptArm;
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
    }

    // Update is called once per frame
    void Update()
    {
        
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
            _mainCamera.SetActive(false);
            _gameCamera.SetActive(true);
            //_GameCanvas.SetActive(true);
            _sciptPlayerEnabled1.enabled = false;
            _sciptPlayerEnabled2.enabled = false;

            gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _InputCanvas.SetActive(false);
    }

}
