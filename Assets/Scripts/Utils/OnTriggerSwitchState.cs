using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerSwitchState : MonoBehaviour {

    [SerializeField]
    GameObject FalseWall;
    [SerializeField]
    GameObject WallToChangeMaterial;

    [SerializeField]
    Material beforeMat;
    [SerializeField]
    Material afterMat;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            
            FalseWall.gameObject.SetActive(!FalseWall.gameObject.activeSelf);
            if ( FalseWall.gameObject.activeSelf )
                WallToChangeMaterial.GetComponent<Renderer>().material = beforeMat;
            else
                WallToChangeMaterial.GetComponent<Renderer>().material = afterMat;
        }
    }
}
