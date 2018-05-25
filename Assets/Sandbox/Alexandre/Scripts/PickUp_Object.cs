using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Object : MonoBehaviour {

    Camera mainCamera;
    bool carryingObj;
    GameObject carriedObj;

    
    public float distance;
    public float smooth;

	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        carryingObj = false;
	}
	
	// Update is called once per frame
	void Update () {
		if( carryingObj )
        {
            carry(carriedObj);
        }
        else
        {
            pickup();
        }
	}

    void carry( GameObject a)
    {
        Rigidbody a_r = a.GetComponent<Rigidbody>();
        a_r.isKinematic = true;

        a.transform.position = Vector3.Lerp(a.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup()
    {
        if( Input.GetKeyDown (KeyCode.E))
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if( Physics.Raycast( ray, out hit))
            {
                PickUp_Able p = hit.collider.GetComponent<PickUp_Able>();
                if( p != null )
                {
                    carryingObj = true;
                    carriedObj = p.gameObject;
                }
            }
        }
    }
}
