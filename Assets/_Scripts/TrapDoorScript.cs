using UnityEngine;
using System.Collections;

public class TrapDoorScript : MonoBehaviour
{
    Animator anim;
    public BoxCollider left;
    public BoxCollider right;

    public BoxCollider Main;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator OnTriggerEnter(Collider trapdoor)
    {
        if ((trapdoor.gameObject.tag == "Player"))
        {
            Main.enabled = false;
            anim.SetBool("TrapActivator", true);
            yield return new WaitForSeconds(2);
            left.enabled = false;
            right.enabled = false;
        }
    }
}
