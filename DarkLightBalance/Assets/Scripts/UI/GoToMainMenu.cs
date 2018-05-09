using UnityEngine;
using UnityEngine.SceneManagement;

namespace Logic
{
    public class GoToMainMenu : MonoBehaviour
    {
        private GameManager gameGM;

        private void OnEnable()
        {
            SetGameManager();
            gameGM.GoToMenuSceneEvent += GoToMain;
          
        }

        private void OnDisable()
        {
            gameGM.GoToMenuSceneEvent -= GoToMain;
            
        }

        public void GoToMain()
        {
            SceneManager.LoadScene(0);
        }

        void SetGameManager()
        {
            gameGM = GetComponent<GameManager>();
        }
    }
}