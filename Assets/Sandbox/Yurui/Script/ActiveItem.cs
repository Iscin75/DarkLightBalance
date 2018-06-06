using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveItem : MonoBehaviour {

    bool isOpened;

    [SerializeField]
    Camera lumiere;
    float delay;
    public ObjectState m_ObjectState = ObjectState.NoState;


	// Use this for initialization
	void Start () {
        isOpened = false;
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
            Ouvrir_Able p = null;
            if (hit.distance <= 6)
                p = hit.collider.GetComponent<Ouvrir_Able>();
            if (p != null)
            {

            }
        }
    }
}

