using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour {

    #region Variables
    [SerializeField]
    public static GameObject m_Player;
    #endregion

    private void Awake()
    {
        try
        {
            m_Player = GameObject.FindGameObjectWithTag("Player");
        }
        catch
        {
            Debug.LogError("Contrôleur du personnage introuvable, merci de l'ajouter et/ou d'y assigner le tag Player");
        }
        DisableController();
    }

    private void OnEnable()
    {
        GameManager.Instance.PauseMenuEvent += DisableController;
        GameManager.Instance.ContinueLevelEvent += EnableController;
        GameManager.Instance.StartGameEvent += EnableController;
        GameManager.Instance.MainMenuEvent += DisableController;
        GameManager.Instance.RestartLevelEvent += EnableController;
    }

    public void DisableController()
    {
        m_Player.GetComponent<FirstPersonController>().enabled = false;
    }

    public void EnableController()
    {
        m_Player.GetComponent<FirstPersonController>().enabled = true;
    }

    public static void SetPlayerTransform(Transform pPositions)
    {
        m_Player.transform.position = pPositions.position;
        m_Player.transform.rotation = pPositions.rotation;
        
    }
 



}
