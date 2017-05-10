using UnityEngine;
using System.Collections;

public class GhoulController : MonoBehaviour 
{
    private PlayerController player;
    Animator playerAnim;
    public Rigidbody ghoul;

    // Raycast variables
    public float rayDist;
    public LayerMask whereWalk;
    public LayerMask obstacle;
    public bool rCont;
    public bool lCont;
    public bool stuff;
    private Vector3 temp2;
    private Vector3 temp1;
    private Vector3 rayoffset;

    //movement
    Vector3 movement;
    public float moveSpeed;
    float turnTimer;
    public float maxVel;

    //enemy detection
    public bool chase;
    public LayerMask WhatIsEnemy;
    public GameObject target;
    public float targetdist;

    //Div Variables
    bool IsAlive;
    public float curSpeed;

    void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerAnim = GetComponent<Animator>();
        ghoul = GetComponent<Rigidbody>();

        //Raycasting for wallk 
        rayoffset = new Vector3(0, 3, 0);

        Vector3 noAngle = ghoul.transform.up;
        //Quaternion spreadAngle = Quaternion.AngleAxis(45, new Vector3(0, 0, 1));
        //Quaternion spreadAngle2 = Quaternion.AngleAxis(-45, new Vector3(0, 0, 1));
        Quaternion spreadAngle = Quaternion.Euler(0, 0, 45);
        Quaternion spreadAngle2 = Quaternion.Euler(0, 0, -45);
        temp2 = spreadAngle * noAngle;
        temp1 = spreadAngle2 * noAngle;

        //curSpeed = ghoul.velocity.magnitude;
        IsAlive = true;
        playerAnim.SetBool("IsAlive", IsAlive);
        
    }

    void Awake()
    {
        /*Physics.IgnoreLayerCollision(12, 11, true);
        Physics.IgnoreLayerCollision(12, 12, true);*/
    }
	

	void Update () 
    {

        //Debug.Log(ghoul.velocity.magnitude);
        Debug.Log(curSpeed);
    }

    void FixedUpdate()
    {
        playerAnim.SetFloat("Speed", ghoul.velocity.magnitude);
        curSpeed = ghoul.velocity.magnitude;
        RaycastHit rayOut;

        // detecting if the player is in front of the knight.
        chase = Physics.Raycast(ghoul.transform.position + rayoffset, transform.forward, out rayOut, targetdist, WhatIsEnemy);
        //Debug.DrawRay(ghoul.transform.position + rayoffset, transform.forward, Color.cyan, 10, false);

        // detecting if there is surface to walk on in fron of the knight.
        rCont = Physics.Raycast(ghoul.transform.position + rayoffset, -temp2, out rayOut, rayDist, whereWalk);
        Debug.DrawRay(ghoul.transform.position + rayoffset, -temp2, Color.green, 10, false);

        lCont = Physics.Raycast(ghoul.transform.position + rayoffset, -temp1, out rayOut, rayDist, whereWalk);
       // Debug.DrawRay(ghoul.transform.position + rayoffset, -temp1, Color.green, 10, false);
        // detecting if anything is in the knights path.
        stuff = Physics.Raycast(ghoul.transform.position + new Vector3(0, 1, 0), transform.forward, out rayOut, 3f, obstacle);
        //Debug.DrawRay(ghoul.transform.position + new Vector3(0, 1, 0), transform.forward, Color.yellow, 10, false);

        // movement
        movement = transform.forward * moveSpeed;
        //ghoul.AddForce(movement, ForceMode.VelocityChange);
        ghoul.AddForce(movement);

        if (lCont == false && turnTimer == 0 || rCont == false && turnTimer == 0 || stuff == true && turnTimer == 0)
        {
            turnTimer = 50;
            ghoul.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
            //body.AddForce(Movement, ForceMode.VelocityChange);

        }

        if (turnTimer > 0)
        {
            turnTimer--;
        }
        if (ghoul.velocity.magnitude > maxVel)
        {
            ghoul.velocity = Vector3.ClampMagnitude(ghoul.velocity, maxVel);

        }


    }

    void OnCollisionEnter(Collision ghoul)
    {
        /*if (ghoul.gameObject.CompareTag("Player"))
        {
            player.takeDamage(1);
            StartCoroutine(player.Knockback(0.02f, 1750, player.transform.position, transform.position));
            
            
            
        }*/

    }
}
