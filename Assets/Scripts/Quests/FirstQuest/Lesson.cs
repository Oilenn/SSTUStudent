using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lesson : MonoBehaviour
{
    [SerializeField] private MathWoman _mathWoman;

    [SerializeField] private TMP_Text _seconds;
    private int _secondsToSit;

    private StudentPlace _colliderZone;

    public bool LessonStarted { get; private set; }//������ �� ����� 
    public bool HasCame { get; private set; }//������ �� ����� � �������
    public bool HasFind = false;//��� �� ����� ������ ������������
    public bool IsStaring;

    IEnumerator TimerToSit()
    {
        _secondsToSit--;
        _seconds.text = "��������� �� ��� �����!\n" + _secondsToSit.ToString();
        yield return new WaitForSeconds(1);
        StartCoroutine(TimerToSit());
    }

    public void StartLesson()
    {
        LessonStarted = true;
    }

    public void PlayerCame()
    {
        HasCame = true;
    }

    public void PlayerSat()
    {
        HasFind = false;
    }

    private void Start()
    {
        //�� ������������ �������, StudentPlace - ������ �������� �������
        _colliderZone = transform.GetChild(0).GetComponent<StudentPlace>();
    }

    private void LessonFail()
    {

    }

    private void Update()
    {
        //Debug.Log(_colliderZone.HasExit);
        //Debug.Log(_mathWoman.IsLooking);
        if (LessonStarted)
        {
            if (_colliderZone.HasExit && _mathWoman.IsLooking && !HasFind)
            {
                HasFind = true;
            }
            else if (!_colliderZone.HasExit)
            {
                HasFind = false;
                _secondsToSit = 7;
                StopCoroutine(TimerToSit());
            }

            if (HasFind && !IsStaring)
            {
                _seconds.gameObject.SetActive(true);
                StartCoroutine(TimerToSit());
                IsStaring = true;
            }

            if(_secondsToSit <= 0)
            {
                LessonFail();
            }

            if (HasFind)
            {
                Debug.Log("Found");
            }
        }
    }
}
