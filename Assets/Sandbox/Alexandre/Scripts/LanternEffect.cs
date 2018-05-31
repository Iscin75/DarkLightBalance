using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternEffect : MonoBehaviour {

    public Material EffectNull;
    public Material EffectLight;
    public Material EffectShadow;

    Renderer rend;
    public bool isChanged;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material = EffectNull;
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
        if (rend.material.shader == EffectNull.shader )
        {
            rend.material = EffectLight;
            rend.enabled = true;
        }
        else if (rend.material.shader == EffectLight.shader)
        {
            rend.material = EffectShadow;
        }
        else if (rend.material.shader == EffectShadow.shader)
        {
            rend.material = EffectNull;
            rend.enabled = false;
        }
        isChanged = false;
    }
}
