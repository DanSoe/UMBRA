using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
    Animator playerAnim;
	public static bool attacking = false;

	private float attackTimer = 0;
	private float attackCooldown = 1.0f;

	public BoxCollider attackTrigger;


	void Awake()
	{
        playerAnim = GetComponentInParent<Animator>();
		attackTrigger.enabled = false;
      //  playerAnim.SetBool("CanAttack", false);
		
	}


	void Update () 
	{
       // Debug.Log(attacking);
		if (Input.GetKeyDown("f") && !attacking && PlayerHeavyAttack.attacking == false)
		{
			attacking = true;
			attackTimer = attackCooldown;
          //  playerAnim.SetBool("CanAttack", false);
            playerAnim.SetBool("LightAttack", attacking);
			attackTrigger.enabled = true;
            
		}

		if (attacking) 
		{
            if (attackTimer < 0.2)
            {
                playerAnim.SetBool("LightAttack", false);
            }
            
			if (attackTimer > 0) 
			{
				attackTimer -= Time.deltaTime;
			} 
			else 
			{
                
				attacking = false;
                
                //playerAnim.SetBool("LightAttack", attacking);
				attackTrigger.enabled = false;
			}
		}
        if (attackTimer < 0)
        {
            attackTimer = 0;
        //    playerAnim.SetBool("CanAttack", true);
        }
	
	}

}
