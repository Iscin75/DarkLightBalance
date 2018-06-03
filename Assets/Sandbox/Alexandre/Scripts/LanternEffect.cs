using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternEffect : MonoBehaviour {

    public Material EffectNull;
    public Material EffectLight;
    public Material EffectShadow;

    Renderer rend;
    GameObject room;
    LanternLightMaterial currentLightning;
    public bool isChanged;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material = EffectNull;
        rend.enabled = false;
        isChanged = false;
        room = GameObject.Find("Level");
    }
	
	// Update is called once per frame
	void Update () {
		if( isChanged )
            change();

	}

    void change()
    {
        currentLightning = transform.parent.GetComponentInChildren<LanternLightMaterial>();

        Debug.Log(room.tag);
        Debug.Log(currentLightning.getCurrentColor());

        if ( currentLightning.getCurrentColor() == currentLightning.materialLight.GetColor("_TintColor"))
        {
            rend.enabled = false;
            if ( room.tag == "Shadow_Room")
            {
                rend.material = EffectShadow;
                rend.enabled = true;
            }
        }
        else if ( currentLightning.getCurrentColor() == currentLightning.materialShadow.GetColor("_TintColor"))
        {
            rend.enabled = false;
            if (room.tag == "Light_Room")
            {
                rend.material = EffectLight;
                rend.enabled = true;
            }
        }
        else if ( currentLightning.getCurrentColor() == currentLightning.materialNull.GetColor("_TintColor"))
        {
            rend.material = EffectNull;
            rend.enabled = false;
        }
        isChanged = false;
    }
}
