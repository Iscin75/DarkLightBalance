using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternEffect : MonoBehaviour {

    public Material EffectNull;
    public Material EffectShadow;

    [SerializeField]
    GameObject currentLantern;
    ActiveItem lanternState;

    Renderer rend;
    LanternLightMaterial currentLightning;
    public bool isChanged;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material = EffectNull;
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

        Debug.Log(lanternState.m_ObjectState);

        if ( lanternState.m_ObjectState == ObjectState.Shadow )
        {
                rend.material = EffectShadow;
                rend.enabled = true;
        }
        else if ( lanternState.m_ObjectState == ObjectState.NoState )
        {
                rend.material = EffectNull;
                rend.enabled = false;
        }
        isChanged = false;
    }
}
