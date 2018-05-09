using UnityEngine;
using UnityEngine.SceneManagement;

namespace Logic
{


    public class RestartLevel : MonoBehaviour
    {
        private GameManager gameGM;
        private void OnEnable()
        {
            SetGameManager();
            gameGM.RestartLevelEvent += Restart;

        }

        private void OnDisable()
        {
            gameGM.RestartLevelEvent -= Restart;
          
        }

        void Restart()
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }

        void SetGameManager()
        {
            gameGM = GetComponent<GameManager>();
        }

    }
}