using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StudentWork : MonoBehaviour
{
    [SerializeField] private Lesson _les;
    [SerializeField] private Toggle _rightToggle1;
    [SerializeField] private Toggle _rightToggle2;
    [SerializeField] private GameObject _warningText;

    public void EndWork()
    {
        if (_rightToggle1.isOn && _rightToggle2.isOn)
        {
            _les.EndLesson();
            gameObject.SetActive(false);
        }
        else
        {
            _warningText.SetActive(true);
        }
    }

    private void OnDisable()
    {
        _warningText.SetActive(false);
    }
}
