using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogWindow : MonoBehaviour
{
    private TMP_Text _character;
    private TMP_Text _monologue;

    public string CharacterName;
    public Queue<string> Phrases = new Queue<string>();

    private void Update()
    {
        if (Phrases.Count <= 0) gameObject.SetActive(false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            PutNextPharse();
        }
    }

    private void PutNextPharse()
    {
        _character.text = CharacterName;
        _monologue.text = Phrases.Dequeue();
    }

    public void SetNameAndMono(string name, Queue<string> mono)
    {
        CharacterName = name;
        Phrases = mono;
    }
}
