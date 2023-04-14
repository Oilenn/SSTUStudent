using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogWindow : MonoBehaviour
{
    [SerializeField]private TMP_Text _character;
    [SerializeField]private TMP_Text _monologue;

    public string CharacterName;
    public Queue<string> Phrases = new Queue<string>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Phrases.Count <= 0) gameObject.SetActive(false);
            else PutNextPharse();
        }
    }

    private void PutNextPharse()
    {
        _character.text = CharacterName;
        _monologue.text = Phrases.Dequeue();
    }

    public void SetNameAndMono(string name, Queue<string> mono)
    {
        print(CharacterName);
        CharacterName = name;
        Phrases = mono;
        _character.text = CharacterName;
        _monologue.text = Phrases.Dequeue();
    }

    private void OnDisable()
    {
        CharacterName = "";
        Phrases = null;
    }
}
