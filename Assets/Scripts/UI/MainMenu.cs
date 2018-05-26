using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    GameObject m_mainMenuPanel;


    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += ToggleMenuPrincipal;
        GameManager.Instance.MainMenuEvent += ToggleMenuPrincipal;
    }

    void ToggleMenuPrincipal()
    {
        m_mainMenuPanel.SetActive(!m_mainMenuPanel.activeSelf);
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
