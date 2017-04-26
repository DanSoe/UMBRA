using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour 
{
   // Animator playerAnim;
    private PlayerController player; 


	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
       // playerAnim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnTriggerEnter(Collider playerTouch)
    {
        //Debug.Log(playerTouch.gameObject.name);
        if (gameObject.tag == "HealingOrb")
        {
            if (playerTouch.gameObject.tag == "Player")
            {
                if (player.curHealth < 5)
                {
                    player.curHealth++;
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);

                }
            }
            /*
            if (playerTouch.gameObject.tag == "Player")
            {
                Debug.Log("One Damage");
                Destroy(hittarget.gameObject);
            }
             * */
        }
    }
}
