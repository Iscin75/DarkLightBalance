using UnityEngine;

namespace Logic
{
    public class GameOverManager : MonoBehaviour
    {
        private GameManager gameGM;

        [SerializeField]
        private GameObject panelGO;

        private void OnEnable()
        {
            SetGameManager();
            gameGM.GameOverEvent += ActivateGOPanel;
        }

        private void OnDisable()
        {
            gameGM.GameOverEvent -= ActivateGOPanel;
        }

        void SetGameManager()
        {
            gameGM = GetComponent<GameManager>();
        }

        void ActivateGOPanel()
        {
            if(panelGO != null)
            {
                panelGO.SetActive(true);
            }
            else
            {
                Debug.LogWarning("Il faut assigner le panel GameOver de la scène au script 'GameOverManager' dans l'inspecteur");
            }
        }
    }
}