using System.Collections;
using UnityEngine;

public class OnTriggerAnimation : MonoBehaviour {

    [SerializeField]
    GameObject affectedObject;
    private Animator anim;


    private void Awake()
    {
        anim = affectedObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LanternEffect"))
        {
            Debug.Log("Collide");
            anim.SetBool("isOpen", true);
        }
    
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
            yield return new WaitForSeconds(10);
            Debug.Log("CollideOut");
            anim.SetBool("isOpen", false);
        
    }
}
