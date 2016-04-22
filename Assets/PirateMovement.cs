using UnityEngine;
using System.Collections;

public class PirateMovement : MonoBehaviour {

	private float minX = -3.2f;
	private float maxX = 3.2f;
	private int SwipeID = -1;
	public float minMovement = 10.0f;
	private Vector2 StartPos;
	private Vector3 moveDirection = Vector3.zero;
	public float jumpSpeed = 0F;
	bool landed=false;
	public GameObject bullet;
	public GameObject bulletSpawn;
	private GameObject clone;
	public bool firstshot=false;
	public bool gameover = false;
	public float gravity = 20.0F;
	private bool isJumped = false;
	/* End of Bullet Sprite and variables */
	
	/* End of Coin Icon Combo Sprite and Variables */
	
	//Speed variable
	public float bulletSpeed = 1600f;
	public float hunterSpeed= 3.0f;
	
	bool isFired = false;
	
	public bool isRight = true;
	public GameObject shoot;
	Animator anim;
	Animator animshoot;
	
	private bool roundAvailable = true;
	public GUIText fireCount;
	int fc = 6;
	
	public Sprite[] bulletCount;
	private int countIndex = 0;
	public GameObject _bulletCount;
	//SpriteRenderer renderer;
	
	SpriteRenderer hunterSpriteRenderer;
	public Sprite idle;
	
	private bool start = false;
	private bool isRestart = false;
	
	private float restartInitiate;
	
	
	
	public Sprite[] scoreSprite;
	
	public GUIText timeObject;
	
	/* GameOver object */
	public GameObject gameOver;
	public GameObject gameOverCanvas;
	public bool isGameOver = false;
	
	// Start Button
	private GameObject startButton;
	
	public float nextFire;
	private bool startFiring = false;
	
	//variable to keep track of number of birds killed.
	
	
	//Special bird condition
	
	public GameObject[] specialBird;
	
	private GameObject gamecontroller;
	private GameController gc;
	

	
	
	private float idleTime;
	public GameObject glassBreak;
	//public GameObject sniperTracker;
	public int IdleThreshold = 7;
	public GameObject progressBar;
	
	private bool isInitial = true;
	private bool isFlipped = true;
	public bool isgrounded = true;

	float leftBorder;
	float rightBorder;

	float maxValue = 15f; // or whatever you want the max value to be
	float minValue = -15f; // or whatever you want the min value to be
	float currentValue = 0; // or wherever you want to start
	int direction = 1; 
	public float shootAngle = 22f;

	public float fireRate;
	public bool spotted = false;

	void Start () {

		moveDirection = new Vector3 (1, 0, Input.GetAxis ("Vertical"));
		moveDirection = transform.TransformDirection (moveDirection);
		moveDirection *= 12.0F;
		idleTime = 0f;
		
		gamecontroller = GameObject.FindGameObjectWithTag ("GameController");
		gc = gamecontroller.GetComponent<GameController> ();
		
		anim = gameObject.GetComponent<Animator> ();

		startButton = GameObject.Find ("StartButton");
		
		hunterSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		
		/* Bullets Available */
		roundAvailable = true;
		restartInitiate = 0;

		string temp = Screen.width.ToString();
		float width = float.Parse(temp);

		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

	}
	
