using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonStarter : MonoBehaviour
{
    private Lesson ActiveQuest;

    private void OnDestroy()
    {
        ActiveQuest.StartLesson();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        ActiveQuest = transform.parent.gameObject.GetComponent<Lesson>();
        ActiveQuest.enabled = false;
    }

    void Update()
    {
        
    }
}
