using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson : MonoBehaviour
{
    [SerializeField] private MathWoman _mathWoman;

    private StudentPlace _colliderZone;

    private bool _lessonStarted;
    public bool HasCame { get; private set; }//Пришёл ли игрок 
    public bool HasFind = false;//Был ли игрок был спален математичкой

    public void StartLesson()
    {
        _lessonStarted = true;
    }

    public void PlayerCame()
    {
        HasCame = true;
    }

    private void Start()
    {
        _colliderZone = transform.GetChild(0).GetComponent<StudentPlace>();
    }

    private void Update()
    {
        //Debug.Log(_colliderZone.HasExit);
        //Debug.Log(_mathWoman.IsLooking);
        if (_lessonStarted)
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
