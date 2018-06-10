using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HelpPanel : MonoBehaviour {

    [SerializeField]
    GameObject m_HelpPanel;
    [SerializeField]
    GameObject m_TopPanel;
    [SerializeField]
    GameObject m_BotPanel;
    [SerializeField]
    public static Text topPanel_Text;
    public static Text botPanel_Text;


    void Awake()
    {
        topPanel_Text = m_TopPanel.GetComponentInChildren<Text>(true);
        botPanel_Text = m_BotPanel.GetComponentInChildren<Text>(true);
    }

    private void OnEnable()
    {
        GameManager.Instance.ShowHelpMenuEvent += ShowHelpPanel;
    }

    private IEnumerator HideHelpPanel()
    {
        yield return new WaitForSeconds(3);
        m_TopPanel.transform.DOLocalMoveY(480, 1);
        m_BotPanel.transform.DOLocalMoveY(-50, 1);
        m_HelpPanel.SetActive(false);
        GameManager.Instance.CallHideHelpMenu();
    }

    private void ShowHelpPanel()
    {
        m_HelpPanel.SetActive(true);
        m_TopPanel.transform.DOLocalMoveY(50, 2);
        m_BotPanel.transform.DOLocalMoveY(50, 2);
        StartCoroutine(HideHelpPanel());

    }
}
