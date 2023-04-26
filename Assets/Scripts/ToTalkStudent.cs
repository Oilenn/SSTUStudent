using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTalkStudent : MonoBehaviour
{
    [SerializeField] private Lesson _les;
    [SerializeField] public List<string> Phrases;
    [SerializeField] public List<string> Choise;

    [SerializeField] private List<Vector3> _transforms;

    public bool HasEntered { get; private set; } //Зашёл ли игрок в область NPC
    public bool HasJustLeft { get; private set; } //Вышел ли игрок из области NPC некоторое время назад

    public bool IsTalking { get; set; }

    private void Start()
    {
        HasJustLeft = false;
        HasEntered = false;
    }

    private void MakeChoice()
    {

    }

    private void Update()
    {
        if (!_les.enabled)
        {

        }
    }

    public void MoveToNextPosition()
    {
        transform.position = _transforms[0];
        _transforms.Remove(_transforms[0]);
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