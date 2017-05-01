using UnityEngine;
using System.Collections;

public class GhoulController : MonoBehaviour 
{
    private PlayerController player;
    Animator playerAnim;
    public Rigidbody ghoul;


	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerAnim = GetComponent<Animator>();
        ghoul = GetComponent<Rigidbody>();
	
	}
	

	void Update () 
    {
	
	}
    
    void OnCollisionEnter(Collision ghoul)
    {
        if (ghoul.gameObject.CompareTag("Player"))
        {
            player.takeDamage(1);
            StartCoroutine(player.Knockback(0.02f, 20, player.transform.position, transform.position));
            
            
            
        }

    }
}
