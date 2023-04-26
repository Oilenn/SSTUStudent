using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject _endScreen;
    [SerializeField] GameObject _Player;
    [SerializeField] GameObject _leftArm;
    [SerializeField] GameObject _rightArm;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject _lastRep;

    walk _scriptWalk;
    arms _scriptLeftArm;
    arms _scriptRightArm;
    camera _cameraScript;
    Animator _animPlayer;
    AudioSource _steps;

    // Update is called once per frame
    void Update()
    {
        _scriptWalk = _Player.GetComponent<walk>();
        _scriptLeftArm = _leftArm.GetComponent<arms>();
        _scriptRightArm = _rightArm.GetComponent<arms>();
        _cameraScript = _camera.GetComponent<camera>();
        _steps = _Player.GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _animPlayer.enabled = false;
            _endScreen.SetActive(true);
            _scriptWalk.enabled = false;
            _scriptLeftArm.enabled = false;
            _scriptRightArm.enabled = false;
            _cameraScript.enabled = false;
            _lastRep.SetActive(false);
            _steps.enabled = false;
            gameObject.SetActive(false);
        }
    }
}
