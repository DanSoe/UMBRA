using UnityEngine;
using System.Collections;

public class GhoulController : MonoBehaviour 
{
    Animator playerAnim;
    public Rigidbody ghoul;


	void Start () 
    {
        playerAnim = GetComponent<Animator>();
        ghoul = GetComponent<Rigidbody>();
	
	}
	

	void Update () 
    {
	
	}
    /*
    void OnCollisionEnter(Collision ghoul)
    {
        Debug.Log(ghoul.gameObject.name);
        if (ghoul.gameObject.tag == "sword")
        {
            Debug.Log("Halla");
            Destroy(this);
            
            
            
        }

    }
    */
}
