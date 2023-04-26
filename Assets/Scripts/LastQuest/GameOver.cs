using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _endScreen;
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _leftArm;
    [SerializeField] GameObject _rightArm;
    [SerializeField] GameObject _camera;

    walk _scriptWalk;
    arms _scriptLeftArm;
    arms _scriptRightArm;
    camera _cameraScript;
    Animator _animPlayer;
    AudioSource _steps;

    // Start is called before the first frame update
    void Start()
    {
        _scriptWalk = _Player.GetComponent<walk>();
        _scriptLeftArm = _leftArm.GetComponent<arms>();
        _scriptRightArm = _rightArm.GetComponent<arms>();
        _cameraScript = _camera.GetComponent<camera>();
        _steps = _Player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animPlayer.enabled = false;
            _endScreen.SetActive(true);
            _scriptWalk.enabled = false;
            _scriptLeftArm.enabled = false;
            _scriptRightArm.enabled = false;
            _cameraScript.enabled = false;
            _steps.enabled = false;
            gameObject.SetActive(false);
        }

    }
}
