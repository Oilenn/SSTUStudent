using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentWork : MonoBehaviour
{
    [SerializeField] private Lesson _les;

    public void EndWork()
    {
        _les.EndLesson();
        gameObject.SetActive(false);
    }
}
