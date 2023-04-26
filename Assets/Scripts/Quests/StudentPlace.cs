using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentPlace : MonoBehaviour
{
    [SerializeField] MathWoman _mathWoman;

    [Header("Player prefabs")]
    [SerializeField] private GameObject _player;//�������� �����
    [SerializeField] private GameObject _playerSat;//����� ������
    [SerializeField] private GameObject _playerPrefab;//������ ������. ��������� ������ - �������, ����� - ������.
    [SerializeField] private Transform _toStandUp;//������� ��� ����� ��������� �����, ����� �����

    [Header("UI Elements")]
    [SerializeField] private GameObject _toSatInfo;//����� � ���, ��� ����� ����� �����

    private Lesson _les;
    //���������� ������� ������ ����� ���������
    private Vector3 _previousPosition;
    private Quaternion _previousRotation;

    private Transform _mainPlayer;

    //����� �� ����� �� ���� ����������
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
        _previousPosition = _toStandUp.transform.position;
        _previousRotation = _toStandUp.transform.rotation;
    }

    private void SitDownPlayer()
    {
        HasSat = true;
        _playerSat.SetActive(true);

        ChangePreviousPosition();
        Destroy(_player);
    }

    public void StandPlayerUp()
    {
        HasSat = false;
        _playerSat.SetActive(false);

        _player = Instantiate(_playerPrefab);
        _mainPlayer = GameObject.FindGameObjectWithTag("MainPlayer").transform;
        _mainPlayer.transform.position = _previousPosition;
        _mainPlayer.transform.rotation = _previousRotation;
    }

    //����� ������� �� �����
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_les.LessonStarted) HasExit = true;
        }
    }

    //����� ������� �� ��� �����
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
                _toSatInfo.SetActive(true);
            }
            else
            {
                _toSatInfo.SetActive(false);
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
