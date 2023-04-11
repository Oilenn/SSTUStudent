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
    [SerializeField] private GameObject _window;
    private DialogWindow _dialogWindow;
    //����� ��� ��������� ����������� ����.

    private void Start()
    {
        _dialogWindow = _window.GetComponent<DialogWindow>();
    }

    private void TurnOnWindow(string name, Queue<string> phrases)
    {
        _window.SetActive(true);
        _dialogWindow.SetNameAndMono(name, phrases);
    }
}
