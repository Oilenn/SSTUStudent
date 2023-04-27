using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentsTalker : MonoBehaviour
{
    [Header("NPCs to talk")]
    [SerializeField] private List<NPC> Students = new List<NPC>();//������ ���� ���������, � �������� ����� ����������
    [SerializeField] private DialogManager _dialogManager;
    void Update()
    {
        //��������� � NPC
        foreach (var npc in Students)
        {
            if (npc.HasEntered && Input.GetKeyDown(KeyCode.E) && !_dialogManager.IsWindowOn())
            {
                npc.transform.GetChild(0).gameObject.SetActive(false);
                _dialogManager.PlayDialog(npc.Phrases);
            }
            if (npc.HasJustLeft)
            {
                _dialogManager.StopDialog();
            }
        }
    }
}
