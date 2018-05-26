using UnityEngine;

[RequireComponent(typeof(Collider))]
public class VictoryTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            GameManager.Instance.CallLevelVictory();
    }
}
