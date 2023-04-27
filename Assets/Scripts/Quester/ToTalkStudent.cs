using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTalkStudent : MonoBehaviour
{
    [SerializeField] public List<string> ToLesson;
    [SerializeField] public List<string> ToRacing;
    [SerializeField] public List<string> Choise;
    [SerializeField] public List<string> ToPlay;
    [SerializeField] public List<string> ToHome;

    [SerializeField] private Vector3 _racePosition;
    [SerializeField] private Vector3 _lessonPosition;
    [SerializeField] private Vector3 _waitPosition;

    public bool IsInRacingRoom { get; private set; }

    public bool HasEntered { get; private set; } //Зашёл ли игрок в область NPC
    public bool HasJustLeft { get; private set; } //Вышел ли игрок из области NPC некоторое время назад

    public bool IsTalking { get; set; }

    private void Start()
    {
        HasJustLeft = false;
        HasEntered = false;
    }

    private void NormalizeRotation()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void MoveToLessonPosition()
    {
        NormalizeRotation();
        IsInRacingRoom = false;
        transform.position = _lessonPosition;
    }

    public void MoveToRacePosition()
    {
        NormalizeRotation();
        IsInRacingRoom = true;
        transform.position = _racePosition;
    }

    public void MoveToWait()
    {
        NormalizeRotation();
        IsInRacingRoom = false;
        transform.position = _waitPosition;
    }

    IEnumerator LeftOffset()
    {
        yield return new WaitForSeconds(0.01f);
        if (!HasEntered)
        {
            HasJustLeft = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HasEntered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HasEntered = false;
            HasJustLeft = true;
            StartCoroutine(LeftOffset());
        }
    }
}