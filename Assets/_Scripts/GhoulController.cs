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
    bool move;

    //enemy detection
    public bool chase;
    public bool inFront;
    public LayerMask WhatIsEnemy;
    private GameObject target;
    public float targetdist;
    //float eneDist;

    //Div Variables
    bool IsAlive;
    public float curSpeed;

    CapsuleCollider torso;
    BoxCollider[] hands;


    void Start () 
    {
        target = GameObject.FindGameObjectWithTag("Player");
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

        // starting idle animation at random time


        playerAnim.Play("Idle", 0 ,Random.value);

        torso = ghoul.GetComponent<CapsuleCollider>();
        hands = ghoul.GetComponentsInChildren<BoxCollider>();

    }

    void Awake()
    {
        //Physics.IgnoreLayerCollision(12, 11, true);
        Physics.IgnoreLayerCollision(12, 12, true);
    }
	

	void Update () 
    {

        //Debug.Log(ghoul.velocity.magnitude);
        //Debug.Log(curSpeed);
    }

    void FixedUpdate()
    {

        //eneDist = Vector3.Distance(ghoul.position, target.transform.position);
        playerAnim.SetFloat("Speed", ghoul.velocity.magnitude);
        curSpeed = ghoul.velocity.magnitude;
        RaycastHit rayOut;

        // detecting if the player is in front of the knight.
        chase = Physics.Raycast(ghoul.transform.position + rayoffset, transform.forward, out rayOut, targetdist, WhatIsEnemy);
        //Debug.DrawRay(ghoul.transform.position + rayoffset, transform.forward, Color.cyan, 10, false);
        inFront = Physics.Raycast(ghoul.transform.position + rayoffset, transform.forward, out rayOut, 2.5f, WhatIsEnemy);
        //Debug.DrawRay(ghoul.transform.position + rayoffset, transform.forward, Color.black,1,true);

        // detecting if there is surface to walk on in fron of the knight.
        rCont = Physics.Raycast(ghoul.transform.position + rayoffset, -temp2, out rayOut, rayDist, whereWalk);
        //Debug.DrawRay(ghoul.transform.position + rayoffset, -temp2, Color.green, 10, false);

        lCont = Physics.Raycast(ghoul.transform.position + rayoffset, -temp1, out rayOut, rayDist, whereWalk);
        //Debug.DrawRay(ghoul.transform.position + rayoffset, -temp1, Color.green, 10, false);
       
        // detecting if anything is in the knights path.
        stuff = Physics.Raycast(ghoul.transform.position + new Vector3(0, 1, 0), transform.forward, out rayOut, 3f, obstacle);
        //Debug.DrawRay(ghoul.transform.position + new Vector3(0, 1, 0), transform.forward, Color.yellow, 10, false);
        

        // movement
        movement = transform.forward * moveSpeed;
        //ghoul.AddForce(movement, ForceMode.VelocityChange);
        

       

        if (chase == true && inFront == true)
        {
            move = false;
            playerAnim.SetBool("Attack", true);
        }
        else if (chase == true)
        {
            maxVel = 5f;
            move = true;
        }
        else
        {
            move = true;
            maxVel = 3f;
            playerAnim.SetBool("Attack", false);
        }

        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack") == false && playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Death") == false)
        {
            if (move)
            {
                ghoul.AddForce(movement);
                if (ghoul.velocity.magnitude > maxVel)
                {
                    ghoul.velocity = Vector3.ClampMagnitude(ghoul.velocity, maxVel);

                }
                if (lCont == false && turnTimer == 0 || rCont == false && turnTimer == 0 || stuff == true && turnTimer == 0)
                {
                    turnTimer = 50;
                    ghoul.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
                    //body.AddForce(Movement, ForceMode.VelocityChange);

                }

            }
        }

        if (turnTimer > 0)
        {
            turnTimer--;
        }
        
        if (IsAlive == false)
        {

            move = false;
            playerAnim.SetBool("IsAlive", IsAlive);
            playerAnim.SetBool("Attack", false);
            torso.enabled = false;
            hands[0].enabled = false;
            hands[1].enabled = false;
            ghoul.velocity = Vector3.ClampMagnitude(ghoul.velocity, maxVel);
            maxVel = 0;
            
            ghoul.useGravity = false;

            
            if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Death") == false)
            {
                
                Destroy(this.gameObject, 1.5f);
                

            }
        }


    }
    public void takeDamage(int dmg)
    {
        IsAlive = false;
        

    }
    void OnCollisionEnter(Collision ghoul)
    {
        /*if (ghoul.gameObject.CompareTag("Player"))
        {
            player.takeDamage(1);
            StartCoroutine(player.Knockback(0.02f, 1750, player.transform.position, transform.position));
            
            
            
        }*/

    }
    public IEnumerator Knockback(float knockDur, float knockbackPower, Vector3 knockbackDir, Vector3 targetPosition)
    {
        float timer = 0;
        float dist = 15000;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            if (transform.position.x < targetPosition.x)
            {
                ghoul.AddForce(new Vector3(-dist, knockbackPower, 0));
            }
            else if (transform.position.x > targetPosition.x)
            {
                ghoul.AddForce(new Vector3(dist, knockbackPower, 0));
            }
        }
        yield return 0;
    }
}
