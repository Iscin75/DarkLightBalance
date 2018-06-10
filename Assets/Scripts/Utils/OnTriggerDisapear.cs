using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerDisapear : MonoBehaviour {


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LanternEffect"))
            gameObject.SetActive(false);
    }
}
