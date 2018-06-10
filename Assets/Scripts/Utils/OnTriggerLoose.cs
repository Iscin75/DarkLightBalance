using UnityEngine;

public class OnTriggerLoose : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            GameManager.Instance.CallGameLoose();
    }
}
