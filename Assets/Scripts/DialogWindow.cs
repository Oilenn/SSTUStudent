using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogWindow : MonoBehaviour
{
    [SerializeField]private TMP_Text _character;//Имя персонажа
    [SerializeField]private TMP_Text _monologue;//Монолог персонажа

    public string CharacterName;
    public Queue<string> Phrases = new Queue<string>();//Фразы монолога персонажа


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

    //Установка имени и фраз монолога
    public void SetNameAndMono(string name, Queue<string> mono)
    {
        print(CharacterName);
        CharacterName = name;
        Phrases = mono;
        _character.text = CharacterName;
        _monologue.text = Phrases.Dequeue();
    }

    //Обнуляем значения при отсутствии фраз
    private void OnDisable()
    {
        CharacterName = "";
        Phrases = null;
    }
}
