using UnityEngine;

public class OnTriggerTeleport : MonoBehaviour {

    [SerializeField]
    GameObject m_TeleportPosition;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(PlayerManager.isCarryingObject)
            {
                GameManager.Instance.CallDropInteractableObject();
            }
            player.transform.position = m_TeleportPosition.transform.position;
            player.transform.rotation = m_TeleportPosition.transform.rotation;

        }
    }


}
