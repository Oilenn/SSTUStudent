using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : MonoBehaviour
{
    [Header("Phrases. The first element must to be name of a character.")]
    [SerializeField] private List<string> CameAtLesson = new List<string>();
    [SerializeField] private List<string> SatDown = new List<string>();
    [SerializeField] private List<string> Warning = new List<string>();

    [SerializeField] private GameObject _workPaper;
    [SerializeField] private GameObject _player;

    private Lesson _lesson;

    private Transform _colliderZone;//������� �������� ����� ������(�����)
    private bool _hasWorkOpened;//������� �� ������ ������

    [Header("")]
    [SerializeField] private GameObject _window;//������ ����������� ����
    private DialogWindow _dialogWindow;

    private void Start()
    {
        _lesson = GetComponent<Lesson>();
        _colliderZone = transform.GetChild(0);
        //_player = GameObject.FindGameObjectWithTag("Player");
        _dialogWindow = _window.GetComponent<DialogWindow>();
    }

    private void StartDialog(string name, Queue<string> phrases)
    {
        _window.SetActive(true);
        _dialogWindow.SetNameAndMono(name, phrases);
    }

    //��������� ������, ������� ����� ����������� ���� ��� � ������ �� �������������
    private void PlayDialogOnce(List<string> PhrasesLst)
    {
        if (PhrasesLst.Count > 0)
        {
            Queue<string> phrases = new Queue<string>(PhrasesLst);
            StartDialog(phrases.Dequeue(), new Queue<string>(phrases));
            PhrasesLst.Clear();
        }
    }

    //��������� ���������������� ������
    private void PlayDialog(List<string> PhrasesLst)
    {
        Queue<string> phrases = new Queue<string>(PhrasesLst);
        StartDialog(phrases.Dequeue(), phrases);
    }

    private void Update()
    {
        //������,����� ����� ������ �� ����
        if (_lesson.HasCame)
        {
            PlayDialogOnce(CameAtLesson);
        }

        //������, ����� ����� ��� �� �����
        if (_lesson.LessonStarted)
        {
            PlayDialogOnce(SatDown);
        }

        if (_lesson.HasFind)
        {
            PlayDialog(Warning);
        }

        //Debug.Log(_colliderZone.transform.position);
        //Debug.Log(_player.transform.position);
        if (!_hasWorkOpened)
        {
            if (Vector3.Distance(_colliderZone.transform.position, _player.transform.position) < 1)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Debug.Log("Opened");
                    _workPaper.SetActive(true);
                    _hasWorkOpened = true;
                }
            }
        }
        else if (_hasWorkOpened)
        {
            if (Input.GetKeyDown(KeyCode.R) || Vector3.Distance(_colliderZone.transform.position, _player.transform.position) > 2)
                {
                    Debug.Log("Closed");
                    _workPaper.SetActive(false);
                    _hasWorkOpened = false;
                }
            }
            /*
            if (Input.GetKeyDown(KeyCode.E) && !_window.activeSelf)
            {
                Queue<string> phrases = new Queue<string>(CameAtLesson);
                //������ ������� � ������� - ��� ���������, � ��� ����� ������� ������.
                StartDialog(phrases.Dequeue(), phrases);
            }
            */
        }
    }
