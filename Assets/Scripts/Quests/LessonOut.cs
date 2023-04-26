using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonOut : MonoBehaviour
{
    public bool HasPlayerOut { get; private set; }
    [SerializeField] private GameObject _outAndIn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(HasPlayerOut);
            _outAndIn.SetActive(false);
            HasPlayerOut = true;
        }
    }
}
