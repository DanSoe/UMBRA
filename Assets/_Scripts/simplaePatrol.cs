using UnityEngine;
using System.Collections;

public class simplaePatrol : MonoBehaviour {

    
    public float moveSpeed;
    public Transform stillground;
    public Rigidbody body;

    public LayerMask whatIsGround;
    public bool groundHere;
    public float distanceRay;

    private Quaternion temp1;
    private Vector3 temp2;



    // Use this for initialization
    void Start ()
    {
       body = GetComponent<Rigidbody>();
       
       //stillground = body.GetComponentInChildren < 1 > ();
        
	
	}

    void FixedUpdate()
    {

        RaycastHit rayOut;
        groundHere = Physics.Raycast(stillground.transform.position, -transform.up, out rayOut, distanceRay, whatIsGround);
        Debug.DrawRay(stillground.transform.position, -transform.up,Color.cyan, distanceRay, false);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
