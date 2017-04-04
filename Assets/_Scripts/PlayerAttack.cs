using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour 
{
    Animator playerAnim;
	public bool attacking = false;

	private float attackTimer = 0;
	private float attackCooldown = 0.3f;

	public BoxCollider attackTrigger;


	void Awake()
	{
        playerAnim = GetComponentInParent<Animator>();
		attackTrigger.enabled = false;
		
	}


	void Update () 
	{
		if (Input.GetKeyDown("f") && !attacking)
		{
			attacking = true;
			attackTimer = attackCooldown;
            playerAnim.SetBool("LightAttack", attacking);
			attackTrigger.enabled = true;
		}

		if (attacking) 
		{
			if (attackTimer > 0) 
			{
				attackTimer -= Time.deltaTime;
			} 
			else 
			{
				attacking = false;
                playerAnim.SetBool("LightAttack", attacking);
				attackTrigger.enabled = false;
			}
		}
	
	}
}
