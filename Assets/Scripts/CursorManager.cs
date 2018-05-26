using UnityEngine;

public class CursorManager : MonoBehaviour {

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += LockCursor;
        GameManager.Instance.PauseMenuEvent += EnableCursor;
        GameManager.Instance.ContinueLevelEvent += LockCursor;
        GameManager.Instance.MainMenuEvent += EnableCursor;
        GameManager.Instance.RestartLevelEvent += EnableCursor;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
