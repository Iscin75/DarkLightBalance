using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class OnTriggerHelpPanel : MonoBehaviour {


    bool isActivable = true;
    [SerializeField]
    string topPanel_value;
    [SerializeField]
    string botPanel_value;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(isActivable);
        if(isActivable && other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision");
            HelpPanel.topPanel_Text.text = topPanel_value;
            HelpPanel.botPanel_Text.text = botPanel_value;
            GameManager.Instance.CallHelpMenu();
            isActivable = false;
        }
    }
}
