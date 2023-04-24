using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lesson : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Toggle _firstAnswer;
    [SerializeField] private Toggle _secondAnswer;
    //[SerializeField] private 

    [Header("")]
    [SerializeField] private StudentPlace _colliderZone;
    [SerializeField] private MathWoman _mathWoman;
    [SerializeField] private GameObject _cabinetDoor;

    //Работы других студентов
    [Header("Students work")]
    [SerializeField] private GameObject _firstWork;
    [SerializeField] private GameObject _SecondWork;

    public bool LessonStarted { get; private set; }
    public bool LessonEnded { get; private set; }

    public bool HasCame { get; private set; }//Пришёл ли игрок в кабинет
    public bool HasFind = false;//Был ли игрок спален математичкой
    public bool IsMathWomanWait { get; private set; }

    public int Points { get; private set; }

    IEnumerator LessonTimer()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(LessonTimer());
    }

    IEnumerator WaitForSit()
    {
        yield return new WaitForSeconds(7);
        if (HasFind)
        {
            EndLesson();
        }
    }

    public void EndLesson()
    {
        if (_firstAnswer.isOn)
        {
            Points++;
        }
        if (_secondAnswer.isOn)
        {
            Points++;
        }
        Debug.Log("Lesson ended");
        LessonEnded = true;
        LessonStarted = false;
        _cabinetDoor.SetActive(false);
    }

    public void StartLesson()
    {
        LessonStarted = true;
        _firstWork.SetActive(true);
        _SecondWork.SetActive(true);
        _cabinetDoor.SetActive(true);
    }

    public void PlayerCame()
    {
        HasCame = true;
    }

    public bool HasSat()
    {
        return _colliderZone.HasSat;
    }

    private void Start()
    {
        //По стандартному префабу, StudentPlace - первый дочерний элемент
        _colliderZone = transform.GetChild(0).GetComponent<StudentPlace>();
        LessonEnded = false;
    }

    private void Update()
    {
        //Debug.Log(_colliderZone.HasExit);
        //Debug.Log(_mathWoman.IsLooking);
        //print(LessonStarted);

        if (LessonStarted && !LessonEnded)
        {
            if (HasFind && !IsMathWomanWait)
            {
                IsMathWomanWait = true;
                StartCoroutine(WaitForSit());
            }
            else if(!HasFind)
            {
                IsMathWomanWait = false;
                StopCoroutine(WaitForSit());
            }

            if (!_colliderZone.HasSat && !_mathWoman.IsLooking)
            {
                HasFind = true;
            }
            else if (_colliderZone.HasSat)
            {
                HasFind = false;
            }

            if (HasFind)
            {
                Debug.Log("Found");
            }
        }
    }
}
