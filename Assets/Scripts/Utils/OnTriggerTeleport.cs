using UnityEngine;

public class OnTriggerTeleport : MonoBehaviour {

    [SerializeField]
    GameObject m_TeleportPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(PlayerManager.isCarryingObject)
            {
                GameManager.Instance.CallDropInteractableObject();
            }
            PlayerManager.SetPlayerTransform(m_TeleportPosition.transform);

        }
    }


}
