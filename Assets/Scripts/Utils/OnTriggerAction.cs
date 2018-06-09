using UnityEngine;

public class OnTriggerAction : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LanternEffect"))
        {
            gameObject.SetActive(false);
        }
    }
}
