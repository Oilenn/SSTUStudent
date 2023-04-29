using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenDoors : MonoBehaviour
{
    [SerializeField] GameObject _fourtRep;
    [SerializeField] GameObject _npcRep;
    [SerializeField] GameObject _raceDoor;
    [SerializeField] GameObject _lessonDoor;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _npcRep.SetActive(false);
            _fourtRep.SetActive(true);
        }
    }
}
