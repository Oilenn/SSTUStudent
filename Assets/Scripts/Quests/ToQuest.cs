using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToQuest : MonoBehaviour
{
    [SerializeField] private LessonOut _colliderOut;

    [Header("StudentToTalk")]
    [SerializeField] private GameObject _nikitaTarget;
    [SerializeField] private ToTalkStudent _nikita;

    [Header("UI elements")]
    [SerializeField] private TMP_Text _task;
    [SerializeField] private Animator _fade;
    [SerializeField] private GameObject _window;//Объект диалогового окна
    [SerializeField] private DialogManager _dialogManager;

    private float _fadeTime;

    public bool IsLessonFinished { get; private set; }
    public bool IsRacingFinished { get; private set; }

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

    private void Update()
    {
        if (_colliderOut.HasPlayerOut)
        {
            _nikitaTarget.SetActive(true);
            ChangeTask("Поговорите с Никитой");
            if (_nikita.IsTalking && !_window.activeSelf)
            {
                _fade.gameObject.SetActive(true);
                _fade.Play("FadeAnimation");
                _fade.SetBool("IsPlaying", true);
                _nikita.IsTalking = false;
                StartCoroutine(AnimationTimer());
            }
            else if (!_fade.GetBool("IsPlaying") && !_fade.gameObject.activeSelf)
            {
                _fade.gameObject.SetActive(false);
                //Поставить следующий квест//
            }
            if (Input.GetKeyDown(KeyCode.E) && _nikita.HasEntered && !_window.activeSelf)
            {
                print("E" + _nikita.HasEntered.ToString());
                _dialogManager.PlayDialogOnce(_nikita.Phrases);
                _nikita.IsTalking = true;
            }
        }

        if(_fadeTime >= 1)
        {
            _nikita.MoveToNextPosition();
            StopCoroutine(AnimationTimer());
        }
    }
}
