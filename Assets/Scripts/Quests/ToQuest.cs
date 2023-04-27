using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToQuest : MonoBehaviour
{
    //Скрипт для перехода от одного квеста к другому

    [SerializeField] private FirstQuest _firstQuest;

    [SerializeField] private GameObject _npc;

    [Header("Colliders")]
    [SerializeField] private LessonOut _colliderLessonOut;
    [SerializeField] private LessonOut _colliderRacingOut;
    //[SerializeField] private 

    [Header("Student to talk & make choice")]
    [SerializeField] private GameObject _nikitaTarget;
    [SerializeField] private ToTalkStudent _nikita;

    [Header("UI elements")]
    [SerializeField] private TMP_Text _task;
    [SerializeField] private Animator _fade;
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private Choice _choice;

    [Header("Doors for quests")]
    [SerializeField] private GameObject _lessonDoor;
    [SerializeField] private GameObject _racingDoor;

    [SerializeField] private GameObject _raceStarter;
    [SerializeField] private GameObject _runStarter;
    [SerializeField] private GameObject _raceExiter;
    private float _fadeTime = 0;

    public bool IsLessonFinished { get; private set; }
    public bool IsRacingFinished { get; private set; }
    public bool IsChoiceSetting { get; private set; }
    public bool IsRunStarted { get; private set; }
    public bool IsRaceEnded { get; set; }

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
        Cursor.visible = true;
        if (_choice.HasChoiceDone)
        {
            Cursor.visible = false;
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
            _fade.gameObject.SetActive(true);
            Fade();
        }
    }

    private void Fade()
    {
        _fade.Play("FadeAnimation");
        _fade.SetBool("IsPlaying", true);
        StartCoroutine(AnimationTimer());
    }

    private void StopFade()
    {
        //_fade.SetBool("IsPlaying", false);
        _fadeTime = 0;
        StopAllCoroutines();
        _fade.gameObject.SetActive(false);
    }

    private void ComeToRace()
    {
        _lessonDoor.SetActive(true);
        _racingDoor.SetActive(false);
        if (!IsLessonFinished || !IsRaceEnded)
        {
            _nikita.MoveToRacePosition();
        }
    }

    private void ComeToLesson()
    {
        _lessonDoor.SetActive(false);
        _firstQuest.enabled = true;
        if (!IsLessonFinished || !IsRaceEnded)
        {
            _nikita.MoveToLessonPosition();
        }
    }

    private void PlayFadedDialog(List<string> phrases)
    {
        if (!_dialogManager.IsWindowOn())
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _dialogManager.PlayDialogOnce(phrases);
                _nikita.IsTalking = true;
            }
            else if (_nikita.IsTalking)
            {
                print("Faded");
                _fade.gameObject.SetActive(true);
                Fade();
                _nikita.IsTalking = false;
            }
        }
    }

    private void Update()
    {
        if (_fadeTime >= 1f && _fadeTime <= 1.11f)
        {
            _nikitaTarget.SetActive(false);
            //Игрок только начал игру
            if (!IsLessonFinished && !IsRacingFinished)
            {
                if (_choice.IsComingToRacing)
                {
                    ComeToRace();
                }
                else
                {
                    ComeToLesson();
                }
            }
            //Игрок закончил квест с гонкой
            else if (!IsLessonFinished)
            {
                ComeToLesson();
            }
            //Игрок закончил квест с парой
            else if (!IsRacingFinished)
            {
                ComeToRace();
            }
            if(_npc.activeSelf)_npc.SetActive(false);//Отключаем всех Npc
        }
        else if (_fadeTime >= 2.2f)
        {
            StopFade();
        }

        if (IsRaceEnded && !IsRacingFinished)
        {
            ChangeTask("Поговорите с Никитой");
            IsRacingFinished = true;
        }

        if(IsRaceEnded && IsLessonFinished)
        {
            _runStarter.SetActive(true);
        }
        if (IsRaceEnded)
        {
            _raceStarter.SetActive(false);
        }

        if (_nikita.HasEntered)
        {
            if (IsRaceEnded && _nikita.IsInRacingRoom)
            {
                if (IsLessonFinished)
                {
                    PlayFadedDialog(_nikita.ToHome);
                    _raceExiter.SetActive(true);
                }
                else
                {
                    PlayFadedDialog(_nikita.ToLesson);
                    _raceExiter.SetActive(true);
                }
            }
            else if (IsLessonFinished)
            {
                if (!_nikita.IsInRacingRoom)
                {
                    PlayFadedDialog(_nikita.ToRacing);
                }
                else
                {
                    if (!_dialogManager.IsWindowOn())
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _dialogManager.PlayDialogOnce(_nikita.ToPlay);
                            _nikita.IsTalking = true;
                        }
                        else if (_nikita.IsTalking && !IsRaceEnded)
                        {
                            _nikita.IsTalking = false;
                            _raceStarter.SetActive(true);
                            ChangeTask("Встаньте за доску и начните играть.");
                        }
                    }
                }
            }
            //Когда игрок только зашёл в игру
            else if (!IsLessonFinished && !IsRacingFinished)
            {
                if (_nikita.IsInRacingRoom)
                {
                    if (!_dialogManager.IsWindowOn())
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            _dialogManager.PlayDialogOnce(_nikita.ToPlay);
                            _nikita.IsTalking = true;
                        }
                        else if (_nikita.IsTalking && !IsRaceEnded)
                        {
                            ChangeTask("Встаньте за доску и начните играть.");
                            _raceStarter.SetActive(true);
                            _nikita.IsTalking = false;
                        }
                    }
                }

                if (!_dialogManager.IsWindowOn())
                {
                    //При нажатии запускаем диалог
                    if (Input.GetKeyDown(KeyCode.E) && !IsChoiceSetting)
                    {
                        _dialogManager.PlayDialogOnce(_nikita.Choise);
                        _nikita.IsTalking = true;
                    }
                    //Когда диалог завершен - даём игроку выбор
                    else if (_nikita.IsTalking || IsChoiceSetting)
                    {
                        IsChoiceSetting = true;
                        _nikita.IsTalking = false;
                        _choice.gameObject.SetActive(true);
                    }
                }
            }
        
        }

        if (_choice.gameObject.activeSelf)
        {
            MakeChoice();
        }

        if (_choice.HasChoiceDone)
        {
            _choice.gameObject.SetActive(false);
        }

        if (_colliderLessonOut.HasPlayerOut && !IsLessonFinished)
        {
            if (!IsRaceEnded)
            {
                ChangeTask("Поговорите с Никитой");
                IsLessonFinished = true;
            }
            else
            {
                ChangeTask("");
                IsLessonFinished = true;
            }
        }
    }
}
