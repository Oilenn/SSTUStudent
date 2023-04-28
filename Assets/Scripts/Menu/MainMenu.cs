using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator _animCamera;
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _gameCamera;
    [SerializeField] GameObject _carMain;
    [SerializeField] GameObject _car;
    [SerializeField] Pause _pause;

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

    AudioSource _audioCar;
    SoundDrive _scriptOnDrive;
    CarController _sciptCarEnabled;
    Animator _carAnim;

    AudioSource _steps;
    camera _cameraScript;


    private void Start()
    {
        _audioCar = _carMain.GetComponent<AudioSource>();
        _scriptOnDrive = _carMain.GetComponent<SoundDrive>();
        _carAnim = _car.GetComponent<Animator>();
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
            if (Pause._InGame)
            {
                _pause.ResumeGameTable();
                _MainMenu.SetActive(false);
                _GameMenu.SetActive(true);
                _mainCamera.SetActive(false);
                _gameCamera.SetActive(true);
                /*_audioCar.enabled = true;
                _scriptOnDrive.enabled = true;
                _carAnim.enabled = true;*/
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

}
