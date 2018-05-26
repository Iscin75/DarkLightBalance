public class GameManager : Singleton<GameManager> {

    public delegate void GameEventHandler();
    public event GameEventHandler StartGameEvent;
    public event GameEventHandler RestartLevelEvent;
    public event GameEventHandler PauseMenuEvent;
    public event GameEventHandler ContinueLevelEvent;
    public event GameEventHandler MainMenuEvent;
    public event GameEventHandler LevelVictoryEvent;
    

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

    public void CallRestartLevel()
    {
        if (RestartLevelEvent != null)
            RestartLevelEvent();
    }

    public void CallMainMenu()
    {
        if (StartGameEvent != null)
            MainMenuEvent();
    }

    public void CallLevelVictory()
    {
        if (LevelVictoryEvent != null)
            LevelVictoryEvent();
    }



}
