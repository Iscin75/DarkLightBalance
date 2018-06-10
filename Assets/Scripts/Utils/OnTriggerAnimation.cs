using System.Collections;
using UnityEngine;

public class OnTriggerAnimation : MonoBehaviour {

    #region Variables
    [SerializeField]
    GameObject affectedObject;
    [SerializeField]
    int desactivation_Delay;

    private Animator anim;
    #endregion


    private void Awake()
    {
        anim = affectedObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("LanternEffect"))
        {
            anim.SetBool("isOpen", true);
        }
    
    }

    private IEnumerator OnTriggerExit(Collider other)
    {
            yield return new WaitForSeconds(desactivation_Delay);
            anim.SetBool("isOpen", false);
        
    }
}
