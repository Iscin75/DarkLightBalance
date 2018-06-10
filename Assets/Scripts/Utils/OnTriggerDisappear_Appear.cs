using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDisappear_Appear : MonoBehaviour {

    [SerializeField]
    GameObject toApply;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LanternEffect"))
            toApply.gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("LanternEffect"))
            toApply.gameObject.SetActive(true);
    }
}
