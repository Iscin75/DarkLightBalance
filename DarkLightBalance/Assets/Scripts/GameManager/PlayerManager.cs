using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Logic
{
    public class PlayerManager : MonoBehaviour
    {

        [SerializeField]
        private FirstPersonController playerController;

        private GameManager gameGM;
        private void OnEnable()
        {
            SetGameManager();
            gameGM.MenuToggleEvent += TogglePlayerController;
        }


        private void OnDisable()
        {
            gameGM.MenuToggleEvent -= TogglePlayerController;
        }

        void TogglePlayerController()
        {
            if(playerController != null)
            {

                playerController.enabled = !gameGM.isMenuOn;
            }
            else
            {
                Debug.LogWarning("Il faut assigner le PlayerController de la scène au script 'PlayerManager' dans l'inspecteur");
            }
        }

        void SetGameManager()
        {
            gameGM = GetComponent<GameManager>();
        }

        
    }
}