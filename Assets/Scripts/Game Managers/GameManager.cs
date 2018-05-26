﻿public class GameManager : Singleton<GameManager> {

    public delegate void GameEventHandler();
    public event GameEventHandler StartGameEvent;
    public event GameEventHandler RestartLevelEvent;
    public event GameEventHandler PauseMenuEvent;
    public event GameEventHandler ContinueLevelEvent;
    public event GameEventHandler PauseToMainMenuEvent;
    public event GameEventHandler LevelVictoryEvent;
    public event GameEventHandler GameVictoryEvent;
    public event GameEventHandler VictoryToMainMenuEvent;

    public bool isGameWin = false;
    public bool isGameStarted = false;

    public void CallStartGame()
    {
        if (StartGameEvent != null)
        {
            isGameStarted = true;
            StartGameEvent();
        }
    }

    public void CallPauseMenu()
    {
        if (PauseMenuEvent != null)
            PauseMenuEvent();
    }

    public void CallContinueLevel()
    {
        if (ContinueLevelEvent != null)
            ContinueLevelEvent();
    }

    public void CallRestartLevel()
    {
        if (RestartLevelEvent != null)
            RestartLevelEvent();
    }

    public void CallPauseToMainMenu()
    {
        if (StartGameEvent != null)
        {
            isGameStarted = false;
            PauseToMainMenuEvent();
        }

    }

    public void CallVictoryToMainMenu()
    {
        if (VictoryToMainMenuEvent != null)
        {
            isGameWin = false;
            isGameStarted = false;
            VictoryToMainMenuEvent();
        }
    }

    public void CallLevelVictory()
    {
        if (LevelVictoryEvent != null)
            LevelVictoryEvent();
    }

    public void CallGameVictory()
    {
        if (GameVictoryEvent != null)
        {
            isGameWin = true;
            GameVictoryEvent();
        }
    }



}