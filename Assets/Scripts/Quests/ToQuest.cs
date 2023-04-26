using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToQuest : MonoBehaviour
{
    //Скрипт для перехода от одного квеста к другому

    [SerializeField] private LessonOut _colliderOut;
    [SerializeField] private LessonOut _colliderRacingOut;

    [Header("Student to talk & make choice")]
    [SerializeField] private GameObject _nikitaTarget;
    [SerializeField] private ToTalkStudent _nikita;

    [Header("UI elements")]
    [SerializeField] private TMP_Text _task;
    [SerializeField] private Animator _fade;
    [SerializeField] private GameObject _window;//Объект диалогового окна
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private Choice _choice;

    [Header("Doors for quests")]
    [SerializeField] private GameObject _lessonDoor;
    [SerializeField] private GameObject _racingDoor;

    private float _fadeTime;

    public bool IsLessonFinished { get; private set; }
    public bool IsRacingFinished { get; private set; }
    public bool IsChoiceSetting { get; private set; }

    IEnumerator AnimationTimer()
    {
        _fadeTime += 0.1f;
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(AnimationTimer());
    }

    private void ChangeTask(string text)
    {
        _task.text = text;
    }

    public void FinishLesson()
    {
        IsLessonFinished = true;
    }

    public void FinishRacing()
    {
        IsRacingFinished = true;
    }

    public void MakeChoice()
    {
        _choice.gameObject.SetActive(true);

        if (_choice.HasChoiceDone)
        {
            if (_choice.IsComingToRacing)
            {
                _lessonDoor.SetActive(true);
                IsChoiceSetting = false;
            }
            else
            {
                _racingDoor.SetActive(true);
                IsChoiceSetting = false;
            }
        }
    }

    private void Update()
    {
        //Пока Никита не договорил - не даём игроку выбрать
        if (!IsLessonFinished && !IsRacingFinished)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!_nikita.IsTalking && !_dialogManager.gameObject.activeSelf)
                {
                    _dialogManager.PlayDialog(_nikita.Choise);
                }
                else
                {
                    MakeChoice();
                }
            }
        }

        if (!IsLessonFinished && !IsRacingFinished)
        {
            if (Input.GetKeyDown(KeyCode.E) && _nikita.HasEntered && !_window.activeSelf)
            {
                _dialogManager.PlayDialogOnce(_nikita.ToLesson);
                _nikita.IsTalking = true;
            }
        }

        if(IsLessonFinished && !_lessonDoor.activeSelf)
        {
            _lessonDoor.SetActive(true);
        }

        if (IsRacingFinished && !_racingDoor.activeSelf)
        {
            _lessonDoor.SetActive(true);
        }

        //Когда игрок вышел из комнаты матеши
        if (_colliderOut.HasPlayerOut && IsLessonFinished)
        {
            _nikitaTarget.SetActive(true);
            ChangeTask("Поговорите с Никитой");

            //При окончании диалога
            if (_nikita.IsTalking && !_window.activeSelf)
            {
                _nikita.IsTalking = false;
                _fade.gameObject.SetActive(true);
                _fade.Play("FadeAnimation");
                _fade.SetBool("IsPlaying", true);
                StartCoroutine(AnimationTimer());
            }

            //Когда затемнение экрана прошло
            else if (!_fade.GetBool("IsPlaying") && !_fade.gameObject.activeSelf)
            {
                _fade.gameObject.SetActive(false);
            }

            //При запуске диалога с Никитой
            if (Input.GetKeyDown(KeyCode.E) && _nikita.HasEntered && !_window.activeSelf)
            {
                _dialogManager.PlayDialogOnce(_nikita.ToLesson);
                _nikita.IsTalking = true;
            }
        }

        //Когда игрок вышел из 107-й
        if (_colliderRacingOut && !IsLessonFinished)
        {
            _lessonDoor.SetActive(true);
        }
        if(_fadeTime >= 1)
        {
            _nikita.MoveToNextPosition();
            StopCoroutine(AnimationTimer());
        }
    }
}
