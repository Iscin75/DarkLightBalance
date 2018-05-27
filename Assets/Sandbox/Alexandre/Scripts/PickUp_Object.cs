using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Object : MonoBehaviour
{

    Camera mainCamera;
    bool carryingObj;
    GameObject carriedObj;

    Quaternion originalRotationValue;

    public float distance;
    public float smooth;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        carryingObj = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (carryingObj)
        {
            //Debug.Log("J'te porte");
            carry(carriedObj);
            checkDrop();
        }
        else
        {
            pickup();
        }
    }

    void carry(GameObject a)
    {
        a.transform.position = Vector3.Lerp(a.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
        a.transform.rotation = mainCamera.transform.rotation;
    }

    void checkDrop()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            dropObject();
        }
    }

    void dropObject()
    {
        Rigidbody a_r = carriedObj.GetComponent<Rigidbody>();
        carriedObj.transform.eulerAngles = new Vector3(originalRotationValue.eulerAngles.x, mainCamera.transform.eulerAngles.y,
            originalRotationValue.eulerAngles.z);
        carriedObj.transform.position = new Vector3(carriedObj.transform.position.x, mainCamera.transform.position.y, carriedObj.transform.position.z);
        a_r.constraints |= RigidbodyConstraints.FreezeRotationY;
        a_r.constraints |= RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        Light l_p = carriedObj.GetComponentInChildren<Light>(true);
        if (l_p != null)
            l_p.enabled = true;
        a_r.useGravity = true;
        carryingObj = false;
        carriedObj = null;
        Physics.IgnoreLayerCollision(9, 10, false);

    }

    void pickup()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                PickUp_Able p = hit.collider.GetComponent<PickUp_Able>();
                if (p != null)
                {
                    Rigidbody a_r = p.GetComponent<Rigidbody>();
                    a_r.constraints &= ~RigidbodyConstraints.FreezeRotationY;
                    a_r.constraints &= ~RigidbodyConstraints.FreezePositionX & ~RigidbodyConstraints.FreezePositionZ;
                    a_r.useGravity = false;
                    carryingObj = true;
                    carriedObj = p.gameObject;
                    originalRotationValue = carriedObj.transform.rotation;
                    Physics.IgnoreLayerCollision(9, 10, true);
                    Light l_p = p.GetComponentInChildren<Light>(true);
                    if (l_p != null)
                        l_p.enabled = false;
                }
            }
        }
    }
}
