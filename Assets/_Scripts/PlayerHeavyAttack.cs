using UnityEngine;
using System.Collections;

public class PlayerHeavyAttack : MonoBehaviour
{
    Animator playerAnim;
    public bool attacking = false;

    private float attackTimer = 0;
    private float attackCooldown = 0.7f;

    public BoxCollider heavyAttackTrigger;


    void Awake()
    {
        playerAnim = GetComponentInParent<Animator>();
        heavyAttackTrigger.enabled = false;

    }


    void Update()
    {
        if (Input.GetKeyDown("g") && !attacking)
        {
            attacking = true;
            attackTimer = attackCooldown;
            playerAnim.SetBool("HeavyAttack", attacking);
            heavyAttackTrigger.enabled = true;
            playerAnim.SetBool("CanAttack", false);
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
                playerAnim.SetBool("HeavyAttack", attacking);
                heavyAttackTrigger.enabled = false;
            }
        }
        if(attackTimer < 0)
        {
            attackTimer = 0;
            playerAnim.SetBool("CanAttack", true);
        }
    }
}
