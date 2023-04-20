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

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(_les.HasCame) HasExit = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!_les.HasCame) _les.PlayerCame();
            else HasExit = false;
        }
    }
}
