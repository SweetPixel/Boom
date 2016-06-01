using UnityEngine;
using System.Collections;

public class JoystickMovement : MonoBehaviour {

	public float speed = 10f;
	public float airSpeed = 15f;
	public float speedX = 0f;
	public float h;
	float v;
	private float lastX;
	private bool facingRight = true;

	private bool isJump = false;
	private Vector2 motion;
	public float gravity= 10f;
	public float jumpSpeed = 10f;

	public bool grounded = true;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	float leftBorder;
	float rightBorder;

	//public GameObject bullet;
	//private GameObject bulletSpawn;
	public GameObject[] spawners;
	public float nextFire;
	public float fireRate;
	public float shootAngle = 22f;
	public bool isRight = true;
	public float bulletSpeed = 1600f;

	public Sprite[] sprites;
	private float bulletAngle = -90f;
	private Vector2 bulletDirectionForce;
	public bool lookingUp = false;

	private string button = "";
	public float moveForce = 35f;
	private bool jump=false;
	public float jumpForce = 50f;
	public float maxHeight = -1f;
	public float maxSpeed = 8f;
	CharacterController controller;
	private bool stopJumping = false;

	// Use this for initialization
	void Start () {
		motion = Vector2.zero;
		bulletDirectionForce = Vector2.zero;
		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
		gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
		//bulletAngle = -90f;
		gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
		//shootAngle = 0f;
		gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
		gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.right);
		lookingUp = false;

