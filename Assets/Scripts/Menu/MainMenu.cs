using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _MainMenu;
    public GameObject _SetMenu;

    public void MainON()
    {
        _MainMenu.SetActive(true);
    }

    public void Settings()
    {
        _MainMenu.SetActive(false);
        _SetMenu.SetActive(true);
    }

    public void Back()
    {
        _MainMenu.SetActive(true);
        _SetMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
