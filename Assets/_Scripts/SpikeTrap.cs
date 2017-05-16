using UnityEngine;
using System.Collections;

public class SpikeTrap : MonoBehaviour
{
    Animator animator;
    // Use this for initialization
    void Start()
    {
        if (!animator) 
        { 
            animator = transform.GetComponentInChildren<Animator>();
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider spikes)
    {
        if((spikes.gameObject.tag == "Player"))
        {
            animator.SetBool("TrapActivator", true);
        }
    }
    void OnTriggerExit(Collider exit)
    {
        if ((exit.gameObject.tag == "Player"))
        {
            animator.SetBool("TrapActivator", false);
        }
    }

}
