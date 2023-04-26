using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToTalkStudent : MonoBehaviour
{
    [SerializeField] public List<string> Phrases;

    [SerializeField] private List<Vector3> _transforms;
    public bool HasEntered { get; private set; } //����� �� ����� � ������� NPC
    public bool HasJustLeft { get; private set; } //����� �� ����� �� ������� NPC ��������� ����� �����

    public bool IsTalking { get; set; }

    private void Start()
    {
        HasJustLeft = false;
        HasEntered = false;
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