	IEnumerator restartLevel()
	{
		while (true) {
			if(isRestart)
				yield return new WaitForSeconds(2);
			Application.LoadLevel ("MainScene");
			
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			if(roundAvailable == false)
			{
				//isRestart = true;
				//restartInitiate = 0;
				break;
			}
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
	
	void Update () {

		/*currentValue += Time.deltaTime * direction  * hunterSpeed; // or however you are incrementing the position
		if(currentValue >= rightBorder-0.3f) {
			direction *= -1;
			currentValue = rightBorder-0.3f;
		} else if (currentValue <= leftBorder+0.3f){
			direction *= -1;
			currentValue = leftBorder+0.3f;
		}

		if(direction > 0)
		{
			if(!isRight)
				Flip ();

		}
		else if(direction < 0){
			if(isRight)
				Flip ();
		}

		moveDirection.x = currentValue; */

		/*if (Input.GetKey (KeyCode.K) && isgrounded) 
		{
			//moveDirection.y = jumpSpeed;
			isJumped = true;
			isgrounded = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<PirateMovement>().isgrounded = false;
			GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpSpeed));
		}*/

		if(Input.GetKey(KeyCode.L) && 
		   Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			StartCoroutine(Fire());
		}

		if(Input.GetKey(KeyCode.Space) )
		{
			Application.LoadLevel("MainScene");
		}

		if (Input.GetKey (KeyCode.A)) {
			if(isRight)
			{
				//isRight = false;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PirateMovement>().Flip();
			}
			GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector2(5f,-1.4f) * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.S)) {
			if(!isRight)
			{
				//isRight = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PirateMovement>().Flip();
			}
			GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector2(5f,-1.4f) * Time.deltaTime);
		}


		//foreach (var T in Input.touches) {
		//	var P = T.position;
		//	if (T.phase == TouchPhase.Began && SwipeID == -1) {
		//		SwipeID = T.fingerId;
	//			StartPos = P;
		//	} else if (T.fingerId == SwipeID) {
		//		var delta = P - StartPos;
		//		if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement) {
		//			SwipeID = -1;
		//			if (Mathf.Abs (delta.x) > Mathf.Abs (delta.y)) {
		//				
		//			} else {
		//				if (delta.y > 0 && isgrounded) {
		//					isJumped = true;
		//					isgrounded = false;
							//moveDirection.y = jumpSpeed;
							/*if (PlayerPrefs.GetInt ("Sound") == 0) 
								{
									gameObject.GetComponent<AudioSource>().Play();
								}*/								
		//				}
		//			}
		//		} 
		//		if (T.phase == TouchPhase.Ended) { 
		//			SwipeID = -1;
		//			if(Time.timeScale == 1){
		//				StartCoroutine(Fire());
		//			}else{
		//				Time.timeScale=1;
		//			}
					//GameObject.Find ("tapToShoot").GetComponent<SpriteRenderer> ().enabled = false;
					//if(!gameover && landed)
						
					//{
						
					//}
					//firstshot=true;
		//		}
		//	}
		//}

		/*if(!isJumped)
			transform.position = new Vector3(currentValue, transform.position.y, 0);
		else{
			//gameObject.transform.position = new Vector3(currentValue, transform.position.y * jumpSpeed * Time.smoothDeltaTime, transform.position.z);
			gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200f);
			isJumped = false;
		}*/
		/*if(isRight)
		{
			gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*10f);
		}
		else{
			gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right*-10f);
		}

		Debug.Log("leftborder: " + leftBorder + " and the transform position: " + transform.position.x);

		float diff = Mathf.Abs(leftBorder + transform.position.x);
		Debug.Log("difference: " +  diff);

		if(rightBorder - transform.position.x < 0.5f)
		{
			isRight = false;
		}
		else if(Mathf.Abs(leftBorder + transform.position.x) >= 0.5f && !isRight){
			isRight = true;
		}*/

		restartInitiate += Time.deltaTime;
		if (isRestart && restartInitiate > 3.2) 
		{
			GameObject go = (GameObject)Instantiate (gameOver, new Vector2 (gameOver.transform.position.x, gameOver.transform.position.y), Quaternion.identity);
			isRestart = false;
			start = false;
		} 
		
		idleTime += Time.deltaTime;
		if (idleTime > IdleThreshold && start) 
		{
			start = false;
			GameObject gOver = GameObject.FindGameObjectWithTag("GameOver");
			if(gOver == null)
			{
				StartCoroutine(idleHunterAnimation());
			}
		}


		
		//moveDirection.y -= gravity * Time.smoothDeltaTime;
		
	}

