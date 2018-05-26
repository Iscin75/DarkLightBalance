using UnityEngine;

public class VictoryMenu : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject m_VictoryMenu;
    #endregion

    private void Awake()
    {
        if (m_VictoryMenu == null)
            Debug.LogError("Merci d'assigner le menu pause au composant PauseMenu dans l'Inspector");
    }

    private void OnEnable()
    {
        GameManager.Instance.GameVictoryEvent += ToggleVictoryMenu;
        GameManager.Instance.VictoryToMainMenuEvent += ToggleVictoryMenu;

    }

    void ToggleVictoryMenu()
    {
        m_VictoryMenu.SetActive(!m_VictoryMenu.activeSelf);
    }

    public void OnClickMenuPrincipal()
    {
        GameManager.Instance.CallVictoryToMainMenu();
    }
}
