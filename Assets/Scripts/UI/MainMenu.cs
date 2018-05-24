using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    GameObject m_mainMenuPanel;


    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += StartGame;
    }

    private void OnDisable()
    {
        GameManager.Instance.StartGameEvent -= StartGame;
    }

    void StartGame()
    {
        m_mainMenuPanel.SetActive(false);
    }

    public void OnClickStartGame()
    {
        GameManager.Instance.CallStartGame();
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
