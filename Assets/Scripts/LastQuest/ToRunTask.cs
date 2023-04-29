using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToRunTask : MonoBehaviour
{
    //Скрипт отвечающий за начало погони
    [SerializeField] GameObject _runAudio;//Музыка для погони
    [SerializeField] GameObject _averageAudio;//Музыка при обычном хождении по институту
    [SerializeField] ToQuest _toQuest;//Для смены задачи

    private void OnEnable()
    {
        _runAudio.SetActive(true);
        _averageAudio.SetActive(false);
        _toQuest.ChangeTask("Бегите от преподавателя!(L.Shift)");
    }
}
