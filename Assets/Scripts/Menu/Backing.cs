using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backing : MonoBehaviour
{
    public static bool _place = false;
    [SerializeField] GameObject _Esc;
    [SerializeField] GameObject _startPanel;
    [SerializeField] GameObject _Set; 
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ComeBack()
    {
        if (_place)
        {
            _Esc.SetActive(true);
            _Set.SetActive(false);
        }
        else
        {
            _startPanel.SetActive(true);
            _Set.SetActive(false);
        }
    }
}
