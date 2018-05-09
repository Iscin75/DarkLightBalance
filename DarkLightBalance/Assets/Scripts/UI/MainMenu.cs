using UnityEngine;
using UnityEngine.SceneManagement;

namespace Logic
{
    public class MainMenu : MonoBehaviour
    {

        public void PlayGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
       
    }
}