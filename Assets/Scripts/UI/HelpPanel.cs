using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject m_HelpPanel;
    [SerializeField]
    GameObject m_TopPanel;
    [SerializeField]
    GameObject m_BotPanel;
    [SerializeField]
    public static Text topPanel_Text;
    public static Text botPanel_Text;
    #endregion


    void Awake()
    {
        if (m_HelpPanel == null || m_TopPanel == null || m_BotPanel == null)
            Debug.LogError("Merci d'assigner les objets au script Helpmenu dans l'Inspector");
   
        topPanel_Text = m_TopPanel.GetComponentInChildren<Text>(true);
        botPanel_Text = m_BotPanel.GetComponentInChildren<Text>(true);
    }

    private void OnEnable()
    {
        GameManager.Instance.ShowHelpMenuEvent += ShowHelpPanel;
    }

    private IEnumerator HideHelpPanel()
    {
        yield return new WaitForSeconds(7);
        m_TopPanel.transform.DOLocalMoveY(480, 1);
        m_BotPanel.transform.DOLocalMoveY(-50, 1);
        m_HelpPanel.SetActive(false);
        GameManager.Instance.CallHideHelpMenu();
    }

    private void ShowHelpPanel()
    {
        m_HelpPanel.SetActive(true);
        m_TopPanel.transform.DOLocalMoveY(50, 6);
        m_BotPanel.transform.DOLocalMoveY(50, 6);
        StartCoroutine(HideHelpPanel());

    }
}
