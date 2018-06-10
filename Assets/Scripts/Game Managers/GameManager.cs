using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    #region eventsList
    public delegate void GameEventHandler();
    public event GameEventHandler StartGameEvent;
    public event GameEventHandler RestartLevelEvent;
    public event GameEventHandler PauseMenuEvent;
    public event GameEventHandler ContinueLevelEvent;
    public event GameEventHandler PauseToMainMenuEvent;
    public event GameEventHandler LevelVictoryEvent;
    public event GameEventHandler GameVictoryEvent;
    public event GameEventHandler VictoryToMainMenuEvent;
    public event GameEventHandler GameLooseEvent;
    public event GameEventHandler LooseToMainMenuEvent;
    public event GameEventHandler EmptyPowerBarEvent;
    public event GameEventHandler PickUpInteractableObjectEvent;
    public event GameEventHandler DropInteractableObjectEvent;
    public event GameEventHandler ToggleLightStateEvent;
    public event GameEventHandler ShowHelpMenuEvent;
    public event GameEventHandler HideHelpMenuEvent;
    #endregion

    #region GlobalVariables
    public bool isGameWin = false;
    public bool isGameStarted = false;
    public bool isGamePaused;
    public bool isLightOn = false;
    public bool isOilEmpty = false;
    public bool isHelpMenuActive = false;
    #endregion

    public void CallStartGame()
    {
        if (StartGameEvent != null)
        {
            isGamePaused = false;
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

    public void CallGameLoose()
    {
        if (GameLooseEvent != null)
            isGameWin = false;
        GameLooseEvent();
    }

    public void CallLooseToMainMenu()
    {
        if (LooseToMainMenuEvent != null)
        {
            isGameStarted = false;
            LooseToMainMenuEvent();
        }
    }

    public void CallEmptyPowerBar()
    {
        if (EmptyPowerBarEvent != null)
            EmptyPowerBarEvent();
    }

    public void CallPickUpInteractableObject()
    {
        if (PickUpInteractableObjectEvent != null)
            PickUpInteractableObjectEvent();
    }

    public void CallDropInteractableObject()
    {
        if (DropInteractableObjectEvent != null)
            DropInteractableObjectEvent();
    }

    public void CallToggleLightState()
    {
        if (ToggleLightStateEvent != null)
            ToggleLightStateEvent();
    }

    public void CallHelpMenu()
    {
        if (ShowHelpMenuEvent != null)
        {
            isHelpMenuActive = true;
            ShowHelpMenuEvent();
        }
           
    }

    public void CallHideHelpMenu()
    {
        if (HideHelpMenuEvent != null)
        {
            isHelpMenuActive = false;
            HideHelpMenuEvent();
        }
    }
}

#region Enum
public enum ObjectState { NoState, Shadow };
#endregion