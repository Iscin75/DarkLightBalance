using UnityEngine;

namespace Logic
{
    public class PauseManager : MonoBehaviour
    {

        private bool isPaused;
        private GameManager gameGM;

        private void OnEnable()
        {
            SetGameManager();
            gameGM.MenuToggleEvent += TogglePause;
        }

        private void OnDisable()
        {
            gameGM.MenuToggleEvent -= TogglePause;

        }

        void TogglePause()
        {
            if(isPaused)
            {
                Time.timeScale = 1;
                isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }

        void SetGameManager()
        {
            gameGM = GetComponent<GameManager>();
        }
    }
}