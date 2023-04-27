using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentPlace : MonoBehaviour
{
    [SerializeField] MathWoman _mathWoman;

    [Header("Player prefabs")]
    [SerializeField] private GameObject _player;//�������� �����
    [SerializeField] private GameObject _playerSat;//����� ������
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
        _mainPlayer = GameObject.FindGameObjectWithTag("MainPlayer").transform;
        _les = transform.parent.GetComponent<Lesson>();
        _previousRotation = _toStandUp.rotation;
        _previousPosition = _toStandUp.transform.position;
        HasExit = true;
        HasSat = false;
    }

    private void MovePlayerUnderGround()
    {
        _player.transform.position = new Vector3(-120, 0.65f);
    }

    private void SitDownPlayer()
    {
        //_player.transform.GetChild(0).GetComponent<walk>().enabled = false;
        HasSat = true;
        _playerSat.SetActive(true);
        print("Sat down");
        Cursor.visible = true;

        MovePlayerUnderGround();
    }

    public void StandPlayerUp()
    {
        //_player.transform.GetChild(0).GetComponent<walk>().enabled = true;
        HasSat = false;
        _playerSat.SetActive(false);
        print("Stand up");
        Cursor.visible = false;

        _player.transform.position = _previousPosition;
        _player.transform.rotation = _previousRotation;
    }

    //����� ������� �� �����
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_les.LessonStarted && !HasSat) HasExit = true;
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

            if (!HasExit)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!_les.LessonStarted)
                    {
                        _les.StartLesson();
                    }

                    if (!_playerSat.activeSelf)
                    {
                        print("sit");
                        SitDownPlayer();
                    }
                    else
                    {
                        print("up");
                        StandPlayerUp();
                    }
                }
            }
        }
    }
}
