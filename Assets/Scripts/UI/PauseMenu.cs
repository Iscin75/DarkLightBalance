using UnityEngine;

public class PauseMenu : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject m_PauseMenuPanel;
    bool isActive = false;
    #endregion

    private void Awake()
    {
        if(m_PauseMenuPanel == null)
            Debug.LogError("Merci d'assigner le menu pause au composant PauseMenu dans l'Inspector");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !GameManager.Instance.isGameWin && GameManager.Instance.isGameStarted)
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
        GameManager.Instance.PauseToMainMenuEvent += ToggleMenuPause;
        GameManager.Instance.RestartLevelEvent += ToggleMenuPause;
    }

    void ToggleMenuPause()
    {
        m_PauseMenuPanel.SetActive(!m_PauseMenuPanel.activeSelf);
    }

    public void OnClickMenuPrincipal()
    {
        isActive = false;
        GameManager.Instance.CallPauseToMainMenu();
    }

    public void OnClickRestart()
    {
        isActive = false;
        GameManager.Instance.CallRestartLevel();
    }

}
