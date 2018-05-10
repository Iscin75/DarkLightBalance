using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public static bool isMenuActive = true;


    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickStart()
    {
        Logic.Instance.SetControllerPosition();
        Logic.Instance.currentLevel = 1;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        isMenuActive = false;
        UI.Instance.menuPrincipal.SetActive(false);
        Logic.Instance.mainCamera.SetActive(false);
        Logic.Instance.fpsController.SetActive(true);
    }
}
