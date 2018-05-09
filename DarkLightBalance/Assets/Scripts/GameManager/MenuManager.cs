using UnityEngine;

namespace Logic
{

    public class MenuManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject menu;

        private GameManager gameGM;

        private void Update()
        {
            CheckMenuToggleRequest();
        }

        /**private void Start()
        {
            ToggleMenu();
        }**/

        private void OnEnable()
        {
            SetGameManager();
            gameGM.GameOverEvent += ToggleMenu;
            gameGM.RestartLevelEvent += ToggleMenu;
            

        }

        private void OnDisable()
        {
            gameGM.GameOverEvent -= ToggleMenu;
            gameGM.RestartLevelEvent -= ToggleMenu;
           
        }

        void CheckMenuToggleRequest()
        {
            if(Input.GetKeyDown(KeyCode.Escape) && !gameGM.isGameOver  )
            {
                ToggleMenu();
            }
        }

        void ToggleMenu()
        {
            if(menu != null)
            {
                menu.SetActive(!menu.activeSelf);
                gameGM.isMenuOn = !gameGM.isMenuOn;
                gameGM.CallEventMenuToggle();
                
            }
            else
            {
                Debug.LogWarning("Il faut assigner le Canvas de la scène au script 'MenuManager' dans l'inspecteur");
            }
        }

        void SetGameManager()
        {
            gameGM = GetComponent<GameManager>();
        }

       
    }
}