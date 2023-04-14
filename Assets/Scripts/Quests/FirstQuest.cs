using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : MonoBehaviour
{
    /*Игрок появляется перед дверьми пятого корпуса. При подходе к турникету главный герой понимает, что забыл карточку и студенческий дома. Главный герой замечает студента, который стоит около дверей.
    Он предлагает сделку: игрок покупает ему энергетик, а студент пропускает игрока.
    Игроку приходится идти в магазин.

    По пути в магазин игрок может поговорить со студентами.
    Разговоры будут о таких темах как:
    Учеба
    Стипендия
    Музыка
    Игры

    По приходе в магазин, игрок ищет энергетик среди полок, но его там не оказывается. Игроку приходится идти на склад и рыскать среди кучи коробок и стеллажей, сложенных будто в лабиринт банку энергетика.
    Игрок оплачивает энергетик и идёт обратно к студенту, после чего тот пропускает игрока.

    Главный герой приходит на пару по математике вовремя.
    */

    //Объект диалогового окна.
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
