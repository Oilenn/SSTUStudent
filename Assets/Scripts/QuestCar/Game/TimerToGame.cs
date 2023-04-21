using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToGame : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _camera;
 
    [Header ("Timer")]
    [SerializeField] GameObject _gameStarter;

    [Header("Cars")]
    [SerializeField] GameObject _carMain;
    [SerializeField] GameObject _car;

    CarController _sciptCarEnabled;
    Animator _carAnim;
    Animator _playTimer;
    // Start is called before the first frame update
    void Start()
    {
        _playTimer = gameObject.GetComponent<Animator>();
        _sciptCarEnabled = _carMain.GetComponent<CarController>();
        _carAnim = _car.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && _gameStarter.active)
        {
            _gameStarter.SetActive(false);
            _playTimer.enabled = true;
        }
    }

    void Drive()
    {
        _sciptCarEnabled.enabled = true;
        _carAnim.enabled = true;
        _mainCamera.SetActive(false);
        _camera.SetActive(true);
    }
}
