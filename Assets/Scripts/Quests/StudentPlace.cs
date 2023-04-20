using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentPlace : MonoBehaviour
{
    [SerializeField] MathWoman _mathWoman;
    private Lesson _les;
    public bool HasExit { get; private set; }

    private void Start()
    {
        _les = transform.parent.GetComponent<Lesson>();
    }

    //Игрок отходит от стола
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_les.LessonStarted) HasExit = true;
        }
    }

    //Игрок садится за своё место
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_les.LessonStarted) _les.StartLesson();
            else HasExit = false;
        }
    }
}
