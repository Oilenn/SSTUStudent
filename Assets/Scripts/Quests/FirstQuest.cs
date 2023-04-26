using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FirstQuest : MonoBehaviour
{
    [Header("Phrases. The first element must to be name of a character.")]
    [SerializeField] private List<string> CameAtLesson = new List<string>();
    [SerializeField] private List<string> SatDown = new List<string>();
    [SerializeField] private List<string> Warning = new List<string>();
    [SerializeField] private List<string> EndOfLesson = new List<string>();
    [SerializeField] private List<string> BadEndOfLesson = new List<string>();
    [Header("Phrases for work result")]
    [SerializeField] private List<string> WellDoneWork = new List<string>();
    [SerializeField] private List<string> AverageWork = new List<string>();
    [SerializeField] private List<string> BadWork = new List<string>();

    [Header("Targets")]
    [SerializeField] private GameObject _targetToCabinet;
    [SerializeField] private GameObject _targetToSit;
    [SerializeField] private GameObject _firstMostSmartest;
    [SerializeField] private GameObject _secondMostSmartest;
    [SerializeField] private GameObject _nikitaTarget;

    [Header("NPCs to talk")]
    [SerializeField] private List<NPC> Students = new List<NPC>();//������ ���� ���������, � �������� ����� ����������

    [Header("UI elements")]
    [SerializeField] private GameObject _workPaper;//����������� ������ ������
    [SerializeField] private GameObject _gameOverWarning;
    [SerializeField] private TMP_Text _task;

    //[Header("Player. Because of uncorrect\nmoving of player - 'chest' must to be here.")]
    //[SerializeField] private GameObject _player;

    [SerializeField] private LessonOut _colliderOut;//������ ��� ������ �� ��������
    [SerializeField] private ToTalkStudent _nikita;
    private Lesson _lesson;

    private StudentPlace _colliderZone;//������� �������� ����� ������(�����)

    private bool _hasWorkOpened;//������� �� ������ ������
    private bool _hasWalkedOut;//����� �� ����� �� ��������

    public bool HasGameOver { get; private set; }

    [Header("")]
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private GameObject _window;//������ ����������� ����
    [SerializeField] private ToQuest _toQuest;

    private void Start()
    {
        _lesson = GetComponent<Lesson>();
        _colliderZone = transform.GetChild(0).GetComponent<StudentPlace>();
        //_player = GameObject.FindGameObjectWithTag("Player");
    }

    //����� ��� ��������� "�������" - ���� ������ ����
    private void TrySetTarget(GameObject target)
    {
        if (!target.activeSelf)
        {
            target.SetActive(true);
        }
    }

    //��� ����������
    private void TryUnsetTarget(GameObject target)
    {
        if (target.activeSelf)
        {
            target.SetActive(false);
        }
    }

    private void ChangeTask(string text)
    {
        _task.text = text;
    }

    private void Update()
    {
        //��������� � NPC
        foreach (var npc in Students)
        {
            if (npc.HasEntered && Input.GetKeyDown(KeyCode.E) && !_window.activeSelf)
            {
                npc.transform.GetChild(0).gameObject.SetActive(false);
                _dialogManager.PlayDialog(npc.Phrases);
            }
            if (npc.HasJustLeft)
            {
                _dialogManager.StopDialog();
            }
        }

        if (!_lesson.LessonEnded)
        {
            //������, ����� ����� ������ �� ����
            if (_lesson.HasCame && !_lesson.LessonStarted)
            {
                TrySetTarget(_targetToSit);
                TryUnsetTarget(_targetToCabinet);
                ChangeTask("������ �� ���� �����");
                _dialogManager.PlayDialogOnce(CameAtLesson);
            }
            else
            {
                ChangeTask("����� �� �����");
            }
        }

        //����� ���� �������
        if(_lesson.LessonStarted && !_lesson.LessonEnded)
        {
            Debug.Log("Lesson");
            //������, ����� ����� ��� �� �����
            if (!_lesson.enabled)
            {
                _lesson.enabled = true;
                if (_lesson.HasSat())
                {
                    TrySetTarget(_firstMostSmartest);
                    TrySetTarget(_secondMostSmartest);
                    TryUnsetTarget(_targetToSit);
                    _dialogManager.PlayDialogOnce(SatDown);
                    _lesson.enabled = true;
                }
            }
            if (_lesson.LessonStarted)
            {
                ChangeTask("������� � ����� ����� �������� � ������");
            }

            if (_lesson.HasFind)
            {
                _dialogManager.PlayDialog(Warning);
            }

            if (_colliderZone.HasSat && !_workPaper.activeSelf)
            {
                _workPaper.SetActive(true);
            }
            else if (!_colliderZone.HasSat)
            {
                _workPaper.SetActive(false);
            }
        }
        else if(_lesson.LessonEnded)
        {
            TrySetTarget(_targetToCabinet);
            TryUnsetTarget(_firstMostSmartest);
            TryUnsetTarget(_secondMostSmartest);
        }

        if (_lesson.LessonEnded && _lesson.enabled)
        {
            ChangeTask("������� �� ��������");
            if (!_lesson.IsMathWomanWait && !_lesson.HasFind)
            {
                _dialogManager.PlayDialog(EndOfLesson);
                _colliderZone.StandPlayerUp();
            }
            else
            {
                _dialogManager.PlayDialog(BadEndOfLesson);
            }
            _lesson.enabled = false;
            _colliderOut.gameObject.SetActive(true);
            _toQuest.FinishLesson();
            this.enabled = false;
        }

        //Debug.Log(_colliderZone.transform.position);
        //Debug.Log(_player.transform.position);
    }
}
