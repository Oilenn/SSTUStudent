using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson : MonoBehaviour
{
    [SerializeField] private MathWoman _mathWoman;

    private StudentPlace _colliderZone;

    public bool LessonStarted { get; private set; }//������ �� ����� 
    public bool HasCame { get; private set; }//������ �� ����� � �������
    public bool HasFind = false;//��� �� ����� ������ ������������

    public void StartLesson()
    {
        LessonStarted = true;
    }

    public void PlayerCame()
    {
        HasCame = true;
    }

    private void Start()
    {
        //�� ������������ �������, StudentPlace - ������ �������� �������
        _colliderZone = transform.GetChild(0).GetComponent<StudentPlace>();
    }

    private void Update()
    {
        //Debug.Log(_colliderZone.HasExit);
        //Debug.Log(_mathWoman.IsLooking);
        if (LessonStarted)
        {
            if (_colliderZone.HasExit && _mathWoman.IsLooking)
            {
                HasFind = true;
            }

            if (HasFind)
            {
                Debug.Log("Found");
            }
        }
    }
}
