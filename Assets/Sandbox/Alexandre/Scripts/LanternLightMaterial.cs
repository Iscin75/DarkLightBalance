using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternLightMaterial : MonoBehaviour {

    public Material materialNull;
    public Material materialLight;
    public Material materialShadow;

    Renderer rend;
    public bool isChanged;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material = materialNull;
        rend.enabled = false;
        isChanged = false;
    }
	
	// Update is called once per frame
	void Update () {
		if( isChanged )
            change();
	}

    void change()
    {
        if (rend.material.GetColor( "_TintColor" )== materialNull.GetColor("_TintColor"))
        {
            rend.material = materialLight;
            rend.enabled = true;
        }
        else if (rend.material.GetColor("_TintColor") == materialLight.GetColor("_TintColor"))
        {
            rend.material = materialShadow;
        }
        else if (rend.material.GetColor("_TintColor") == materialShadow.GetColor("_TintColor"))
        {
            rend.material = materialNull;
            rend.enabled = false;
        }
        isChanged = false;
    }

    public Color getCurrentColor()
    {
        return rend.material.GetColor("_TintColor");
    }
}
