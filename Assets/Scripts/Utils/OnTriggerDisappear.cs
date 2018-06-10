using UnityEngine;

public class OnTriggerDisappear : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LanternEffect"))
            gameObject.SetActive(false);
    }
}
