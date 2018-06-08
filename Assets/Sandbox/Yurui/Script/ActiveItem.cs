using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItem : MonoBehaviour {

    bool isActivated;

    [SerializeField]
    Camera lumiere;
    [SerializeField]
    GameObject cylinder;
    float delay;
    public ObjectState m_ObjectState = ObjectState.NoState;


	// Use this for initialization
	void Start () {
        isActivated = false;
    }
	
	// Update is called once per frame
	void Update () {

	}

    void LaunchActivation()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = lumiere.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            /*Open_Able p = null;
            if (hit.distance <= 6)
                p = hit.collider.GetComponent<Open_Able>();
            if (p != null)
            {
                p = GetComponentInChildren<Open_Able>();
                if (p != null)
                {
                    if (!p.isOpened)
                    {
                        Debug.Log("Closed but no animation");
                        p.isOpened = true;
                        cylinder.transform.Rotate(Time.deltaTime, 0, 5, 0);
                    }
                    else
                        Debug.Log("is open");
                }
                
            }*/
        }
    }
}

