using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool _IsPaused = false;

    public GameObject _PausePanel;
    public GameObject _GameMenu;
    public GameObject _startPanel;
    public GameObject _Set;
    public GameObject _Aim;
    public GameObject _Aim2;


    [SerializeField] GameObject _player;
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _carMain;
    [SerializeField] GameObject _car;

    AudioSource _audioCar;
    SoundDrive _scriptOnDrive;
    CarController _sciptCarEnabled;
    Animator _carAnim;

    camera _scriptCamera;
    AudioSource _stepAudio;

    // Update is called once per frame
    private void Start()
    {
        _audioCar = _carMain.GetComponent<AudioSource>();
        _carAnim = _car.GetComponent<Animator>();
        _sciptCarEnabled = _carMain.GetComponent<CarController>();
        _scriptOnDrive = _carMain.GetComponent<SoundDrive>();
        _scriptCamera = _mainCamera.GetComponent<camera>();
        _stepAudio = _player.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_IsPaused)
            {
                Resume(); 
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Cursor.visible = true;
        Time.timeScale = 0f;
        _stepAudio.enabled = false;
        _scriptCamera.enabled = false;
        _PausePanel.SetActive(true);
        _audioCar.enabled = false;
        _IsPaused = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        _stepAudio.enabled = true;
        _PausePanel.SetActive(false);
        _Set.SetActive(false);
        _scriptCamera.enabled = true;
        _IsPaused = false;
    }

    public void ScreenOn()
    {
        _Set.SetActive(true);
        _PausePanel.SetActive(false);
    }


    public void Exit()
    {
        Time.timeScale = 0f;
        _mainCamera.transform.position = new Vector3(-181.9337f, 16.95828f, -59.90916f);
        _mainCamera.transform.rotation = Quaternion.Euler(6.052f, 0.134f, 0.024f);
        _startPanel.SetActive(true);
        _IsPaused = false;
        _Aim.SetActive(false);
        _Aim2.SetActive(false);
        Backing._place = false;
        _GameMenu.SetActive(false);
    }
}
