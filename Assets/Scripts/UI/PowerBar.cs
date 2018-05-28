using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    #region Variables
    [SerializeField]
    Image m_PowerBar;
    [SerializeField]
    float m_PowerDuration = 10f;
    float m_timeLeft;
    bool isPowerActive = false;
    #endregion

    private void Awake()
    {
        if (m_PowerBar == null)
            Debug.LogError("Merci d'assigner la barre de pouvoir au composant PowerBar dans l'Inspector");
    }

    private void Start()
    {
        m_timeLeft = m_PowerDuration;
    }

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += ResetPowerBar;
        GameManager.Instance.RestartLevelEvent += ResetPowerBar;
        GameManager.Instance.LevelVictoryEvent += ResetPowerBar;
        GameManager.Instance.RestartLevelEvent += StopPowerBar;
        GameManager.Instance.PauseMenuEvent += StopPowerBar;
        GameManager.Instance.GameLooseEvent += StopPowerBar;
        GameManager.Instance.GameVictoryEvent += StopPowerBar;
    }

    private void Update()
    {
        CheckForPowerActivation();
        if (GameManager.Instance.isGameStarted && isPowerActive)
        {
            if (m_timeLeft > 0)
            {
                m_timeLeft -= Time.deltaTime;
                m_PowerBar.fillAmount = m_timeLeft / m_PowerDuration;
            }
            else
            {
                GameManager.Instance.isGameStarted = false;
                GameManager.Instance.CallGameLoose();
            }
        }
    }

    void CheckForPowerActivation()
    {
        if (Input.GetKeyDown(KeyCode.P) && GameManager.Instance.isGameStarted && !GameManager.Instance.isGamePaused)
            isPowerActive = !isPowerActive;
    }

    void ResetPowerBar()
    {
        m_timeLeft = m_PowerDuration;
        m_PowerBar.fillAmount = m_PowerDuration;
    }

    void StopPowerBar()
    {
        isPowerActive = false;
    }

    

}
