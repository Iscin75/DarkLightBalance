using UnityEngine;

namespace Logic
{
    public class CursorManager : MonoBehaviour
    {
        private bool isCursorLocked = true;
        private GameManager gameGM;

        private void OnEnable()
        {
            SetGameManager();
            gameGM.MenuToggleEvent += ToggleCursorState;
        }

        private void OnDisable()
        {
            gameGM.MenuToggleEvent -= ToggleCursorState;
        }

        void Update()
        {
            CheckIfCursorShouldLock();
        }

        void ToggleCursorState()
        {
            isCursorLocked = !isCursorLocked;
        }

        void CheckIfCursorShouldLock()
        {
            if(isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        void SetGameManager()
        {
            gameGM = GetComponent<GameManager>();
        }
    }
}