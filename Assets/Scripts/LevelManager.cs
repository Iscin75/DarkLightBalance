using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    int currentLevel = 0;
    [SerializeField]
    Transform levelStartPosition;

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += LoadNextLevel;
        GameManager.Instance.MainMenuEvent += UnloadGame;
        GameManager.Instance.RestartLevelEvent += RestartLevel;
        GameManager.Instance.LevelVictoryEvent += LoadNextLevel;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }


    void LoadNextLevel()
    {
        
        if (SceneManager.sceneCountInBuildSettings > currentLevel + 1 )
        {
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(currentLevel);
            }
            currentLevel++;

            SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
        }
        else
        {
            Debug.Log("Win");
            //TODO Panel Victoire
        }


    }

    void UnloadGame()
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        currentLevel = 0;
    }

    void RestartLevel()
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
       if(currentLevel != 0)
        {
            levelStartPosition = GameObject.FindGameObjectWithTag("StartPoint").transform;
            PlayerManager.SetPlayerTransform(levelStartPosition);
        }
    }

}
