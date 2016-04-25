using UnityEngine;
using System.Collections;

public class JoystickMovement : MonoBehaviour {

	public float speed = 10f;
	public float airSpeed = 15f;
	private float speedX = 0f;
	float h;
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

	}

	/*void Update()
	{
		spriteSwap();
	}*/

	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		h = CnControls.CnInputManager.GetAxis("Horizontal");
		v = CnControls.CnInputManager.GetAxis("Vertical");

		if(h > 0){
			transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
			isRight = true;
		}
		else if (h < 0){
			transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
			isRight = false;
		}

		if (Input.GetKey (KeyCode.A) || button.Equals("left")) {
			if(isRight)
			{
				isRight = false;
				transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
			}
			h = -0.7f;
		}
		
		if (Input.GetKey (KeyCode.D) || button.Equals("right")) {
			if(!isRight)
			{
				isRight = true;
				transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
			}
			h = 0.7f;
		}

		if(grounded)
		{
			speedX = speed;
		}
		if(!grounded)
		{
			speedX = airSpeed;
		}

		motion.x = Mathf.Clamp(h * speedX, leftBorder, rightBorder);

		//if(h!=0 && grounded || h!=0 && !grounded)
		//	motion.x = Mathf.Clamp(h * speed, leftBorder, rightBorder);

		if(isJump || Input.GetKey(KeyCode.K) &&  grounded)
		{
			motion.y = jumpSpeed;
			isJump = false;
		}


		if(!grounded)
		{
			motion.y -= gravity * Time.deltaTime;
		}

		if(v >=0.8f)
		{
			motion.x = 0f;
		}

		gameObject.GetComponent<Rigidbody2D>().velocity = motion;

	}

	public void buttonClick(string name)
	{
		button = name;
		GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[2];
		if(button.Equals("up"))
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
		else if(button.Equals("left"))
		{
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
			//bulletAngle = -90f;
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
			//shootAngle = 0f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(-Vector2.right);
			lookingUp = false;
		}
		else if(button.Equals("right") )
		{
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = sprites[0];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(spawners[0]);
			//bulletAngle = -90f;
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
			//shootAngle = 0f;
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.right);
			lookingUp = false;
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
		else if((v >=0.8f && h <=0.65f) || (button.Equals("up") ))
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
		isJump = true;
	}

}
