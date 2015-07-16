using UnityEngine;
using System.Collections;

public class HunterMovement : MonoBehaviour {

	private float minX = -3.2f;
	private float maxX = 3.2f;
	//bool isRight = true;

	/* Bullet Sprites and variables */
	public Vector3 pointB;
	private GameObject bulletpointVariable;
	public GameObject bulletSpawn;
	public GameObject bulletSpawn_sniper;
	public GameObject bulletSpawn_shotgun;
	public GameObject bulletSpawn_ak47;

	private GameObject bullet;
	public GameObject bulletNormal;
	public GameObject bulletSmg;
	public GameObject bulletShotgun;

	private GameObject bulletIcon;
	private SpriteRenderer bulletIconRender;
	public Sprite bulletIcon_smg;
	public Sprite bulletIcon_shotgun;
	public Sprite bulletIcon_sniper;
	public Sprite bulletIcon_rifle;

	/* End of Bullet Sprite and variables */

	/* Coin Icon Combo Sprite and Variables */
	private GameObject coinIcon;
	private SpriteRenderer coinIconRender;
	public Sprite combo2;
	public Sprite combo3;
	public Sprite combo4;
	public Sprite combo5;
	public Sprite coinNormalIcon;
	private int comboValue = 0;

	/* End of Coin Icon Combo Sprite and Variables */

	//Speed variable
	public float bulletSpeed = 1600f;
	public float hunterSpeed= 3.0f;

	bool isFired = false;

	bool isRight = false;
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

	private Animator hunterAnime;

	private float restartInitiate;

	public GameObject bird;

	/*
	 *  Score Variables
	*/
	private int score = 0;
	public Sprite[] scoreSprite;
	public GameObject ScoreUnit;
	SpriteRenderer scoreRenderer;
	public GameObject ScoreTen;
	SpriteRenderer scoreRendererTwo;
	public GameObject ScoreHundred;
	SpriteRenderer scoreRendererThree;
	private int scoreCounter = 0;

	public GUIText timeObject;

	/* GameOver object */
	public GameObject gameOver;
	public GameObject gameOverCanvas;
	public bool isGameOver = false;

	// Start Button
	private GameObject startButton;

	/* Bullet Variables */
	private int b = 10;
	private int bulletCounter = 9;
	public GameObject bulletOne;
	public GameObject bulletTwo;
	private SpriteRenderer bulletOneRender;
	private SpriteRenderer bulletTwoRender;

	/* Bird initiation points */
	float[] Yaxis = { 2.3f , 1.7f, 1.15f, 0.75f};
	float[] Xaxis = { 5.1f , 11.3f };
	public float nextFire;
	private bool startFiring = false;
	private int fireShot = 0;

	//variable to keep track of number of birds killed.
	private int birdKilled = 0;

	//Special bird condition
	private int birdCount = 0;
	public GameObject[] specialBird;
	public GameObject eagle;
	private bool isEagleVisible = false;
	public GameObject birdEnemy;
	public GameObject sandHillCrane;
	public GameObject hummingBird;

	private float timeLeft = 0f; 
	public float totalTime= 2f;
	private bool isCombo;

