using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour {

    #region Variables
    [SerializeField]
    public static GameObject m_Player;
    public static bool isCarryingObject = false;
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            if(!isCarryingObject)
            {
                GameManager.Instance.CallPickUpInteractableObject();
            }
            else
            {
                GameManager.Instance.CallDropInteractableObject();
            }

        if(!GameManager.Instance.isOilEmpty && !isCarryingObject && Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.CallToggleLightState();
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.PauseMenuEvent += DisableController;
        GameManager.Instance.ContinueLevelEvent += EnableController;
        GameManager.Instance.StartGameEvent += EnableController;
        GameManager.Instance.PauseToMainMenuEvent += DisableController;
        GameManager.Instance.RestartLevelEvent += EnableController;
        GameManager.Instance.GameVictoryEvent += DisableController;
        GameManager.Instance.GameLooseEvent += DisableController;

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
