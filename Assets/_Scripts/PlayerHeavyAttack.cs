using UnityEngine;
using System.Collections;
//using PlayerAttack;

public class PlayerHeavyAttack : MonoBehaviour
{
    
    Animator playerAnim;
    public static bool attacking = false;

    private float attackTimer = 0;
    private float attackCooldown = 1.33f;

    public BoxCollider heavyAttackTrigger;  


    void Awake()
    {
        playerAnim = GetComponentInParent<Animator>();
        heavyAttackTrigger.enabled = false;
       // playerAnim.SetBool("CanAttack", false);

    }

    
    void Update()
    {
        if (Input.GetButton("HAttack" )/*(Input.GetKeyDown("g")*/ && !attacking && PlayerAttack.attacking == false) 
        {
            attacking = true;
            attackTimer = attackCooldown;
            playerAnim.SetBool("HeavyAttack", attacking);
            heavyAttackTrigger.enabled = true;
           // playerAnim.SetBool("CanAttack", false);
        }

        if (attacking)
        {
            if (attackTimer < 0.2)
            {
                playerAnim.SetBool("HeavyAttack", false);
            }

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                //playerAnim.SetBool("HeavyAttack", attacking);
                heavyAttackTrigger.enabled = false;
            }
        }
        if(attackTimer < 0)
        {
            attackTimer = 0;
          //  playerAnim.SetBool("CanAttack", true);
        }
    }
}
