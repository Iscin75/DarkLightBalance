using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class MenuPause : MonoBehaviour {

    bool isMenuActive = true;
  

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) && MenuPrincipal.isMenuActive == false)
        {
            CheckForCursorLock();
            isMenuActive = !isMenuActive;
            UI.Instance.menuPause.SetActive(isMenuActive);

        }
    }

    private void CheckForCursorLock()
    {
        if(!isMenuActive)
        {
            LockGame();
        }
        else
        {
            UnlockGame();
        }
    }

    public void OnClickRestart()
    {
        Logic.Instance.SetControllerPosition();
        SceneManager.UnloadSceneAsync(Logic.Instance.currentLevel);
        SceneManager.LoadScene(Logic.Instance.currentLevel, LoadSceneMode.Additive);
        UnlockGame();
        isMenuActive = false;
        UI.Instance.menuPause.SetActive(false);

    }

    public void OnClickMenuPrincipal()
    {
        SceneManager.UnloadSceneAsync(Logic.Instance.currentLevel);
        Logic.Instance.fpsController.GetComponent<FirstPersonController>().enabled = true;
        Logic.Instance.fpsController.SetActive(false);
        UI.Instance.menuPause.SetActive(false);
        MenuPrincipal.isMenuActive = true;
        Time.timeScale = 1;
        UI.Instance.menuPrincipal.SetActive(true);
        Logic.Instance.mainCamera.SetActive(true);

    }

    private void LockGame()
    {
        Time.timeScale = 0;
        Logic.Instance.fpsController.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void UnlockGame()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Logic.Instance.fpsController.GetComponent<FirstPersonController>().enabled = true;
    }


}
