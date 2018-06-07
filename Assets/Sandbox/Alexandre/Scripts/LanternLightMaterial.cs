using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternLightMaterial : MonoBehaviour {

    [SerializeField]
    public Material materialNull;
    [SerializeField]
    public Material materialShadow;
    [SerializeField]
    GameObject currentLantern;
    ActiveItem lanternState;

    Renderer rend;
    public bool isChanged;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material = materialNull;
        rend.enabled = false;
        isChanged = false;
        lanternState = currentLantern.GetComponent<ActiveItem>();
    }
	
	// Update is called once per frame
	void Update () {
		if( isChanged )
            change();
	}

    void change()
    {

        if( lanternState.m_ObjectState == ObjectState.NoState )
        {
            rend.material = materialShadow;
            lanternState.m_ObjectState = ObjectState.Shadow;
            rend.enabled = true;
        }
        else if( lanternState.m_ObjectState == ObjectState.Shadow )
        {
            rend.material = materialNull;
            lanternState.m_ObjectState = ObjectState.NoState;
            rend.enabled = false;
        }
        isChanged = false;
    }

    public Color getCurrentColor()
    {
        return rend.material.GetColor("_TintColor");
    }
}
