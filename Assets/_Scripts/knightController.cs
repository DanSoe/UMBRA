using UnityEngine;
using System.Collections;

public class knightController : MonoBehaviour
{

    private PlayerController player;


    public float moveSpeed;
    public Rigidbody body;

    public int maxHealth = 3;
    public int curHealth;
    float invtime;

    public BoxCollider attackTrigger;

    public GameObject target;
    public float targetdist;
    //public float rayDist;
    public LayerMask WhatIsEnemy;
    public LayerMask whereWalk;
    public LayerMask obstacle;
    public bool chase;
    public bool rCont;
    public bool lCont;
    public bool stuff;
    public bool ground;
    public float maxVel;
    bool move;

    private float turnTimer;

    private Vector3 rayoffset;

    public float eneDist;
    public float atDist;
    public float chaseDist;
    Animator Anim;

    private Vector3 temp2;
    private Vector3 temp1;
    Vector3 Movement;
    bool buildupMovement;
    float curSpeed;

    BoxCollider sword;
    CapsuleCollider torso;

    // Use this for initialization
    void Start()
    {
        chase = false;
        attackTrigger.enabled = false;
        Anim = GetComponent<Animator>();

        curHealth = maxHealth;

        rayoffset = new Vector3(0, 3, 0);

        //for rotating raycast
        Vector3 noAngle = body.transform.up;
        //Quaternion spreadAngle = Quaternion.AngleAxis(45, new Vector3(0, 0, 1));
        //Quaternion spreadAngle2 = Quaternion.AngleAxis(-45, new Vector3(0, 0, 1));
        Quaternion spreadAngle = Quaternion.Euler(0, 0, 45);
        Quaternion spreadAngle2 = Quaternion.Euler(0, 0, -45);
        temp2 = spreadAngle * noAngle;
        temp1 = spreadAngle2 * noAngle;

        Anim.SetFloat("Life", curHealth);

        sword = body.GetComponentInChildren<BoxCollider>();
        torso = body.GetComponent<CapsuleCollider>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void awake()
    {
        //target = GameObject.FindGameObjectWithTag("Player").GetComponent;
        /*Physics.IgnoreLayerCollision(11, 12, true);
        Physics.IgnoreLayerCollision(11, 11, true);*/

    }

    IEnumerator wait(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void Update()
    {

        Anim.SetFloat("Speed", curSpeed);

        eneDist = Vector3.Distance(body.position, target.transform.position);



        if (eneDist < atDist && chase == true && Anim.GetCurrentAnimatorStateInfo(0).IsName("shield hit") == false)
        {
            move = false;
            Anim.SetBool("Attack", true);
            maxVel = 0f;
            Anim.SetFloat("Speed", 0f);
            //attackTrigger.enabled = true;
            //StartCoroutine(wait(2));
        }
        else if (eneDist > atDist && chase == true)
        {
            move = true;
            maxVel = 12f;

        }
        else
        {
            move = true;

            Anim.SetBool("Attack", false);
            maxVel = 5f;
            Anim.SetFloat("Speed", curSpeed);
            attackTrigger.enabled = false;
        }
        Movement = transform.forward * moveSpeed;


    }
    void FixedUpdate()
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") == false && Anim.GetCurrentAnimatorStateInfo(0).IsName("Death") == false && Anim.GetCurrentAnimatorStateInfo(0).IsName("backhit") == false && Anim.GetCurrentAnimatorStateInfo(0).IsName("shield hit") == false)
        {
            if (ground == true)
            {
                if (move)
                {
                    //body.AddForce(Movement, ForceMode.VelocityChange);
                    body.AddForce(Movement);
                    if (body.velocity.magnitude > maxVel)
                    {
                        body.velocity = Vector3.ClampMagnitude(body.velocity, maxVel);

                    }
                }
                if (lCont == false && turnTimer == 0 || rCont == false && turnTimer == 0 || stuff == true && turnTimer == 0)
                {
                    turnTimer = 50;
                    body.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
                    //body.AddForce(Movement, ForceMode.VelocityChange);

                }

            }
        }

        curSpeed = body.velocity.magnitude;

        RaycastHit rayOut;

        // detecting if the player is in front of the knight.
        chase = Physics.Raycast(body.transform.position + rayoffset, transform.forward, out rayOut, targetdist, WhatIsEnemy);
        //Debug.DrawRay(body.transform.position + rayoffset, transform.forward, Color.cyan, 10, false);

        // detecting if there is surface to walk on in fron of the knight.
        rCont = Physics.Raycast(body.transform.position + rayoffset, -temp2, out rayOut, 4.55f, whereWalk);
        //Debug.DrawRay(body.transform.position + rayoffset, -temp2, Color.green, 10, false);

        lCont = Physics.Raycast(body.transform.position + rayoffset, -temp1, out rayOut, 4.55f, whereWalk);
        //Debug.DrawRay(body.transform.position + rayoffset, -temp1, Color.green, 10, false);
        ground = Physics.Raycast(body.transform.position, -transform.up, out rayOut, 0.25f, whereWalk);

        // detecting if anything is in the knights path.
        stuff = Physics.Raycast(body.transform.position + new Vector3(0, 1, 0), transform.forward, out rayOut, 3f, obstacle);
        //Debug.DrawRay(body.transform.position + new Vector3(0, 1, 0), transform.forward, Color.yellow, 10, false);

        if (lCont == false && turnTimer == 0 || rCont == false && turnTimer == 0 || stuff == true && turnTimer == 0)
        {
            turnTimer = 50;
            body.transform.rotation = Quaternion.AngleAxis(180, transform.up) * transform.rotation;
            //body.AddForce(Movement, ForceMode.VelocityChange);

        }

        if (turnTimer > 0)
        {
            turnTimer--;
        }
        if (invtime > 0)
        {
            invtime--;
        }
        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
        if (curHealth <= 0)
        {

            sword.enabled = false;
            torso.enabled = false;
            Anim.SetBool("Attack", false);
            move = false;
            maxVel = 0;
            body.velocity = Vector3.ClampMagnitude(body.velocity, maxVel);
            Destroy(this.gameObject, 2.55f);

        }




    }
    public void takeDamage(int dmg, int mode)
    {

        if (invtime <= 0)
        {

            if (mode == 1)
            {
                Anim.SetTrigger("BeenHit");
            }
            else if (mode == 2)
            {
                Anim.SetTrigger("BackHit");
            }
            invtime = 100;
            curHealth -= dmg;
            Anim.SetFloat("Life", curHealth);
            //playerAnim.SetBool("TakeDamage", true);
            Debug.Log(curHealth);


        }
    }
    /*public void hitAnim()
    {
        if (chase == true)
        {
            Anim.SetBool("Hit", true);
            
        }
        else
        {
            Debug.Log("ahhh that hurts");
            Anim.SetTrigger("BeenHit");
            
        }
    }*/
    void LateUpdate()
    {



    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword" && chase == true)
        {
            invtime = 2;
            curHealth -= 1;
            Anim.SetBool("SheildHit", true);
        }

        if (other.tag == "Sword" && chase == false)
        {
            invtime = 2;
            curHealth -= 2;
            Anim.SetBool("Hit", true);
        }
    }*/
    public IEnumerator Knockback(float knockDur, float knockbackPower, Vector3 knockbackDir, Vector3 targetPosition)
    {
        float timer = 0;

        while (knockDur > timer)
        {
            timer += Time.deltaTime;
            if (transform.position.x < targetPosition.x)
            {
                body.AddForce(new Vector3(-10000, knockbackPower, 0));
            }
            else if (transform.position.x > targetPosition.x)
            {
                body.AddForce(new Vector3(10000, knockbackPower, 0));
            }
        }
        yield return 0;
    }
}
