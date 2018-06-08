using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternLightMaterial : MonoBehaviour
{
    [SerializeField]
    GameObject currentLantern;

    LanternState lanternState;
    
    public bool isChanged;

    // Use this for initialization
    void Start()
    {
        isChanged = false;
        gameObject.SetActive(false);
        lanternState = currentLantern.GetComponent<LanternState>();
    }

    private void OnEnable()
    {
        GameManager.Instance.EmptyPowerBarEvent += SwitchOffLight;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            change();
        }
    }

    public void change()
    {
        if (lanternState.m_ObjectState == ObjectState.NoState)
        {
            SwitchOnLight();
        }
        else if (lanternState.m_ObjectState == ObjectState.Shadow)
        {
            SwitchOffLight();
        }
        isChanged = false;
    }

    void SwitchOffLight()
    {
        //gameObject.SetActive(false);
        //Debug.Log(lanternState.m_ObjectState);
        lanternState.m_ObjectState = ObjectState.NoState;

    }

    void SwitchOnLight()
    {
        //gameObject.SetActive(true);
        //Debug.Log(lanternState.m_ObjectState);
        lanternState.m_ObjectState = ObjectState.Shadow;
    }
}
