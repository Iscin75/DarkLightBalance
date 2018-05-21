using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuVictoire : MonoBehaviour {


    private void Update()
    {
        if(Logic.Instance.isGameWin)
        {
            ShowVictoryPanel();
            Logic.Instance.isGameWin = false;
        }
    }

    public void ShowVictoryPanel()
    {
        UI.Instance.menuVictoire.SetActive(true);
        Logic.Instance.fpsController.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void OnClickMenuPrincipal()
    {
        UI.Instance.menuVictoire.SetActive(false);
        SceneManager.UnloadSceneAsync("Level " + Logic.Instance.currentLevel);
        Logic.Instance.fpsController.GetComponent<FirstPersonController>().enabled = true;
        Logic.Instance.fpsController.SetActive(false);
        MenuPrincipal.isMenuActive = true;
        Time.timeScale = 1;
        UI.Instance.menuPrincipal.SetActive(true);
        Logic.Instance.mainCamera.SetActive(true);
    }


}
