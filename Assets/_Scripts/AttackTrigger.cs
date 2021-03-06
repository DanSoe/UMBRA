﻿using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour
{
    private knightController enemyKnight;
    private GhoulController enemyGhoul;

    // Use this for initialization
    void Start()
    {
        
      //  enemyKnight = GameObject.FindGameObjectWithTag("Knight").GetComponent<knightController>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider hittarget)
    {
        //Debug.Log(hittarget.gameObject.name);
        if (gameObject.tag == "lightA")
        {
            if (hittarget.gameObject.tag == "ghoul")
            {
                enemyGhoul = hittarget.GetComponent<GhoulController>();
                Debug.Log("One Damage");
                enemyGhoul.takeDamage(1);
                StartCoroutine(enemyGhoul.Knockback(0.03f, 5000, enemyGhoul.transform.position, transform.position));

            }
            if (hittarget.gameObject.tag == "Knight")
            {
                enemyKnight = hittarget.GetComponent<knightController>();
                if (enemyKnight.chase == true)
                {
                    enemyKnight.takeDamage(1,1);
                    Debug.Log("1 dmg");
                    //enemyKnight.hitAnim();
                    StartCoroutine(enemyKnight.Knockback(0.02f, 5000, enemyKnight.transform.position, transform.position));
                }
                else
                {
                    enemyKnight.takeDamage(2,2);
                    Debug.Log("2dmg");
                    //enemyKnight.hitAnim();
                    StartCoroutine(enemyKnight.Knockback(0.02f, 5000, enemyKnight.transform.position, transform.position));
                }
            }
        }
        else
        {
            if (hittarget.gameObject.tag == "ghoul")
            {
                enemyGhoul = hittarget.GetComponent<GhoulController>();
                Debug.Log("Two Damage");
                enemyGhoul.takeDamage(1);
                StartCoroutine(enemyGhoul.Knockback(0.02f, 1750, enemyGhoul.transform.position, transform.position));
            }
            if (hittarget.gameObject.tag == "Knight")
            {
                enemyKnight = hittarget.GetComponent<knightController>();

                if (enemyKnight.chase == true)
                {
                    enemyKnight.takeDamage(2,1);
                    //enemyKnight.hitAnim();
                    StartCoroutine(enemyKnight.Knockback(0.02f, 2000, enemyKnight.transform.position, transform.position));
                }
                else
                {
                    enemyKnight.takeDamage(4,2);
                    //enemyKnight.hitAnim();
                    StartCoroutine(enemyKnight.Knockback(0.02f, 2000, enemyKnight.transform.position, transform.position));
                }
                

            }

        }
    }
}
