using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    public delegate void GameEventHandler();
    public event GameEventHandler StartGameEvent;
    public event GameEventHandler PauseMenuEvent;
    public event GameEventHandler ContinueLevelEvent;
    

    public void CallStartGame()
    {
        if (StartGameEvent != null)
            StartGameEvent();
        
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
   

}
