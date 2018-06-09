using System.Collections.Generic;
using UnityEngine;


public class LightManager : MonoBehaviour
{

    #region Variables
    [SerializeField]
    Camera playerCamera;
    GameObject currentCarriedObj;
    float distance = 3;
    float smooth = 6;
    Quaternion originalRotationValue;
    public static List<GameObject> allLanternEffects;
    #endregion

    private void Awake()
    {
        if (playerCamera == null)
            Debug.LogError("Merci d'assigner la caméra au script LightManager de la scene Logic&UI");
    }

    private void OnEnable()
    {
        GameManager.Instance.EmptyPowerBarEvent += SwitchOffAllLight;
        GameManager.Instance.PickUpInteractableObjectEvent += PickUpLight;
        GameManager.Instance.PickUpInteractableObjectEvent += SwitchOffAllLight;
        GameManager.Instance.DropInteractableObjectEvent += DropLight;
        GameManager.Instance.DropInteractableObjectEvent += SwitchOnAllLight;
        GameManager.Instance.ToggleLightStateEvent += ToggleLightState;
    }

    private void Update()
    {
        if(PlayerManager.isCarryingObject )
        {

            currentCarriedObj.transform.position = Vector3.Lerp(currentCarriedObj.transform.position, playerCamera.transform.position + playerCamera.transform.forward * distance, Time.deltaTime * smooth);
            currentCarriedObj.transform.rotation = playerCamera.transform.rotation;
        }
    }

    void ToggleLightState()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = playerCamera.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.distance <= 3)
            if (hit.transform.gameObject.CompareTag("PickableLight"))
            {
                CurrentLightState go = hit.transform.gameObject.GetComponentInChildren<CurrentLightState>(true);
                if (go.thisLightState == ObjectState.Shadow)
                {
                    GameManager.Instance.isLightOn = false;
                    go.gameObject.SetActive(false);
                    go.gameObject.GetComponent<CurrentLightState>().thisLightState = ObjectState.NoState;

                }
                else
                {
                    GameManager.Instance.isLightOn = true;
                    go.gameObject.SetActive(true);
                    go.gameObject.GetComponent<CurrentLightState>().thisLightState = ObjectState.Shadow;
                }
               
                
            }
    }

    public static void SwitchOffAllLight()
    {
        foreach (GameObject go in allLanternEffects)
        {
            if(go.GetComponentInChildren<CurrentLightState>(true) != null)
                go.GetComponentInChildren<CurrentLightState>(true).gameObject.SetActive(false);
        }
            
    }

    void SwitchOnAllLight()
    {
        foreach (GameObject go in allLanternEffects)
        {
            if (go.GetComponentInChildren<CurrentLightState>(true) != null && go.GetComponentInChildren<CurrentLightState>(true).thisLightState == ObjectState.Shadow)
            {
                GameManager.Instance.isLightOn = true;
                go.GetComponentInChildren< CurrentLightState>(true).gameObject.SetActive(true);
            }
        }  

    }

    void PickUpLight()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = playerCamera.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.distance <= 3)
        
            if (hit.transform.gameObject.CompareTag("PickableLight"))
            {
                Debug.Log("Pickable");
                currentCarriedObj = hit.transform.gameObject;
                Rigidbody a_r = currentCarriedObj.GetComponent<Rigidbody>();
                a_r.constraints &= ~RigidbodyConstraints.FreezeRotationY;
                a_r.constraints &= ~RigidbodyConstraints.FreezePositionX & ~RigidbodyConstraints.FreezePositionZ;
                a_r.useGravity = false;
                originalRotationValue = currentCarriedObj.transform.rotation;
                Physics.IgnoreLayerCollision(9, 10, true);
                PlayerManager.isCarryingObject = true;
                if (currentCarriedObj.transform.GetComponentInChildren<CurrentLightState>(true).thisLightState == ObjectState.Shadow)
                {
                    GameManager.Instance.isLightOn = false;
                }
            } 
    }

    void DropLight()
    {
        if(currentCarriedObj != null)
        {
            Debug.Log("Dropable");
            Rigidbody a_r = currentCarriedObj.GetComponent<Rigidbody>();
            currentCarriedObj.transform.eulerAngles = new Vector3(originalRotationValue.eulerAngles.x, playerCamera.transform.eulerAngles.y,
            originalRotationValue.eulerAngles.z);
            currentCarriedObj.transform.position = new Vector3(currentCarriedObj.transform.position.x, playerCamera.transform.position.y, currentCarriedObj.transform.position.z);
            a_r.constraints |= RigidbodyConstraints.FreezeRotationY;
            a_r.constraints |= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            a_r.useGravity = true;
            Physics.IgnoreLayerCollision(9, 10, false);
            if (currentCarriedObj.transform.GetComponentInChildren<CurrentLightState>(true).thisLightState == ObjectState.Shadow)
            {
                GameManager.Instance.isLightOn = true;
            }
            PlayerManager.isCarryingObject = false;
            currentCarriedObj = null;
            
        }
    }



   
            
}
