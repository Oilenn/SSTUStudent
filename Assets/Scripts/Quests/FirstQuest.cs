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

    [Header("NPCs to talk")]
    [SerializeField] private List<NPC> Students = new List<NPC>();//Список всех студентов, с которыми можно поговорить

    [Header("UI elements")]
    [SerializeField] private GameObject _workPaper;//Контрольная работа игрока
    [SerializeField] private GameObject _gameOverWarning;
    [SerializeField] private TMP_Text _task;

    [Header("Player. Because of uncorrect\nmoving of player - 'chest' must to be here.")]
    [SerializeField] private GameObject _player;

    //[Header("")]
    //[SerializeField] private GameObject _playerToDelete;

    private Lesson _lesson;

    private StudentPlace _colliderZone;//Триггер рабочего места игрока(парта)
    private bool _hasWorkOpened;//Открыта ли работа игрока

    public bool HasGameOver { get; private set; }

    [Header("")]
    [SerializeField] private GameObject _window;//Объект диалогового окна
    private DialogWindow _dialogWindow;

    private void Start()
    {
        _lesson = GetComponent<Lesson>();
        _colliderZone = transform.GetChild(0).GetComponent<StudentPlace>();
        //_player = GameObject.FindGameObjectWithTag("Player");
        _dialogWindow = _window.GetComponent<DialogWindow>();
    }

    private void StartDialog(string name, Queue<string> phrases)
    {
        _window.SetActive(true);
        _dialogWindow.SetNameAndMono(name, phrases);
    }

    private void StopDialog()
    {
        //_dialogWindow.SetNameAndMono("", new Queue<string>());
        _window.SetActive(false);
    }

    //Запустить диалог, который будет срабатывать один раз и больше не проигрываться
    private void PlayDialogOnce(List<string> PhrasesLst)
    {
        if (PhrasesLst.Count > 0)
        {
            Queue<string> phrases = new Queue<string>(PhrasesLst);
            StartDialog(phrases.Dequeue(), new Queue<string>(phrases));
            PhrasesLst.Clear();
        }
    }

    //Запустить многоповторяемый диалог
    private void PlayDialog(List<string> PhrasesLst)
    {
        Queue<string> phrases = new Queue<string>(PhrasesLst);
        StartDialog(phrases.Dequeue(), phrases);
    }

    private void GameOver()
    {
        if (!_window.activeSelf)
        {
            _gameOverWarning.SetActive(true);
            HasGameOver = true;
        }
    }

    //Метод для включения "маячков" - куда игроку идти
    private void TrySetTarget(GameObject target)
    {
        if (!target.activeSelf)
        {
            target.SetActive(true);
        }
    }

    //Для выключения
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
        //Разговоры с NPC
        foreach (var npc in Students)
        {
            if (npc.HasEntered && Input.GetKeyDown(KeyCode.E) && !_window.activeSelf)
            {
                npc.transform.GetChild(0).gameObject.SetActive(false);
                PlayDialog(npc.Phrases);
            }
            if (npc.HasJustLeft)
            {
                StopDialog();
            }
        }

        if (!_lesson.LessonEnded)
        {
            //диалог,когда игрок пришёл на пару
            if (_lesson.HasCame && !_lesson.LessonStarted)
            {
                TrySetTarget(_targetToSit);
                TryUnsetTarget(_targetToCabinet);
                ChangeTask("Сядьте за свое место");
                PlayDialogOnce(CameAtLesson);
            }
            else
            {
                ChangeTask("Идите на матан");
            }
        }

        //Когда урок начался
        if(_lesson.LessonStarted && !_lesson.LessonEnded)
        {
            Debug.Log("Lesson");
            //диалог, когда игрок сел за парту
            if (!_lesson.enabled)
            {
                _lesson.enabled = true;
                if (_lesson.HasSat())
                {
                    TrySetTarget(_firstMostSmartest);
                    TrySetTarget(_secondMostSmartest);
                    TryUnsetTarget(_targetToSit);
                    PlayDialogOnce(SatDown);
                    _lesson.enabled = true;
                }
            }
            if (_lesson.LessonStarted)
            {
                ChangeTask("Спишите у самых умных учеников в классе");
            }

            if (_lesson.HasFind)
            {
                PlayDialog(Warning);
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
            ChangeTask("Выйдите из кабинета");
            if (!_lesson.IsMathWomanWait && !_lesson.HasFind) PlayDialog(EndOfLesson);
            else PlayDialog(BadEndOfLesson);
            _colliderZone.StandPlayerUp();
            _lesson.enabled = false;
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

        if (_lesson.LessonEnded)
        {
            if(_lesson.Points == 2)
            {
                PlayDialog(WellDoneWork);
            }
            if (_lesson.Points == 1)
            {
                PlayDialog(AverageWork);
            }
            if (_lesson.Points == 0)
            {
                PlayDialog(BadWork);
            }
        }
    }
}
