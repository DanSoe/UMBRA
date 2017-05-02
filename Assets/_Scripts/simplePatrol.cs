using UnityEngine;
using System.Collections;

public class simplePatrol : MonoBehaviour
{


    public float moveSpeed;
    public Transform stillground;
    public Rigidbody body;

    public LayerMask whatIsGround;
    public bool groundHere;
    public float distanceRay;

    private Quaternion temp1;
    private Vector3 temp2;



    // 
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Vector3 noAngle = stillground.forward;
        Quaternion spreadAngle = Quaternion.AngleAxis(135, new Vector3(0, 0, 1));
        temp2 = spreadAngle * noAngle;
        //stillground = body.GetComponentInChildren < 1 > ();


    }

    void FixedUpdate()
    {
        body.velocity = transform.forward * moveSpeed;
        RaycastHit rayOut;
        groundHere = Physics.Raycast(stillground.transform.position, -temp2, out rayOut, distanceRay, whatIsGround);
        Debug.DrawRay(stillground.transform.position, -temp2,Color.cyan, 10, false);

         if (groundHere == false)
         {
             body.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
             Vector3 noAngle = stillground.forward;
             Quaternion spreadAngle = Quaternion.AngleAxis(135, new Vector3(0, 0, 1));
             temp2 = spreadAngle * noAngle;
         }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "edge")
        {
            body.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
        }
    }
}
