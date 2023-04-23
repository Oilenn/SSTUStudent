using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

//using NamesAndTags;

public class MainMenu2 : MonoBehaviour
{
    [Header("Части главного меню")]
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _graphics;
    [SerializeField] private GameObject _sound;
    [SerializeField] private GameObject _conrtols;

    [Header("Объекты для имени")]
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private TMP_Text _warningText;
    private static string _warning = "Никнейм игрока введен неккоректно.\nВведите имя без пробелов.";
    public string Name = " ";

    public int[,] Resolutions =
    {
        {1024, 768},
        {1280, 720},
        {1920, 1080},
        {2560, 1440},
        {3840, 2160}
    };

    private void Update()
    {
        print(PlayerPrefs.GetString("Name"));
    }

    private void Start()
    {
        //
    }

    //Метод для деактивации всех объектов главного меню, за исключением аргумента.
    private void UnactiveAll(GameObject MenuEl)
    {
        MenuEl.SetActive(true);
        string ElTag = MenuEl.tag;

        int ChildsCount = transform.childCount;

        for (int i = 0; i < ChildsCount; i++)
        {
            GameObject cur = transform.GetChild(i).gameObject;

            if (cur.activeSelf && !cur.CompareTag(ElTag))
            {
                cur.SetActive(false);
            }
        }
    }

    //Имя

    public void InsertName()
    {
        Name = _inputField.text;
        SetWrong();
    }

    //Метод для проверки наличия запрещенных символов в имени
    public bool IsCorrect(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == ' ') return false;
        }
        return true;
    }

    //Метод для проверки заполненности текста имени
    public bool IsInputFull(string text)
    {
        if (text.Length == 0) return false;

        return true;
    }

    //Метод для установки текста-предупреждения о наличии пробелов в тексте
    public void SetWrong()
    {
        if (!IsCorrect(_inputField.text))
        {
            _warningText.text = _warning;
        }
        else
        {
            _warningText.text = "";
        }
    }

    //Метод для установки имени в PlayerPrefs
    public void TrySetName()
    {
        //Проверяем - заполнен ли инпут
        if (IsInputFull(_inputField.text))
        {
            PlayerPrefs.SetString("Name", Name);
            BackToMain();
        }
    }

    //Главное меню
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenSettings()
    {
        UnactiveAll(_settings);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMain()
    {
        UnactiveAll(_mainMenu);
        _mainMenu.GetComponent<Animator>().Play("Menu.FromRight");
    }

    //Меню настроек

    public void OpenGraphics()
    {
        UnactiveAll(_graphics);
    }

    public void OpenSound()
    {
        UnactiveAll(_sound);
    }

    public void OpenControls()
    {
        UnactiveAll(_conrtols);
    }

    public void BackToSettings()
    {
        UnactiveAll(_settings);
    }
    //Графика

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

    //Экран
    public void SetResolution(TMP_Dropdown dropdown)
    {
        Screen.SetResolution(Resolutions[dropdown.value, 0], Resolutions[dropdown.value, 1], true);
        print(Screen.currentResolution);
    }

    public void SetScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
        PlayerPrefs.SetInt("FullScreen", Convert.ToInt32(Screen.fullScreen));
    }

    //Звуки и музыка
    public void SetMusic()
    {

    }
}
