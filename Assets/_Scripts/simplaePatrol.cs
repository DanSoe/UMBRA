using UnityEngine;
using System.Collections;

public class simplaePatrol : MonoBehaviour {

    private GameObject body;
    public float moveSpeed;
    private Transform stillground;
	// Use this for initialization
	void Start ()
    {
        body = GameObject.Find(this);
        stillground = body.GetComponentInChildren < 1 > ();
        
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
