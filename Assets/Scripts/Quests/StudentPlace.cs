using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentPlace : MonoBehaviour
{
    [SerializeField] MathWoman _mathWoman;

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _cam;
    [SerializeField] private GameObject _camRot;
    [SerializeField] private GameObject _playerSat;

    [SerializeField] private GameObject _playerPrefab;

    [SerializeField] private GameObject _satInfo;

    private Lesson _les;

    private Transform _previousPosition;

    public bool HasExit { get; private set; }
    public bool HasSat { get; private set; }

    private void Start()
    {
        _les = transform.parent.GetComponent<Lesson>();
        HasExit = true;
        HasSat = false;
    }

    private void ChangePreviousPosition()
    {
        _previousPosition = GameObject.FindGameObjectWithTag("PreviousPosition").transform;
    }

    private void SitDownPlayer()
    {
        HasSat = true;
        _playerSat.SetActive(true);

        ChangePreviousPosition();
        Destroy(_player);
        _cam.SetActive(false);
        _camRot.SetActive(false);
    }

    public void StandPlayerUp()
    {
        HasSat = false;
        _playerSat.SetActive(false);

        _player = Instantiate(_playerPrefab);
        _player.transform.position = _previousPosition.position;
        _player.transform.rotation = _previousPosition.rotation;
        _cam.SetActive(true);
        _camRot.SetActive(true);
    }

    //Игрок отходит от стола
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_les.LessonStarted) HasExit = true;
        }
    }

    //Игрок садится за своё место
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HasExit = false;
        }
    }

    private void Update()
    {
        if (!_les.LessonEnded)
        {
            if (!HasExit && !HasSat)
            {
                _satInfo.SetActive(true);
            }
            else
            {
                _satInfo.SetActive(false);
            }

            if (HasExit == false)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!_les.LessonStarted)
                    {
                        _les.StartLesson();
                    }

                    if (!_playerSat.activeSelf)
                    {
                        SitDownPlayer();
                    }
                    else
                    {
                        StandPlayerUp();
                    }
                }
            }
        }
    }
}
