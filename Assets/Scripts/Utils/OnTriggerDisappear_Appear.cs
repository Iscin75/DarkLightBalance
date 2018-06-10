using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDisappear_Appear : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LanternEffect"))
            gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LanternEffect"))
            gameObject.SetActive(true);
    }
}
