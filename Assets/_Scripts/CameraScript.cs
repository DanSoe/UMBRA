using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
	public GameObject player;

	// Use this for initialization
	void Start () 
	{
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

    }

    // Update is called once per frame
    void Update () 
	{
       
		transform.position = new Vector3(player.transform.position.x, (player.transform.position.y+5), -70);

       
    }
}