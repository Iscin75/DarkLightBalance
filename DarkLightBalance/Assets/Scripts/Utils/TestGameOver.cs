using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class TestGameOver : MonoBehaviour
    {

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.O))
            {
                GetComponent<GameManager>().CallEventGameOver();
            }
        }
    }
}