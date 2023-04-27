using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject _window;//Объект диалогового окна
    private DialogWindow _dialogWindow;

    private void Start()
    {
        _dialogWindow = _window.GetComponent<DialogWindow>();
    }

    public GameObject GetWindow()
    {
        return _window;
    }

    public bool IsWindowOn()
    {
        return _window.activeSelf;
    }

    private void StartDialog(string name, Queue<string> phrases)
    {
        _window.SetActive(true);
        _dialogWindow.SetNameAndMono(name, phrases);
    }

    public void StopDialog()
    {
        //_dialogWindow.SetNameAndMono("", new Queue<string>());
        _window.SetActive(false);
    }

    //Запустить диалог, который будет срабатывать один раз и больше не проигрываться
    public void PlayDialogOnce(List<string> PhrasesLst)
    {
        if (PhrasesLst.Count > 0)
        {
            Queue<string> phrases = new Queue<string>(PhrasesLst);
            StartDialog(phrases.Dequeue(), new Queue<string>(phrases));
            PhrasesLst.Clear();
        }
    }

    //Запустить многоповторяемый диалог
    public void PlayDialog(List<string> PhrasesLst)
    {
        Queue<string> phrases = new Queue<string>(PhrasesLst);
        StartDialog(phrases.Dequeue(), phrases);
    }

    public void PlayUnstopableDialog(float t = 3)
    {

    }
}
