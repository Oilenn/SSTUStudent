using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsSetter : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _graphics;
    [SerializeField] private TMP_Dropdown _resolution;
    [SerializeField] private Toggle _isFullscreen;

    public int[,] Resolutions =
    {
        {1920, 1080},
        {1280, 720},
        {2560, 1440},
        {3840, 2160}
    };

    public void ChangeFullscreen()
    {
        Screen.fullScreen = _isFullscreen.isOn;
        //Debug.Log(_isFullscreen.isOn);
    }

    public void SetResolution(TMP_Dropdown dropdown)
    {
        Screen.SetResolution(Resolutions[dropdown.value, 0], Resolutions[dropdown.value, 1], true);
        //print(Screen.currentResolution);
    }

    public void SetGraphicSettings(TMP_Dropdown dropdown)
    {
        if (dropdown.captionText.text == "Очень высокие") VeryHigh();
        if (dropdown.captionText.text == "Высокие") High();
        if (dropdown.captionText.text == "Средние") Medium();
        if (dropdown.captionText.text == "Низкие") Low();
        print(QualitySettings.GetQualityLevel());
    }

    public void VeryHigh()
    {
        QualitySettings.SetQualityLevel(4);
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(3);
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(2);
    }

    public void Low()
    {
        QualitySettings.SetQualityLevel(1);
    }
}