	public void InitiateFire()
	{
		StartCoroutine (Fire ());
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

	IEnumerator idleHunterAnimation()
	{
		while (true) 
		{
			flyAwayBirds();
			yield return new WaitForSeconds (1f);
			//sniperTracker.SetActive (false);
			roundAvailable = false;
			anim.SetBool ("isIdle", true);
			yield return new WaitForSeconds (0.2f);
			GameObject gameover = GameObject.FindGameObjectWithTag("GameOver");
			if(gameover == null)
			{
				Instantiate (glassBreak, glassBreak.transform.position, Quaternion.identity);
			}
			yield return new WaitForSeconds (1.5f);
			lost ();
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.GameOver();
			break;
		}
	}
	
	public void flyAwayBirds()
	{
		GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird2D");
		foreach(GameObject b in birds)
		{
			BirdMovement bm = b.GetComponent<BirdMovement>();
			bm.setHunterIdle();
		}
		
		GameObject[] enemy = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
		foreach(GameObject b in enemy)
		{
//			Mover bm = b.GetComponent<Mover>();
//			bm.setHunterIdle();
		}
		
		GameObject[] humming = GameObject.FindGameObjectsWithTag("HummingBird");
		foreach(GameObject b in humming)
		{
			/*HummingBirdScript bm = b.GetComponent<HummingBirdScript>();
			bm.setHunterIdle();*/
		}
		
		GameObject[] sandhillCrane = GameObject.FindGameObjectsWithTag("SandhillCrane");
		if(sandhillCrane.Length > 0)
		{
			foreach(GameObject b in sandhillCrane)
			{
				SandhilCraneScript bm = b.GetComponent<SandhilCraneScript>();
				bm.setHunterIdle();
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Coin(Clone)") {
			Destroy(col.gameObject);
		}
		
		if (col.gameObject.name == "PlayHand") {
			return;
		}

		if(col.gameObject.name == "Platform")
		{
			isgrounded = true;
		}

		if(col.gameObject.tag == "Rocket")
		{
			Destroy(gameObject);
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.GameOver();
		}
		
	}
	
	public void DestroyAllComponents()
	{
		/* 
		 * Kill all the enemies.
		 */
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("BirdEnemy2D");
		
		for (int  i = 0; i< enemies.Length; i++) {
			Destroy (enemies[i].gameObject);
		}
		
	}
	
	public void gotHit()
	{
		roundAvailable = false;
		gameObject.transform.position = new Vector2(transform.position.x, -1.9f);
	}

	public void Flip()
	{
		//Vector2 charScale = transform.localScale;
		///	charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
		isRight = !isRight;
		isFlipped = !isFlipped;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		/*Debug.DrawRay(new Vector2(transform.position.x, transform.position.y-0.1f), Vector2.right, Color.green, 2f);
		RaycastHit2D hitup = Physics2D.Linecast(new Vector2(transform.position.x, transform.position.y-0.1f), Vector2.right, 1 <<LayerMask.NameToLayer("Enemy"), 0f, 2f);
		if (hitup.collider != null || hitup.collider.gameObject.name == "Mashroom") {
			Destroy (hitup.collider.gameObject);
		}*/


		GameObject start = GameObject.Find ("StartButton");
		if (start == null) {
			startFiring = true;
		}
		
		if (Input.GetKey (KeyCode.Mouse0) && Time.time > nextFire && roundAvailable && startFiring) {
			nextFire = Time.time + 0.25f;
			if(isFired == false)
			{
				Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				if(clickedPosition.y < 3.0f)
				{
					gc.bulletSpriteSetter();
					isFired = true;
					//animshoot.SetBool("isFired", isFired);
					//StartCoroutine(Fired());
				}
			}
			/*GameObject progressbar = GameObject.FindGameObjectWithTag("ProgressBar");
			if(progressbar == null)
			{
				Instantiate (progressBar, progressBar.transform.position, Quaternion.identity);
			}
			else{
				Destroy(progressbar);
				Instantiate (progressBar, progressBar.transform.position, Quaternion.identity);
			}*/
			idleTime = 0f;
		}
		
	}
	
	public void setRight(bool x)
	{
		isRight = x;
	}
	
	void checkBirdPosition()
	{
		ObstacleTreeScript otScript = new ObstacleTreeScript ();
		if (otScript.getRange ()) {
			otScript.SetAllCollidersStatus (false);
		} else {
			otScript.SetAllCollidersStatus (true);
		}
	}

	public void lost()
	{

		roundAvailable = false;
		startFiring = false;

	} 
	
	public void letStart()
	{
		GameObject explosion = GameObject.FindGameObjectWithTag ("BomberBirdExplosion");
		if (explosion != null) {
			Destroy (explosion);
		}
		
		start = true;
		idleTime = 0f;
	}
	
	public void stopStart()
	{
		GameObject explosion = GameObject.FindGameObjectWithTag ("BomberBirdExplosion");
		if (explosion != null) {
			Destroy (explosion);
		}
		
		start = false;
		idleTime = 0f;
	}
}
