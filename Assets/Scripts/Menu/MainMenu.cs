using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator _animCamera;

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

    public void StartGame()
    {
        _MainMenu.SetActive(false);

        _animCamera.enabled = true;
        _animCamera.Play("MoveToPlayer");

    }

}
