using UnityEngine;

public class CursorManager : MonoBehaviour {

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += LockCursor;
        GameManager.Instance.PauseMenuEvent += EnableCursor;
        GameManager.Instance.ContinueLevelEvent += LockCursor;
        GameManager.Instance.PauseToMainMenuEvent += EnableCursor;
        GameManager.Instance.RestartLevelEvent += EnableCursor;
        GameManager.Instance.GameVictoryEvent += EnableCursor;
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
