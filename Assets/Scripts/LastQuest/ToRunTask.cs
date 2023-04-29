using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRunTask : MonoBehaviour
{
    //������ ���������� �� ������ ������
    [SerializeField] GameObject _runAudio;//������ ��� ������
    [SerializeField] GameObject _averageAudio;//������ ��� ������� �������� �� ���������
    [SerializeField] ToQuest _toQuest;//��� ����� ������

    private void OnEnable()
    {
        _runAudio.SetActive(true);
        _averageAudio.SetActive(false);
        _toQuest.ChangeTask("������ �� �������������!(L.Shift)");
    }
}
