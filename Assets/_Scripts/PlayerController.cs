using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour 
{

    Animator playerAnim;

	//basic movement
	public float JumpHeight;
	public float MoveSpeed;
    public float RunSpeed;
    public float WalkSpeed;
	public float maxVelocity = 120f;
	public Rigidbody player;
    public GameObject raySpawn;

	//is the player dashing?
	public bool dash;
	//how long can dash last=
	public float timer;
	//does dash boost the player's speed?
	public float DashSpeed;


	public LayerMask whatIsGround;
	public bool grounded;
	public float distanceRay;



	// Use this for initialization
	void Start()
	    {
            playerAnim = GetComponent<Animator>();
			dash = false;
			player = GetComponent<Rigidbody>();
			timer = 0;

			//script = GameObject.Find ("DoubleJumpCheckPoint").GetComponent<GetDoublejump>();

		    //nextFire = Time.time;
		}
		
	void FixedUpdate()
		{
            Debug.Log(player.velocity);

			RaycastHit rayOut;
			//grounded = Physics.SphereCast(player.transform.position, -transform.up, out rayOut, distanceRay, whatIsGround );
            grounded = Physics.SphereCast(raySpawn.transform.position, 0.5f , -transform.up, out rayOut, distanceRay, whatIsGround);

        //Kontrollerer max farten spilleren kan ha for å hindre tullete sterke dash boosts
            if (player.velocity.magnitude > maxVelocity)
            {
                player.velocity = Vector3.ClampMagnitude(player.velocity, maxVelocity);
                
            }
	    }

	// Update is called once per frame
	void Update()
	    {
            
		//player.AddForce (Vector3.down * 100f); //(Implimenter etter vi har en grounded check)
		if (Input.GetKey (KeyCode.A) && dash == false)
		{
			//transform.Translate((-transform.forward) * MoveSpeed * Time.deltaTime, Space.World);
            playerAnim.SetFloat("Speed", MoveSpeed);
            if (transform.rotation != Quaternion.Euler(0, -90, 0))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            player.AddForce(transform.forward * MoveSpeed);
			//SpeedLimiter ();

		}
        if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetFloat("Speed", 0f);
        }


        if (Input.GetKey(KeyCode.D) && dash == false) 
		{
			//transform.Translate ((transform.forward) * MoveSpeed * Time.deltaTime, Space.World);
            playerAnim.SetFloat("Speed", MoveSpeed);
            if (transform.rotation != Quaternion.Euler(0, 90, 0))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            player.AddForce(transform.forward * MoveSpeed);
 

		}

		if (Input.GetKeyDown (KeyCode.Q) && dash == false) 
		{
			timer = 40;
			//MoveSpeed = MoveSpeed + DashSpeed;
            if (transform.rotation == Quaternion.Euler(0, 90, 0))
            {
                player.AddForce(-transform.forward * (MoveSpeed+DashSpeed), ForceMode.VelocityChange);
                playerAnim.SetBool("DashBackward", true);
                
            }
            else
            {
                player.AddForce(transform.forward * (MoveSpeed + DashSpeed), ForceMode.VelocityChange);
                playerAnim.SetBool("DashForward", true);
            }

			//insert animation code

		}
		if (Input.GetKeyDown (KeyCode.E) && dash == false) 
		{
			timer = 40  ;
			//MoveSpeed = MoveSpeed + DashSpeed;
            if (transform.rotation == Quaternion.Euler(0, -90, 0))
            {
                player.AddForce(-transform.forward * (MoveSpeed + DashSpeed), ForceMode.VelocityChange);
                playerAnim.SetBool("DashBackward", true);
            }
            else
            {
                player.AddForce(transform.forward * (MoveSpeed + DashSpeed), ForceMode.VelocityChange);
                playerAnim.SetBool("DashForward", true);
            }

			//insert animation code
            

		}
		//counts down the duration of the dash
		if (timer > 0)
		{
			dash = true;
			--timer;
			//SpeedLimiter ();
		}
		//ends the dash once the timer reaches 0
		if (timer <= 0 && dash)
		{
			dash = false;
			//MoveSpeed = MoveSpeed - DashSpeed;
			//insert end animation code
		
		}


		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
            playerAnim.SetBool("Jump",true);


			player.velocity = new Vector3 (GetComponent<Rigidbody> ().velocity.x, JumpHeight);


		}

		if (player != grounded)
		{
			player.AddForce (Vector3.down * 80f); //(Implimenter etter vi har en grounded check)
		}
		/*
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			player.velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, JumpHeight);

        }
*/
        if(player.velocity.y == 0)
        {
            playerAnim.SetBool("Landing", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			MoveSpeed = RunSpeed;
            DashSpeed = DashSpeed / 4;

		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			MoveSpeed = WalkSpeed;
            DashSpeed = DashSpeed * 4;
		}


		if (Input.GetKey("escape"))
		 {
			Application.Quit();
		 }

		//	Debug.Log ("velocity " + player.velocity.sqrMagnitude);
        
	}
    void LateUpdate()
    {
        playerAnim.SetBool("Jump", false);
        playerAnim.SetBool("DashForward", false);
        playerAnim.SetBool("DashBackward", false);
        playerAnim.SetBool("Landing", false);

    }

    /*
	void SpeedLimiter()
	{
		if (player.velocity.sqrMagnitude > maxVelocity)
		{
			var diff = player.velocity.sqrMagnitude - maxVelocity;

			var opposite = player.velocity.normalized * diff;
			player.AddForce(new Vector3(-opposite.x, 0, 0));
		}
	}
     */
}