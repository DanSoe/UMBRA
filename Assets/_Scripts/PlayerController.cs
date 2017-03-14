using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour 
{
	
	//basic movement
	public float JumpHeight;
	public float MoveSpeed;
	public float maxVelocity;
	public Rigidbody player;

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
			dash = false;
			player = GetComponent<Rigidbody>();
			timer = 0;

			//script = GameObject.Find ("DoubleJumpCheckPoint").GetComponent<GetDoublejump>();

		    //nextFire = Time.time;
		}
		
	void FixedUpdate()
		{

			RaycastHit rayOut;
			grounded = Physics.Raycast(player.transform.position, -transform.up, out rayOut, distanceRay, whatIsGround );
	}

	// Update is called once per frame
	void Update()
	    {
		//player.AddForce (Vector3.down * 100f); //(Implimenter etter vi har en grounded check)
		if (Input.GetKey (KeyCode.A))
		{
			//transform.Translate((-transform.forward) * MoveSpeed * Time.deltaTime, Space.World);
			player.AddForce(-transform.forward * MoveSpeed);
			//SpeedLimiter ();

		}

		if (Input.GetKey (KeyCode.D)) 
		{
			//transform.Translate ((transform.forward) * MoveSpeed * Time.deltaTime, Space.World);
			player.AddForce(transform.forward * MoveSpeed);
			//SpeedLimiter ();

		}

		if (Input.GetKeyDown (KeyCode.Q) && dash == false) 
		{
			timer = 50;
			MoveSpeed = MoveSpeed + DashSpeed;
			player.AddForce(-transform.forward * MoveSpeed, ForceMode.VelocityChange);

			//insert animation code

		}
		if (Input.GetKeyDown (KeyCode.E) && dash == false) 
		{
			timer = 50;
			MoveSpeed = MoveSpeed + DashSpeed;
			player.AddForce(transform.forward * MoveSpeed, ForceMode.VelocityChange);

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
			MoveSpeed = MoveSpeed - DashSpeed;
			//insert end animation code
		
		}


		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{

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
		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			MoveSpeed = MoveSpeed * 2;

		}
		else if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			MoveSpeed = MoveSpeed / 2;
		}


		if (Input.GetKey("escape"))
		 {
			Application.Quit();
		 }

		//	Debug.Log ("velocity " + player.velocity.sqrMagnitude);
	}


	void SpeedLimiter()
	{
		if (player.velocity.sqrMagnitude > maxVelocity)
		{
			var diff = player.velocity.sqrMagnitude - maxVelocity;

			var opposite = player.velocity.normalized * diff;
			player.AddForce(new Vector3(-opposite.x, 0, 0));
		}
	}
}