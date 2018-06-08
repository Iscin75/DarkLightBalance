using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_Able : MonoBehaviour {

    [SerializeField]
    GameObject Cylinder;

    public bool isOpening;



	// Use this for initialization
	void Start () {
        isOpening = false;
	}
	
	// Update is called once per frame
	void Update () {
		if( isOpening )
        {
            Cylinder.SetActive(false);
            //joue avec le cylindre
        }
	}

    void OnTriggerEnter( Collider other)
    {
      
        if( other.gameObject.CompareTag("DoorActivation"))
        {
            Debug.Log(other.gameObject.name);
            isOpening = true;
        }
    }

}
