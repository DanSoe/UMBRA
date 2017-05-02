using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour
{
    private knightController enemyKnight;

    // Use this for initialization
    void Start()
    {
        
        enemyKnight = GameObject.FindGameObjectWithTag("Knight").GetComponent<knightController>();
        enemyKnight.chase = false;

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
                Debug.Log("One Damage");

                Destroy(hittarget.gameObject);
            }
            if (hittarget.gameObject.tag == "Knight")
            {
                
                if (enemyKnight.chase == true)
                {
                    
                    enemyKnight.takeDamage(1);
                }
                else
                {
                    enemyKnight.takeDamage(2);
                    
                }
            }
        }
        else
        {
            if (hittarget.gameObject.tag == "ghoul")
            {
                Debug.Log("Two Damage");
                Destroy(hittarget.gameObject);
            }
            if (hittarget.gameObject.tag == "Knight")
            {
                if (enemyKnight.chase == true)
                {
                    enemyKnight.takeDamage(2);
                }
                else
                {
                    enemyKnight.takeDamage(4);
                }
                

            }

        }
    }
}
