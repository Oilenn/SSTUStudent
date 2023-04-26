using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveTeacher : MonoBehaviour
{
    [Header ("Doors")]
    [SerializeField] GameObject _door;
    [SerializeField] GameObject _lastDoor;
    [SerializeField] GameObject _lastDoor1;
    [SerializeField] GameObject _leftDoor;
    [SerializeField] GameObject _rightDoor;

    [Header ("NPC Replic")]
    [SerializeField] GameObject _firstRep;
    [SerializeField] GameObject _secondRep;
    [SerializeField] GameObject _thirdRep;
    [SerializeField] GameObject _forthRep;
    [SerializeField] GameObject _fifthRep;
    [SerializeField] GameObject _sixthRep;

    [Header("Player Replic")]
    [SerializeField] GameObject _MyFirstRep;
    [SerializeField] GameObject _MySecRep;
    [SerializeField] GameObject _MyThirdRep;
    [SerializeField] GameObject _MyFourthRep;

    TMP_Text _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = _firstRep.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void DoorOn()
    {
        _door.SetActive(true);
    }

    void DoorOff()
    {
        _door.SetActive(false);
    }

    void Speak1()
    {
        _firstRep.SetActive(true);
        _text.text = "постой!";
    }

    void Speak2()
    {
        _firstRep.SetActive(false);
        _secondRep.SetActive(true);
    }

    void Speak3()
    {
        _MyFirstRep.SetActive(false);
        _thirdRep.SetActive(true);
    }

    void Speak4()
    {
        _MySecRep.SetActive(false);
        _forthRep.SetActive(true);
    }

    void Speak5()
    {
        _MyThirdRep.SetActive(false);
        _fifthRep.SetActive(true);
    }

    void Speak6()
    {
        _MyFourthRep.SetActive(false);
        _sixthRep.SetActive(true);
    }

    void MySpeak1()
    {
        _secondRep.SetActive(false);
        _MyFirstRep.SetActive(true);
    }

    void MySpeak2()
    {
        _thirdRep.SetActive(false);
        _MySecRep.SetActive(true);
    }

    void MySpeak3()
    {
        _forthRep.SetActive(false);
        _MyThirdRep.SetActive(true);
        _leftDoor.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        _rightDoor.transform.rotation = Quaternion.Euler(0f,0f,0f);
        _lastDoor.transform.rotation = Quaternion.Euler(0f, -180f, 0f);
        _lastDoor1.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

}
