using UnityEngine;

public class Screens : MonoBehaviour
{

    public GameObject _Set;
    public GameObject _PausePanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

    public void ScreenOn()
    {
        _Set.SetActive(true);
        _PausePanel.SetActive(false);
    }

    public void Back()
    {
        _Set.SetActive(false);
        _PausePanel.SetActive(true);
    }


}
