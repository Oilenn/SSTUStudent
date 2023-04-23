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

    [SerializeField] GameObject _mainCamera;

    camera _scriptCamera;

    // Update is called once per frame
    private void Start()
    {
        _scriptCamera = _mainCamera.GetComponent<camera>();
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
        Time.timeScale = 0f;
        _scriptCamera.enabled = false;
        _PausePanel.SetActive(true);
        _IsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
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
        _GameMenu.SetActive(false);
        _mainCamera.transform.position = new Vector3(-181.9337f, 16.95828f, -59.90916f);
        _mainCamera.transform.rotation = Quaternion.Euler(6.052f, 0.134f, 0.024f);
        _startPanel.SetActive(true);
        _IsPaused = false;
    }
}
