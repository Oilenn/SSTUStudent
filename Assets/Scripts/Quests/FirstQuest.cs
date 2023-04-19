using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : MonoBehaviour
{
    [Header("Phrases. The first element must to be name of a character.")]
    [SerializeField] private List<string> MathWoman = new List<string>();
    [SerializeField] private List<string> Nikita = new List<string>();
    [SerializeField] private GameObject _workPaper;
    [SerializeField] private GameObject _player;

    private Transform _colliderZone;
    private bool _hasWorkOpened;

    [Header("")]
    [SerializeField] private GameObject _window;
    private DialogWindow _dialogWindow;

    private void Start()
    {
        _colliderZone = transform.GetChild(0);
        //_player = GameObject.FindGameObjectWithTag("Player");
        _dialogWindow = _window.GetComponent<DialogWindow>();
    }

    private void StartDialog(string name, Queue<string> phrases)
    {
        _window.SetActive(true);
        _dialogWindow.SetNameAndMono(name, phrases);
    }

    private void Update()
    {
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

            if (Input.GetKeyDown(KeyCode.E) && !_window.activeSelf)
            {
                Queue<string> phrases = new Queue<string>(MathWoman);
                //Первый элемент в очереди - имя персонажа, с кем будет вестись диалог.
                StartDialog(phrases.Dequeue(), phrases);
            }
        }
    }
