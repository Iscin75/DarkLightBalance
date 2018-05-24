using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerManager : MonoBehaviour {

    [SerializeField]
    GameObject m_Player;

    private void Awake()
    {
        DisableController();
    }

    private void OnEnable()
    {
        GameManager.Instance.PauseMenuEvent += DisableController;
        GameManager.Instance.ContinueLevelEvent += EnableController;
        GameManager.Instance.StartGameEvent += EnableController;
        GameManager.Instance.MainMenuEvent += DisableController;
    }

    public void DisableController()
    {
        m_Player.GetComponent<FirstPersonController>().enabled = false;
    }

    public void EnableController()
    {
        m_Player.GetComponent<FirstPersonController>().enabled = true;
    }



}
