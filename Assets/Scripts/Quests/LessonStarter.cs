using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonStarter : MonoBehaviour
{
    [SerializeField] private GameObject _lessonDoor;

    private Lesson ActiveQuest;

    private void OnDestroy()
    {
        ActiveQuest.PlayerCame();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _lessonDoor.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        ActiveQuest = transform.parent.gameObject.GetComponent<Lesson>();
        ActiveQuest.enabled = false;
    }
}