	IEnumerator Start () {
		/* Bullet Renderers */

		/*bulletObject = GameObject.Find ("BulletCountDown");
		coinObject = GameObject.Find ("CoinObject");

		coinObject.SetActive (true);
		bulletObject.SetActive (true);*/

		isCombo = false;
		score = 0;
		birdCount = 0;
		timeLeft = 0f; 
		totalTime= 2f;

		bulletIcon = GameObject.Find ("BulletIcon");
		bulletIconRender = bulletIcon.GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator> ();
		
		int gunIndex = PlayerPrefs.GetInt ("gunIndex");
		if (gunIndex == 0 || gunIndex == 1) {
			anim.SetInteger("gunIndex", 1);
			bulletpointVariable = bulletSpawn;
			bullet = bulletNormal;
			bulletIconRender.sprite = bulletIcon_rifle;
		}
		else if (gunIndex == 2) {
			anim.SetInteger("gunIndex", 2);
			bulletpointVariable = bulletSpawn_ak47;
			bullet = bulletSmg;
			bulletIconRender.sprite = bulletIcon_smg;
		}
		else if (gunIndex == 3) {
			anim.SetInteger("gunIndex", 3);
			bulletpointVariable = bulletSpawn_shotgun;
			bullet = bulletShotgun;
			bulletIconRender.sprite = bulletIcon_shotgun;
		}
		else if (gunIndex == 4) {
			anim.SetInteger("gunIndex", 4);
			bulletpointVariable = bulletSpawn_sniper;
			bullet = bulletNormal;
			bulletIconRender.sprite = bulletIcon_sniper;
		}
		animshoot=bulletpointVariable.GetComponent<Animator>();

		coinIcon = GameObject.Find("CoinIcon");
		coinIconRender = coinIcon.GetComponent<SpriteRenderer>();

		b = 50;
		bulletCounter = 9;

		bulletOne = GameObject.Find ("BulletSprite");
		bulletTwo = GameObject.Find ("BulletSpriteTwo");

		bulletOneRender = bulletOne.GetComponent<SpriteRenderer> ();
		bulletOneRender.sprite = scoreSprite [0];

		bulletTwoRender = bulletTwo.GetComponent<SpriteRenderer> ();
		bulletTwoRender.sprite = scoreSprite [5];
		bulletTwoRender.enabled = true;

		/* End of Bullet Renderer */

		startButton = GameObject.Find ("StartButton");

		hunterAnime = gameObject.GetComponent<Animator> ();

		hunterSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

		/* Score Sprites */
		ScoreUnit = GameObject.Find ("ScoreSprite");
		ScoreTen = GameObject.Find ("ScoreSpriteTwo");
		ScoreHundred = GameObject.Find ("ScoreSpriteThree");

		scoreRenderer = ScoreUnit.GetComponent<SpriteRenderer> ();
		scoreRenderer.sprite = scoreSprite [score];

		scoreRendererTwo = ScoreTen.GetComponent<SpriteRenderer> ();
		scoreRendererTwo.sprite = scoreSprite [score];

		scoreRendererThree = ScoreHundred.GetComponent<SpriteRenderer> ();
		scoreRendererThree.sprite = scoreSprite [score];

		/* Bullets Available */
		roundAvailable = true;
		restartInitiate = 0;
		
		/* Flip Function */
		Flip ();

		/* Start Hunter Movement from the middle */
		yield return StartCoroutine(MoveObject(transform, new Vector3(8.15f, -2.15f, 0.02769041f), new Vector3(9.80f, -2.15f, 0.02769041f), hunterSpeed));

		Vector3 pointA = transform.position;
		while (roundAvailable) {
			yield return StartCoroutine(MoveObject(transform, new Vector3(9.80f, -2.15f, 0.02769041f), new Vector3(6.35f, -2.15f, 0.02769041f), hunterSpeed));
			isRight = true;
			yield return StartCoroutine(MoveObject(transform, new Vector3(6.35f, -2.15f, 0.02769041f), new Vector3(9.80f, -2.15f, 0.02769041f), hunterSpeed));
			isRight = false;
		}

		timeLeft = totalTime;

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
		if (isRestart && restartInitiate > 3.2) {

			//DestroyAllComponents();
			GameObject go = (GameObject)Instantiate (gameOver, new Vector2 (8.029126f, 1.784778f), Quaternion.identity);

			isRestart = false;

			//Application.LoadLevel("SecondLevelInfinite");
				} 

		if (birdCount == 5) {
			int index = Random.Range(0,2);
			Instantiate (specialBird[0], new Vector2 (5.27f, 2.824509f), Quaternion.identity);
			birdCount = 0;
				}

		if (isCombo) {
				timeLeft -= Time.deltaTime;
				}

		if (isCombo && timeLeft <= 0 && comboValue >=2) {
			timeLeft = totalTime;
			isCombo = false;
			isEagleVisible = false;
			birdCount = 0;
			coinIconRender.sprite = coinNormalIcon;
			setScore (comboValue);
			comboValue = 0;
				}

		if (birdCount == 3 && isEagleVisible) {
			Instantiate (eagle, new Vector2 (5.27f, 2.824509f), Quaternion.identity);
			isEagleVisible = false;
			birdCount = 0;
		}
	}

