using UnityEngine;

public class ATH : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject m_ATH;
    #endregion

    private void Awake()
    {
        if (m_ATH == null)
            Debug.LogError("Merci d'assigner l'ATH au composant ATH dans l'Inspector");
    }

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += ToggleATH;
        GameManager.Instance.GameVictoryEvent += ToggleATH;
        GameManager.Instance.PauseMenuEvent += ToggleATH;
        GameManager.Instance.ContinueLevelEvent += ToggleATH;
        GameManager.Instance.RestartLevelEvent += ToggleATH;
        GameManager.Instance.GameLooseEvent += ToggleATH;


    }

    void ToggleATH()
    {
        m_ATH.SetActive(!m_ATH.activeSelf);
    }
}
