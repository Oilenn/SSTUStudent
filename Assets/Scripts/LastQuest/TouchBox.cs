using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBox : MonoBehaviour
{
    public GameObject _doorLeft;
    public GameObject _doorRight;
    public GameObject _enterDoor;

    [SerializeField] GameObject _teacher;
    [SerializeField] GameObject _wordSupport;
    [SerializeField] GameObject _betweenDoors;

    [SerializeField] ToQuest _toQuest;

    Animator _animTeach;

    // Start is called before the first frame update
    void Start()
    {
        _animTeach = _teacher.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _betweenDoors.SetActive(true);
        _wordSupport.SetActive(false);
        _animTeach.enabled = true;
        _doorLeft.transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        _doorRight.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        _enterDoor.transform.rotation = Quaternion.Euler(0f,0f,0f);
        gameObject.SetActive(false);
        _toQuest.enabled = false;
    }
}
