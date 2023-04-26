using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToQuestTransition : MonoBehaviour
{
    [SerializeField] private GameObject _fade;

    private GameObject _currentQuest;

    

    private void Start()
    {
        _currentQuest = transform.parent.gameObject;
    }
}
