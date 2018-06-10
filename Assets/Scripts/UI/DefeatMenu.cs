using UnityEngine;

public class DefeatMenu : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject m_LoosePanel;
    #endregion

    private void Awake()
    {
        if(m_LoosePanel == null)
            Debug.LogError("Merci d'assigner le menu de défaite au composant DefeatMenu dans l'Inspector");
    }

    private void OnEnable()
    {
        GameManager.Instance.GameLooseEvent += ToggleLoosePanel;
        GameManager.Instance.LooseToMainMenuEvent += ToggleLoosePanel;
    }

    void ToggleLoosePanel()
    {
        m_LoosePanel.SetActive(!m_LoosePanel.activeSelf);
    }

    public void OnClickMainMenu()
    {
        GameManager.Instance.CallLooseToMainMenu();
    }




}
