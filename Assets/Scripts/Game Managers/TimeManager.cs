using UnityEngine;

public class TimeManager : MonoBehaviour {

    private void Awake()
    {
        StopTime();
    }

    private void OnEnable()
    {
        GameManager.Instance.PauseMenuEvent += StopTime;
        GameManager.Instance.ContinueLevelEvent += StartTime;
        GameManager.Instance.StartGameEvent += StartTime;
        GameManager.Instance.PauseRestartLevelEvent += StartTime;
        GameManager.Instance.GameVictoryEvent += StopTime;
        GameManager.Instance.GameLooseEvent += StopTime;
        GameManager.Instance.ShowHelpMenuEvent += StopTime;
        GameManager.Instance.HideHelpMenuEvent += StartTime;
        GameManager.Instance.DefeatRestartLevelEvent += StartTime;
    }

    void StopTime()
    {
        Time.timeScale = 0;
    }

    void StartTime()
    {
        Time.timeScale = 1;
    }
}
