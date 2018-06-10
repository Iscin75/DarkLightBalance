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
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collide");
            anim.SetBool("isOpen",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collide");
            anim.SetBool("isOpen", false);
        }
    }
}
