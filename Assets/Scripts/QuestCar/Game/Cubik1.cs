using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cubik1 : MonoBehaviour
{
    public GameObject Cube;
    public GameObject _TextMesh;

    TMP_Text _text;
    int _Round;

    private void Start()
    {
        _text = _TextMesh.GetComponent<TMP_Text>();
        _Round = 1;
    }


    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
        {
            Debug.Log(1);
            _Round++;
            gameObject.SetActive(false);
            Cube.SetActive(true);
            Debug.Log(_text.text);
            _text.text = "Круг " + _Round.ToString() + "/2";
        }
    }
}
