using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] public List<string> Phrases;
    public bool HasEntered { get; private set; } //Зашёл ли игрок в область NPC
    public bool HasJustLeft { get; private set; } //Вышел ли игрок из области NPC некоторое время назад

    private void Start()
    {
        HasJustLeft = false;
        HasEntered = false;
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