		controller = gameObject.GetComponent<CharacterController> ();

	}

	/*void Update()
	{
		
	}*/

	// Update is called once per frame
	void Update () {

		#if UNITY_IOS
		spriteSwap();
		#endif

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		if (grounded) {
			jump = true;
		}

		//h = Input.GetAxis("Horizontal");
		//v = CnControls.CnInputManager.GetAxis("Vertical");

		/*if(h > 0){
			//transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
			//isRight = true;
		/*}
		else if (h < 0){
			transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
			isRight = false;
		}*/

		if (Input.GetKey (KeyCode.LeftArrow) || h < 0) {
			if(isRight)
			{
				//isRight = false;
				transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);

				GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
				gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
				//bulletAngle = -90f;
				gameObject.GetComponent<PlayerFireScript>().setBulletAngle(-90f);
				//shootAngle = 0f;
				gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
				gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(-Vector2.right);
				lookingUp = false;

			}
			//h = -0.7f;
		}
		
		if (Input.GetKey (KeyCode.RightArrow) || h>0) {
			Debug.Log ("D is pressed");
			//isRight = true;
			transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);

			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
			//bulletAngle = -90f;
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
			//shootAngle = 0f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.right);
			lookingUp = false;
			//h = 0.7f;
		}

		if (Input.GetKey (KeyCode.UpArrow) || v>0) {
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[2];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[2]);
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			lookingUp = true;
		}

		if ((Input.GetKey (KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow)) || (v>0 && h<0))
		{
			transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[1];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[1]);
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(-22f);
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(-45f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			lookingUp = false;
		}

		if ((Input.GetKey (KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) || (v>0 && h>0))
		{
			transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[1];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[1]);
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(22f);
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(45f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			lookingUp = false;
		}

		if(grounded)
		{
			speedX = speed;
			isJump = true;
		}
		if(!grounded)
		{
			speedX = airSpeed;
		}

		//if(h!=0 && grounded || h!=0 && !grounded)

		/*if(isJump && Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown (KeyCode.JoystickButton1) &&  grounded)
		{
			//motion.y = jumpSpeed;
			GetComponent<Rigidbody2D> ().AddForce (jumpForce * Vector2.up);
		}

		if(isJump && (Input.GetKey(KeyCode.K) || Input.GetKey (KeyCode.JoystickButton1)) &&  grounded)
		{
			if (gameObject.transform.position.y < maxHeight) {
				GetComponent<Rigidbody2D> ().AddForce (jumpForce * Vector2.up);
			}
		}

		if(Input.GetKeyUp(KeyCode.K) || Input.GetKeyUp (KeyCode.JoystickButton1))
		{
			isJump = false;
		}*/

		if ((Input.GetKeyDown (KeyCode.JoystickButton1) || Input.GetKeyDown (KeyCode.F)) && grounded) {
			motion.y = jumpSpeed;
			stopJumping = true;
		}

		if ((Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.F)) && GetComponent<Rigidbody2D>().velocity.y < maxSpeed && isJump && stopJumping) {
			if (gameObject.transform.position.y < maxHeight)
				motion.y = jumpSpeed;
			else {
				isJump = false;
				stopJumping = false;
			}
		}

		if (Input.GetKeyUp (KeyCode.JoystickButton1) || Input.GetKeyUp (KeyCode.F)) {
			isJump = false;
			stopJumping = true;
		}

		motion.x = h * speedX;

		if(!grounded)
		{
			motion.y -= gravity * Time.deltaTime;
		}

		/*if(v >=0.8f)
		{
			motion.x = 0f;
		}*/

		gameObject.GetComponent<Rigidbody2D> ().velocity = motion;

		/*if ((Input.GetKeyDown (KeyCode.JoystickButton1) || Input.GetKeyDown (KeyCode.Space)) && grounded) {
			GetComponent<Rigidbody2D>().AddForce(jumpForce * Vector2.up);
		}

		if ((Input.GetKey (KeyCode.JoystickButton1) || Input.GetKey (KeyCode.Space)) && GetComponent<Rigidbody2D>().velocity.y < maxSpeed && jump) {
			if (gameObject.transform.position.y < maxHeight)
				GetComponent<Rigidbody2D> ().AddForce (jumpForce * Vector2.up);
			else
				jump = false;
		}

		if (Input.GetKeyUp (KeyCode.JoystickButton1) || Input.GetKeyUp (KeyCode.Space)) {
			jump = false;
		}*/

	}

	public void buttonClick(string name)
	{
		button = name;



		if(button.Equals("up"))
		{
			lookingUp = !lookingUp;

			if(lookingUp)
			{
				GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[2];
				gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[2]);
				gameObject.GetComponent<PlayerFireScript>().setBulletAngle(0f);
				//shootAngle = 0f;
				gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
				//bulletDirectionForce = Vector2.up;
				gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			}
			else{
				if(isRight)
				{
					GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
					gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
					//bulletAngle = -90f;
					gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
					//shootAngle = 0f;
					gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
					gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.right);
				}
				else{
					GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
					gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
					//bulletAngle = -90f;
					gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
					//shootAngle = 0f;
					gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
					gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(-Vector2.right);
				}
			}

		}
		else if(button.Equals("left"))
		{
			if(!lookingUp)
			{
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
			//bulletAngle = -90f;
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
			//shootAngle = 0f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(-Vector2.right);
			}
		}
		else if(button.Equals("right") )
		{
			if(!lookingUp)
			{
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
			//bulletAngle = -90f;
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
			//shootAngle = 0f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.right);
			}
			//lookingUp = false;
		}
	}

	public void standStill()
	{
		button = "";
		h = 0f;
	}

	private void spriteSwap()
	{
		if((v >= -1 && v <= 0.1f) || (button.Equals("left") && button.Equals("right") ))
		{
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
			//bulletAngle = -90f;
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
			//shootAngle = 0f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			if(isRight)
			{
			//bulletDirectionForce = Vector2.right;
				gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.right);
			}
			else{
				//bulletDirectionForce = -Vector2.right;
				gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(-Vector2.right);
			}
			lookingUp = false;
		}
		else if((v >0.1 && v <= 0.8f))
		{
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[1];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[1]);
			//bulletAngle = 15f;
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(15f);
			//shootAngle = 22f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(22f);
			//bulletDirectionForce = Vector2.up;
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			lookingUp = false;
		}
		else if((v >=0.8f && h <=0.65f) || button.Equals("up"))
		{
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[2];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[2]);
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(0f);
			//shootAngle = 0f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			//bulletDirectionForce = Vector2.up;
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			lookingUp = true;
		}
	}

	public void bounce()
	{
		motion.y = 4f;
		h=0;
	}

	/*public void InitiateFire()
	{
		StartCoroutine (Fire ());
	}*/

	/*IEnumerator Fire()
	{
		if (isRight) {
			GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,-bulletAngle));
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-shootAngle) * bulletDirectionForce * bulletSpeed);
			yield return new WaitForSeconds(0.25f);
			
		} else {
			GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,bulletAngle));
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,shootAngle) * bulletDirectionForce * bulletSpeed);
			yield return new WaitForSeconds(0.25f);
		}
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ammoDecrement();
	}*/

	public void activateJump()
	{
		if(speed < 13)
		{
			speed+=3;
		}
		isJump = true;
	}

}
