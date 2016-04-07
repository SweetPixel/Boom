using UnityEngine;
using System.Collections;

public class JoystickMovement : MonoBehaviour {

	public float speed = 10f;
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

	public GameObject bullet;
	public GameObject bulletSpawn;
	public float nextFire;
	public float fireRate;
	public float shootAngle = 22f;
	public bool isRight = true;
	public float bulletSpeed = 1600f;

	// Use this for initialization
	void Start () {
		motion = Vector2.zero;
		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		Debug.Log("Right: " + rightBorder);
		Debug.Log("Left: " + leftBorder);

	}


	// Update is called once per frame
	void FixedUpdate () {

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		if(grounded)
		{

		}

		/*if(Input.GetKey(KeyCode.K) && !isJump)
		{
			//gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(gameObject.GetComponent<Rigidbody2D>().velocity.x, this.transform.up.y * jumpSpeed));
			motion.y = jumpSpeed;
			isJump = true;
			/*if(transform.position.y >= 0f)
			{
				isJump = true;
			}
		}*/

		if(Input.GetKey(KeyCode.L) && 
		   Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			StartCoroutine(Fire());
		}

		/*if(grounded)
		{

		}*/
		float h = CnControls.CnInputManager.GetAxis("Horizontal");

		if(h > 0){
			transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
			isRight = true;
		}
		else if (h < 0){
			transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
			isRight = false;
		}

		motion.x = Mathf.Clamp(h * speed, leftBorder, rightBorder);

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

		gameObject.GetComponent<Rigidbody2D>().velocity = motion;

	}

	IEnumerator Fire()
	{
		if (isRight) {
			GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,-15f));
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-shootAngle) * Vector2.up * bulletSpeed);
			yield return new WaitForSeconds(0.25f);
			
		} else {
			GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,15f));
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,shootAngle) * Vector2.up * bulletSpeed);
			yield return new WaitForSeconds(0.25f);
		}
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ammoDecrement();
	}

	public void activateJump()
	{
		isJump = true;
	}

}
