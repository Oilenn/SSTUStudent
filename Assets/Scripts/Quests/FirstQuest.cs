using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : MonoBehaviour
{
    [Header("Phrases. The first element must to be name of a character.")]
    [SerializeField] private List<string> MathWoman = new List<string>();
    [SerializeField] private List<string> Nikita = new List<string>();

    [Header("")]
    [SerializeField] private GameObject _window;
    private DialogWindow _dialogWindow;

    private void Start()
    {
        _dialogWindow = _window.GetComponent<DialogWindow>();
    }

    private void StartDialog(string name, Queue<string> phrases)
    {
        _window.SetActive(true);
        _dialogWindow.SetNameAndMono(name, phrases);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !_window.activeSelf)
        {
            Queue<string> phrases = new Queue<string>(MathWoman);
            //Первый элемент в очереди - имя персонажа, с кем будет вестись диалог.
            StartDialog(phrases.Dequeue(), phrases);
        }
    }
}