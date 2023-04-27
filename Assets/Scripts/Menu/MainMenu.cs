using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator _animCamera;

    public GameObject _MainMenu;
    public GameObject _SetMenu;
    public GameObject _GameMenu;
    public GameObject _Esc;
    public GameObject _player;
    public GameObject _Aim;
    public GameObject _Aim2;

    [Header ("For Start")]

    [SerializeField] GameObject _camera;

    int _countStart = 0;

    AudioSource _steps;
    camera _cameraScript;


    private void Start()
    {
        _cameraScript = _camera.GetComponent<camera>();
        _steps = _player.GetComponent<AudioSource>();
    }

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
        if (_countStart < 1)
        {

            _MainMenu.SetActive(false);

            _animCamera.enabled = true;
            _animCamera.Play("MoveToPlayer");
            _countStart++;
            Cursor.visible = false;

            Backing._place = true;
        }

        else
        {
            _Aim.SetActive(true);
            _Aim2.SetActive(true);
            _steps.enabled = true;
            _MainMenu.SetActive(false);
            _GameMenu.SetActive(true);
            _cameraScript.enabled = true;
            _Esc.SetActive(false);
            Time.timeScale = 1f;
            Backing._place = true;

            Cursor.visible = false;
        }
    }

}
