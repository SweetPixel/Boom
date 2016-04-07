using UnityEngine;
using System.Collections;

public class Hunter : MonoBehaviour {

	private float minX = -3.2f;
	private float maxX = 3.2f;
	
	/* End of Bullet Sprite and variables */
	
	/* End of Coin Icon Combo Sprite and Variables */
	
	//Speed variable
	public float bulletSpeed = 1600f;
	public float hunterSpeed= 3.0f;
	
	bool isFired = false;
	
	bool isRight = true;
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
	
	IEnumerator Start () {
		/* Bullet Renderers */
		
		/*bulletObject = GameObject.Find ("BulletCountDown");
		coinObject = GameObject.Find ("CoinObject");

		coinObject.SetActive (true);
		bulletObject.SetActive (true);*/
		idleTime = 0f;
		
		gamecontroller = GameObject.FindGameObjectWithTag ("GameController");
		gc = gamecontroller.GetComponent<GameController> ();
		
		anim = gameObject.GetComponent<Animator> ();
		
		
		//sniperTracker = GameObject.FindGameObjectWithTag ("SniperTracker");
		//sniperTracker.SetActive (false);
		
		/* End of Bullet Renderer */
		
		startButton = GameObject.Find ("StartButton");
		
		hunterSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
		
		/* Bullets Available */
		roundAvailable = true;
		restartInitiate = 0;
		
		/* Flip Function */
		//Flip ();
		
		/* Start Hunter Movement from the middle */
		//yield return StartCoroutine(MoveObject(transform, new Vector3(8.15f, -1.84f, 0.02769041f), new Vector3(9.80f, -1.84f, 0.02769041f), hunterSpeed));

		string temp = Screen.width.ToString();
		float width = float.Parse(temp);

		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		yield return StartCoroutine(MoveObject(transform, new Vector3(0f, -2.45f, 0.02769041f), new Vector3(rightBorder-0.3f, -2.45f, 0.02769041f), hunterSpeed));
		
		Vector3 pointA = transform.position;
		while (roundAvailable) {
			Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector3(rightBorder-0.3f, -2.45f, 0.02769041f), new Vector3(leftBorder+0.3f, -2.45f, 0.02769041f), hunterSpeed));
			//isRight = true;
			Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector3(leftBorder+0.3f, -2.45f, 0.02769041f), new Vector3(rightBorder-0.3f, -2.45f, 0.02769041f), hunterSpeed));
			//isRight = false;
		}
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
		
		/*if (gameObject.transform.position.x < 6.4 || gameObject.transform.position.x > 9.7) {
			Flip ();
				}*/
		
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
			HummingBirdScript bm = b.GetComponent<HummingBirdScript>();
			bm.setHunterIdle();
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
		
		if (col.gameObject.name == "HunterColliderLeft" || col.gameObject.name == "HunterColliderRight") {
			Flip ();
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
	
	void Flip()
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
		/* if (Input.GetKey (KeyCode.Mouse0) && roundAvailable && start) 
		{
			if(isFired == false)
			{

				bulletSpriteSetter();
				isFired = true;
				animshoot.SetBool("isFired", isFired);
				//checkBirdPosition();
				StartCoroutine(Fired());
			}
		} */
		
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
					animshoot.SetBool("isFired", isFired);
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
	
	
	/*IEnumerator Fired()
	{

	}*/
	
	/*IEnumerator shotGunFire()
	{
		if (isRight) {
			GameObject rightBul = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,0f));
			rightBul.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-5f) * Vector2.up * 2950f); 
			
			yield return new WaitForSeconds (0.01f);
			
			GameObject midBul = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,-10f));
			midBul.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-15f) * Vector2.up * bulletSpeed);
			
			yield return new WaitForSeconds (0.01f);
			
			GameObject leftBul = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,-20f));
			leftBul.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-25f) * Vector2.up * 2900f);
			
		} else {
			GameObject rightBul = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,0f));
			rightBul.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,5f) * Vector2.up * 2950f);
			
			yield return new WaitForSeconds (0.01f);
			
			GameObject midBul = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,10f));
			midBul.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,15f) * Vector2.up * bulletSpeed);
			
			yield return new WaitForSeconds (0.01f);
			
			GameObject leftBul = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,20f));
			leftBul.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,25f) * Vector2.up * 2900f);
		}
	}*/
	
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
	
	/* IEnumerator lost()
	{
		roundAvailable = false;
		gameObject.transform.position = new Vector2(transform.position.x, -1.81f);
		hunterAnime.SetBool("isLost", true);
		yield return new WaitForSeconds (0f);
	} */
	
	public void lost()
	{
		//int sc = PlayerPrefs.GetInt ("Score");
		/////////////////sc = sc + score;
		//PlayerPrefs.SetInt ("Score", sc);
		////////////////////PlayerPrefs.SetInt ("MatchScore", score);
		/*if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", score); */
		roundAvailable = false;
		startFiring = false;
		//sniperTracker.SetActive (false);
		//GameObject go = (GameObject)Instantiate (gameOver, new Vector2 (8.029126f, 1.784778f), Quaternion.identity);
		
		//gameObject.transform.position = new Vector2(transform.position.x, -1.98f);
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
		//coinObject.SetActive (false);
		//bulletObject.SetActive (false);
	}
}
