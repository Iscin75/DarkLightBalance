using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    #region Variables
    int currentLevel = 0;
    [SerializeField]
    Transform levelStartPosition;
    #endregion

    private void OnEnable()
    {
        GameManager.Instance.StartGameEvent += LoadNextLevel;
        GameManager.Instance.PauseToMainMenuEvent += UnloadGame;
        GameManager.Instance.RestartLevelEvent += RestartLevel;
        GameManager.Instance.LevelVictoryEvent += LoadNextLevel;
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        GameManager.Instance.VictoryToMainMenuEvent += UnloadGame;
        GameManager.Instance.LooseToMainMenuEvent += UnloadGame;
    }

    void LoadNextLevel()
    {
        
        if (SceneManager.sceneCountInBuildSettings > currentLevel + 1 )
        {
            if (SceneManager.sceneCount > 1)
                SceneManager.UnloadSceneAsync(currentLevel);
            
            currentLevel++;
            SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
        }
        else
        {
            GameManager.Instance.CallGameVictory();
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
            try
            {
                levelStartPosition = GameObject.FindGameObjectWithTag("StartPoint").transform;
            }
            catch
            {
                Debug.LogError("Point de départ inexistant dans le niveau suivant, merci d'assigner un tag StartPoint dans la scène correspondante");
            }
            GetAllLanternEffect();
            LightManager.SwitchOffAllLight();
            GameManager.Instance.isLightOn = false;
           
            PlayerManager.SetPlayerTransform(levelStartPosition);
        }
    }

    void GetAllLanternEffect()
    {
        LightManager.allLanternEffects = GameObject.FindGameObjectsWithTag("PickableLight").ToList();
      

    }

}
