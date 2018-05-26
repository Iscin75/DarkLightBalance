using UnityEngine;

public class MainMenu : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject m_mainMenuPanel;
    #endregion

    private void Awake()
    {
        if (m_mainMenuPanel == null)
            Debug.LogError("Merci d'assigner le menu principal au composant MainMenu dans l'Inspector");
    }

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
