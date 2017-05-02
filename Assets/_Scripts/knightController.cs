using UnityEngine;
using System.Collections;

public class knightController : MonoBehaviour
{

    private PlayerController player;


    public float moveSpeed;
    public Rigidbody body;

    float maxHealt;
    float curHealt;
    float invtime;

    public BoxCollider attackTrigger;

    public GameObject target;
    public float targetdist;
    public float rayDist;
    public LayerMask WhatIsEnemy;
    public LayerMask whereWalk;
    public LayerMask obstacle;
    public bool chase;
    public bool rCont;
    public bool lCont;
    public bool stuff;

    private float turnTimer;

    private Vector3 rayoffset;

    public float eneDist;
    Animator Anim;

    private Vector3 temp2;
    private Vector3 temp1;

    // Use this for initialization
    void Start()
    {
        Anim = GetComponent<Animator>();

        maxHealt = 3;
        curHealt = maxHealt;

        rayoffset = new Vector3(0, 3, 0);

        //for rotating raycast
        Vector3 noAngle = body.transform.forward;
        Quaternion spreadAngle = Quaternion.AngleAxis(135, new Vector3(0, 0, 1));
        Quaternion spreadAngle2 = Quaternion.AngleAxis(45, new Vector3(0, 0, 1));
        temp2 = spreadAngle * noAngle;
        temp1 = spreadAngle2 * noAngle;
    }

    void awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetFloat("Speed", moveSpeed);




        eneDist = Vector3.Distance(body.position, target.transform.position);

        if (eneDist < 5f && chase == true)
        {
            Anim.SetBool("Attack", true);
            moveSpeed = 0f;
            Anim.SetFloat("Speed", 0f);
            attackTrigger.enabled = true;
        }
        else if (eneDist > 5f && chase == true)
        {
            moveSpeed = 9f;
        }
        else
        {
            Anim.SetBool("Attack", false);
            moveSpeed = 6f;
            Anim.SetFloat("Speed", moveSpeed);
            attackTrigger.enabled = false;
        }

    }
    void FixedUpdate()
    {
        body.velocity = transform.forward * moveSpeed;
        RaycastHit rayOut;

        // detecting if the player is in front of the knight.
        chase = Physics.Raycast(body.transform.position + rayoffset, transform.forward, out rayOut, targetdist, WhatIsEnemy);
        Debug.DrawRay(body.transform.position + rayoffset, transform.forward, Color.cyan, 10, false);

        // detecting if there is surface to walk on in fron of the knight.
        rCont = Physics.Raycast(body.transform.position + rayoffset, -temp2, out rayOut, rayDist, whereWalk);
        Debug.DrawRay(body.transform.position + rayoffset, -temp2, Color.green, 10, false);

        lCont = Physics.Raycast(body.transform.position + rayoffset, -temp1, out rayOut, rayDist, whereWalk);
        Debug.DrawRay(body.transform.position + rayoffset, -temp1, Color.green, 10, false);
        // detecting if anything is in the knights path.
        stuff = Physics.Raycast(body.transform.position + new Vector3(0, 1, 0), transform.forward, out rayOut, 3f, obstacle);
        Debug.DrawRay(body.transform.position + new Vector3(0, 1, 0), transform.forward, Color.yellow, 10, false);

        if (lCont == false && turnTimer == 0 || rCont == false && turnTimer == 0 || stuff == true && turnTimer == 0)
        {
            turnTimer = 10;
            body.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;

        }

        if (turnTimer > 0)
        {
            turnTimer--;
        }
        if (invtime > 0)
        {
            invtime--;
        }


    }
    void LateUpdate()
    {
        Anim.SetBool("SheildHit", false);
        Anim.SetBool("Hit", false);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword" && chase == true)
        {
            invtime = 3;
            curHealt -= 1;
            Anim.SetBool("SheildHit", true);
        }

        if (other.tag == "Sword" && chase == false)
        {
            invtime = 3;
            curHealt -= 2;
            Anim.SetBool("Hit", true);
        }
    }
}
