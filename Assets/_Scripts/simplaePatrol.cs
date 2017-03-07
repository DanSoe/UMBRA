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
        Vector3 noAngle = stillground.forward;
        Quaternion spreadAngle = Quaternion.AngleAxis(45, new Vector3(0, distanceRay, 0));
        temp2 = spreadAngle * noAngle;
        //stillground = body.GetComponentInChildren < 1 > ();


    }

    void FixedUpdate()
    {

        RaycastHit rayOut;
        groundHere = Physics.Raycast(stillground.transform.position, -temp2, out rayOut, distanceRay, whatIsGround);
        Debug.DrawRay(stillground.transform.position, -temp2,Color.cyan, 10, false);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
