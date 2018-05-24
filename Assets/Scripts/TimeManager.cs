using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {


    private void OnEnable()
    {
        GameManager.Instance.PauseMenuEvent += StopTime;
        GameManager.Instance.ContinueLevelEvent += StartTime;
    }

    private void OnDisable()
    {
        GameManager.Instance.PauseMenuEvent -= StopTime;
        GameManager.Instance.ContinueLevelEvent -= StartTime;
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
