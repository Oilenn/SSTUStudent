using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceDoorCloser : MonoBehaviour
{
    [SerializeField] GameObject _raceDoor;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Closedddd");
            _raceDoor.SetActive(false);
        }
    }
}
