using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    static int currentLevel;

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += LoadNextLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance.StartGameEvent -= LoadNextLevel;
    }

    void LoadNextLevel()
    {
     
         currentLevel++;
         SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
        
  
    }
}
