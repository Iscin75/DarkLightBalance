﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	[SerializeField]
    GameObject m_PauseMenuPanel;
    bool isActive = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (!isActive)
            {
                isActive = true;
                GameManager.Instance.CallPauseMenu();
            }
            else
            {
                isActive = false;
                GameManager.Instance.CallContinueLevel();
            }
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.PauseMenuEvent += ToggleMenuPause;
        GameManager.Instance.ContinueLevelEvent += ToggleMenuPause;
    }

    private void OnDisable()
    {
        GameManager.Instance.PauseMenuEvent -= ToggleMenuPause;
        GameManager.Instance.ContinueLevelEvent -= ToggleMenuPause;
    }

    void ToggleMenuPause()
    {
        m_PauseMenuPanel.SetActive(!m_PauseMenuPanel.activeSelf);
    }
}