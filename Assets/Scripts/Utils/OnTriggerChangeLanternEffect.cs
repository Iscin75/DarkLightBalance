using UnityEngine;

public class OnTriggerChangeLanternEffect : MonoBehaviour {

    [SerializeField]
    GameObject AreaOfEffect;

    [SerializeField]
    Material toApply;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            AreaOfEffect.GetComponent<Renderer>().material = toApply;
    }
}