	public void setEagleVisibility()
	{
		isEagleVisible = false;
	}

	public void decrementBirdCount()
	{
		birdCount = 0;
		coinIconRender.sprite = coinNormalIcon;
		setScore (comboValue);
		comboValue = 0;
	}

	public void incrementBirdCount()
	{
		birdCount += 1;
		coinIconRender.sprite = coinNormalIcon;
		isCombo = true;
		if (timeLeft < 0) {
			timeLeft = totalTime;
			isCombo = false;
			isEagleVisible = false;
			birdCount = 0;
			coinIconRender.sprite = coinNormalIcon;
			/*for(int i = 0; i < comboValue; i++)
			{
				score ++;
			} */
			comboValue = 0;
		} else {
			//timeLeft = totalTime;
			if(birdCount == 2)
			{
				coinIconRender.sprite = combo2;
				comboValue = 2;
			}
			else if(birdCount == 3)
			{
				coinIconRender.sprite = combo3;
				comboValue = 3;
			}
			else if(birdCount == 4)
			{
				coinIconRender.sprite = combo4;
				comboValue = 4;
			}
			else if(birdCount == 5)
			{
				coinIconRender.sprite = combo5;
				comboValue = 5;
			}
			else{
				coinIconRender.sprite = coinNormalIcon;
			}
			isEagleVisible = true;
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Coin(Clone)") {
			Destroy(col.gameObject);
			initiateCoin();
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
		hunterAnime.SetBool("isHit", true);
	}

	public int getBirdKilled()
	{
		return birdKilled;
	}

	public void initiateCoin()
	{
		birdKilled++;
	}

	private void initiatePelican()
	{
		int index = Random.Range(0,4);
		float y = Yaxis[index];
		float x = 5.1f;
		if(index == 0 || index == 2)
		{
			x = Xaxis[0];
		}
		else if(index == 1 || index == 3)
		{
			x = Xaxis[1];
		}
		
		Instantiate (bird, new Vector2 (x, y), Quaternion.identity);
	}

	/*
	 * Set score and initiate the birds with respect to the level.
	 */

	public void setScoreToZero ()
	{
		score = 0;
	}

	public void setScore(int value)
	{
		score += value;
		Debug.Log (score);

		if (value == 0) {
			return;
				}

		if (score <= 5) {
			scoreRendererThree.sprite = scoreSprite [score];
						initiatePelican ();
				}
		else if (score >=6 && score < 10) {
			scoreRendererThree.sprite = scoreSprite [score];
			GameObject tucan = GameObject.FindGameObjectWithTag("BirdEnemy2D");
			if(tucan != null)
			{
				initiatePelican();
			}
			else{
				StartCoroutine(InitiateEnemy(1));
			}
		} else if (score == 10){
			bulletCounter--;
			scoreRendererThree.sprite = scoreSprite [0];
			scoreRendererTwo.sprite = scoreSprite [1];
				GameObject tucan = GameObject.FindGameObjectWithTag("BirdEnemy2D");
				if(tucan != null)
				{
					initiatePelican();
				}
				else{
					StartCoroutine(InitiateEnemy(1));
				}
		}
		else if(score > 10 && score < 20){
			if(value > 1)
			{
				scoreCounter+=value;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

				GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
				if(shc != null)
				{
					GameObject tucan = GameObject.FindGameObjectWithTag("BirdEnemy2D");
					
					if(tucan != null)
					{
						initiatePelican();
					}
					else{
						StartCoroutine(InitiateEnemy(1));
					}
				}
				else{
					Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
				}

		}
		else if(score == 20){
			bulletCounter--;
			scoreCounter = 2;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

				GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
				if(shc != null)
				{
					GameObject tucan = GameObject.FindGameObjectWithTag("BirdEnemy2D");
					
					if(tucan != null)
					{
						initiatePelican();
					}
					else{
						StartCoroutine(InitiateEnemy(1));
					}
				}
				else{
					Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
				}

		}
		else if(score > 20 && score < 30){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

				GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
				if(shc != null)
				{
					GameObject[] tucan = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
					int x = Random.Range(0,2);
					if(x == 1)
					{
						initiatePelican();
					}
					else{
						if(tucan.Length < 2)
						{
							StartCoroutine(InitiateEnemy(1));
						}
					}
				}
				else{
					Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
				}

		}
		else if(score == 30){
			//setMisses();
			scoreCounter = 3;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

				GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
				if(shc != null)
				{
					GameObject[] tucan = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
					int x = Random.Range(0,2);
					if(x == 1)
					{
						initiatePelican();
					}
					else{
						if(tucan.Length < 2)
						{
							StartCoroutine(InitiateEnemy(1));
						}
					}
				}
				else{
					Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
				}

		}
		else if(score > 30 && score < 40){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			GameObject hb = GameObject.FindGameObjectWithTag("HummingBird");
			if(hb != null)
			{
				GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
				if(shc != null)
				{
					GameObject[] tucan = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
					int x = Random.Range(0,2);
					if(x == 1)
					{
						initiatePelican();
					}
					else{
						if(tucan.Length < 2)
						{
							StartCoroutine(InitiateEnemy(1));
						}
					}
				}
				else{
					Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
				}
			}
			else{
				Instantiate (hummingBird, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
			}
		}
		else if(score == 40){
			scoreCounter = 4;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			GameObject hb = GameObject.FindGameObjectWithTag("HummingBird");
			if(hb != null)
			{
				GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
				if(shc != null)
				{
					GameObject[] tucan = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
					int x = Random.Range(0,2);
					if(x == 1)
					{
						initiatePelican();
					}
					else{
						if(tucan.Length < 2)
						{
							StartCoroutine(InitiateEnemy(1));
						}
					}
				}
				else{
					Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
				}
			}
			else{
				Instantiate (hummingBird, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
			}
		}
		else if(score > 40 && score < 50){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

			GameObject hb = GameObject.FindGameObjectWithTag("HummingBird");
			if(hb != null)
			{
				GameObject[] shc = GameObject.FindGameObjectsWithTag("SandhillCrane");
				int x_shc = Random.Range(0,2);
				if(x_shc == 1)
				{
					GameObject[] tucan = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
					int x = Random.Range(0,2);
					if(x == 1)
					{
						initiatePelican();
					}
					else{
						if(tucan.Length < 2)
						{
							StartCoroutine(InitiateEnemy(1));
						}
					}
				}
				else{
					if(shc.Length < 2)
					{
						Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
					}
				}
			}
			else{
				Instantiate (hummingBird, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
			}

		}
		else if(score == 50){
			scoreCounter = 5;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score > 50 && score < 60){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score == 60){
			scoreCounter = 6;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score > 60 && score < 70){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score == 70){
			scoreCounter = 7;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score > 70 && score < 80){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score == 80){
			scoreCounter = 8;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score > 80 && score < 90){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score == 90){
			scoreCounter = 9;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score > 90 && score < 100){
			scoreCounter++;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score == 100){
			scoreCounter = 1;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			fiftyOnwards();
		}
		else if(score > 100 && score <= 999){

			int hundred = score / 100;
			scoreRenderer.sprite = scoreSprite [hundred];

			int ut = score % 100;
			int ten = ut / 10;
			int unit = ut % 10;

			scoreRendererTwo.sprite = scoreSprite [ten];
			scoreRendererThree.sprite = scoreSprite [unit];
			fiftyOnwards();
		}
	}

	private void fiftyOnwards()
	{
		GameObject[] hb = GameObject.FindGameObjectsWithTag("HummingBird");
		int x_hb = Random.Range(0,2);
		if(x_hb  == 1)
		{
			GameObject[] shc = GameObject.FindGameObjectsWithTag("SandhillCrane");
			int x_shc = Random.Range(0,2);
			if(x_shc == 1)
			{
				GameObject[] tucan = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
				int x = Random.Range(0,2);
				if(x == 1)
				{
					initiatePelican();
				}
				else{
					if(tucan.Length < 2)
					{
						StartCoroutine(InitiateEnemy(1));
					}
				}
			}
			else{
				if(shc.Length < 2)
				{
					Instantiate (sandHillCrane, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
				}
			}
		}
		else{
			if(hb.Length < 2)
			{
				Instantiate (hummingBird, new Vector2 (5.1f, 1.784778f), Quaternion.identity);
			}

		}
	}

	IEnumerator InitiateEnemy(int length)
	{
		while(true)
		{
			for (int i=0;i<length;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (birdEnemy, new Vector2 (4.1f, Random.Range(1.2f, 3f)), spawnRotation);
				yield return new WaitForSeconds(0.5f);
			}
			break;
		}
	}

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
	///	charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
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
			nextFire = Time.time + 0.5f;
			if(isFired == false)
			{
				bulletSpriteSetter();
				isFired = true;
				animshoot.SetBool("isFired", isFired);
				StartCoroutine(Fired());
			}
		}


	}

	IEnumerator Fired()
	{
		fireShot++;
		yield return new WaitForSeconds(0.25f);
		if (isRight) {
			GameObject game = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,-10f));
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-15f) * Vector2.up * bulletSpeed);
		} else {
			GameObject game = (GameObject)Instantiate(bullet, bulletpointVariable.transform.position, Quaternion.Euler(0,0,10f));
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,15f) * Vector2.up * bulletSpeed);
		}
		isFired = false;
		animshoot.SetBool("isFired", isFired);
	}

	public int getFireShotNumber()
	{
		return fireShot;
	}

	public void addAmmo()
	{
		bulletOneRender = bulletOne.GetComponent<SpriteRenderer> ();
		bulletOneRender.sprite = scoreSprite [0];
		
		bulletTwoRender = bulletTwo.GetComponent<SpriteRenderer> ();
		bulletTwoRender.sprite = scoreSprite [5];
		bulletTwoRender.enabled = true;
		b = 50;
		bulletCounter = 9;
	}

	public void addCoin()
	{
		setScore (5);
	}

	void bulletSpriteSetter()
	{
		b = b - 1;
		if (b > 40) {
			bulletTwoRender.sprite = scoreSprite[4];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
				}
		else if (b == 40) {
			bulletTwoRender.sprite = scoreSprite[4];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 40 && b > 30) {
			bulletTwoRender.sprite = scoreSprite[3];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		else if (b == 30) {
			bulletTwoRender.sprite = scoreSprite[3];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 30 && b > 20) {
			bulletTwoRender.sprite = scoreSprite[2];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		else if (b == 20) {
			bulletTwoRender.sprite = scoreSprite[2];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 20 && b > 10) {
			bulletTwoRender.sprite = scoreSprite[1];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		else if (b == 10) {
			bulletTwoRender.sprite = scoreSprite[1];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 10 && b > 0) {
			bulletTwoRender.enabled = false;
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		if (b == 0) {
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter = 9;
			lost();
		}
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
		int sc = PlayerPrefs.GetInt ("Score");
		sc = sc + score;
		PlayerPrefs.SetInt ("Score", sc);
		PlayerPrefs.SetInt ("MatchScore", score);
		/*if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", score); */
		roundAvailable = false;
		//gameObject.transform.position = new Vector2(transform.position.x, -1.98f);
		//hunterAnime.SetBool("isLost", true);
	} 

	public void letStart()
	{
		start = true;
		//coinObject.SetActive (false);
		//bulletObject.SetActive (false);
	}

}
