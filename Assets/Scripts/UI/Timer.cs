using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {


    #region Variables
    [SerializeField]
    Image m_Timer;
    [SerializeField]
    float m_PowerDuration = 300f;
    float m_timeLeft;
    bool isActive;
    #endregion


    private void Awake()
    {
        if (m_Timer == null)
            Debug.LogError("Merci d'assigner la barre de pouvoir au composant PowerBar dans l'Inspector");
    }

    private void Start()
    {
        m_timeLeft = m_PowerDuration;
    }

    private void OnEnable()
    {
        GameManager.Instance.LevelVictoryEvent += ResetTimer;
        GameManager.Instance.LooseToMainMenuEvent += ResetTimer;
        GameManager.Instance.VictoryToMainMenuEvent += ResetTimer;
        GameManager.Instance.RestartLevelEvent += ResetTimer;
        GameManager.Instance.PauseToMainMenuEvent += ResetTimer;
    }


    void Update () {

        if (GameManager.Instance.isGameStarted && !GameManager.Instance.isGamePaused && !GameManager.Instance.isHelpMenuActive  && !GameManager.Instance.isGameWin)
        {
            if (m_timeLeft > 0)
            {
                m_timeLeft -= Time.deltaTime;
                m_Timer.fillAmount = m_timeLeft / m_PowerDuration;
            }
            else
            {

                GameManager.Instance.isGameStarted = false;
                GameManager.Instance.CallGameLoose();
            }
        }
    }

    void ResetTimer()
    {
        m_timeLeft = m_PowerDuration;
        m_Timer.fillAmount = m_PowerDuration;
    }

   
}

