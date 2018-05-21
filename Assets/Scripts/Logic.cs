using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logic : Singleton<Logic> {

  
    [SerializeField]
    public GameObject fpsController;
    [SerializeField]
    public GameObject mainCamera;
    [SerializeField]
    public List<Transform> startPositions = new List<Transform>();
   

    public int currentLevel = 1;
    public int nbLevels;
    public bool isGameWin = false;

    private void Start()
    {
        nbLevels = startPositions.Count;
 
    }

    public void SetControllerPosition()
    {
        fpsController.transform.position = startPositions[currentLevel - 1].transform.position;
        fpsController.transform.rotation = startPositions[currentLevel - 1].transform.rotation;
    }

    public void GoToNextLevel()
    {

        if (currentLevel != nbLevels)
        {
           
            SceneManager.UnloadSceneAsync("Level " + currentLevel.ToString());
            currentLevel += 1;
            SceneManager.LoadScene(currentLevel, LoadSceneMode.Additive);
            SetControllerPosition();

        }
        

        else 
        {
            Debug.Log("WINNN!!");
            isGameWin = true;

        }
      
    }

}
