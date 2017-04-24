using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
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
        }
        else
        {
            if (hittarget.gameObject.tag == "ghoul")
            {
                Debug.Log("Two Damage");
                Destroy(hittarget.gameObject);
            }

        }

    }
}
