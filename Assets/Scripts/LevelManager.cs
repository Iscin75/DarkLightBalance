using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    static int currentLevel;

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += LoadNextLevel;
        GameManager.Instance.MainMenuEvent += UnloadLastLevel;
    }


    void LoadNextLevel()
    {
     
         currentLevel++;
         SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
        
    }

    void UnloadLastLevel()
    {
        SceneManager.UnloadSceneAsync(currentLevel);
        currentLevel = 0;
    }
}
