using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuest : MonoBehaviour
{
    /*����� ���������� ����� ������� ������ �������. ��� ������� � ��������� ������� ����� ��������, ��� ����� �������� � ������������ ����. ������� ����� �������� ��������, ������� ����� ����� ������.
    �� ���������� ������: ����� �������� ��� ���������, � ������� ���������� ������.
    ������ ���������� ���� � �������.

    �� ���� � ������� ����� ����� ���������� �� ����������.
    ��������� ����� � ����� ����� ���:
    �����
    ���������
    ������
    ����

    �� ������� � �������, ����� ���� ��������� ����� �����, �� ��� ��� �� �����������. ������ ���������� ���� �� ����� � ������� ����� ���� ������� � ���������, ��������� ����� � �������� ����� ����������.
    ����� ���������� ��������� � ��� ������� � ��������, ����� ���� ��� ���������� ������.

    ������� ����� �������� �� ���� �� ���������� �������.
    */

    //������ ����������� ����.
    [Header("Phrases")]
    [SerializeField] private List<string> Andrey = new List<string>();
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
            Queue<string> phrases = new Queue<string>(Andrey);
            StartDialog("������", phrases);
        }
    }
}
