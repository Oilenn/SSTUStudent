using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson : MonoBehaviour
{
    [SerializeField] private MathWoman _mathWoman;

    private GameObject[] _playerParts;
    private Coll _colliderZone;

    
    public bool HasFind = false;

    private void Start()
    {
        _playerParts = GameObject.FindGameObjectsWithTag("Player");
        _colliderZone = transform.GetChild(0).GetComponent<Coll>();
    }

    private void Update()
    {
        Debug.Log(_colliderZone.HasExit);
        Debug.Log(_mathWoman.IsLooking);
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
