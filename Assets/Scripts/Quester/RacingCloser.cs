using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingCloser : MonoBehaviour
{
    [SerializeField] GameObject _door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _door.transform.rotation = Quaternion.Euler(0, 0, 0);
            Destroy(gameObject);
        }
    }
}
