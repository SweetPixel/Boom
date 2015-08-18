using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

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
	public GameObject ScoreThousand;
	SpriteRenderer scoreRendererFour;
	private int scoreCounter = 0;

	public GameObject bird;
	public GameObject birdEnemy;
	private int birdCount = 0;

	/* Coin Icon Combo Sprite and Variables */
	public GameObject coinIcon;
	private SpriteRenderer coinIconRender;
	private Animator coinAnimator;
	public Sprite combo2;
	public Sprite combo3;
	public Sprite combo4;
	public Sprite combo5;
	public Sprite coinNormalIcon;
	private int comboValue = 0;

	/* Bird initiation points */
	float[] Yaxis = { 2.3f , 1.7f, 1.15f, 0.75f};
	float[] Xaxis = { 5.1f , 11.3f };

	/* Bullet Variables */
	private int b = 10;
	private int bulletCounter = 9;
	public GameObject bulletOne;
	public GameObject bulletTwo;
	private SpriteRenderer bulletOneRender;
	private SpriteRenderer bulletTwoRender;

	public GameObject bulletRifleIcon;
	public GameObject bulletShotGunIcon;
	public GameObject bulletSmgIcon;
	public GameObject bulletSniperIcon;
	private Animator anime;
	//private SpriteRenderer bulletIconRender;
	public Sprite bulletIcon_smg;
	public Sprite bulletIcon_shotgun;
	public Sprite bulletIcon_sniper;
	public Sprite bulletIcon_rifle;

	public GameObject sandHillCrane;
	public GameObject hummingBird;

	int gunIndex = 0;
	private bool initFlamingo = false;
	public GameObject specialBird;
	private bool isCombo;
	public GameObject eagle;
	private bool isEagleVisible = false;
	private float timeLeft = 0f; 
	public float totalTime= 2f;
	private int birdKilled = 0;
	private int fireShot = 0;
	public GameObject gameOver;

	public GameObject comboComponents;
	//public GameObject gift;

	private float giftTimeLeft = 360;
	private bool startgiftTimer = false;

	public GameObject goldenSpark;
	public GameObject startCanvas;
	float startTime = 0;
	bool startDelay = true;


	private bool slowDown = false;
	private bool isfinish = false;

	void Start()
	{
		score = 0;
		birdCount = 0;
		isCombo = false;
		b = 50;
		bulletCounter = 9;
		timeLeft = 0f; 
		totalTime= 2f;
		//startCanvas.SetActive(false);
		coinIconRender = coinIcon.GetComponent<SpriteRenderer> ();
		coinAnimator = coinIcon.GetComponent<Animator> ();

		bulletOne = GameObject.Find ("BulletSprite");
		bulletTwo = GameObject.Find ("BulletSpriteTwo");
		
		bulletOneRender = bulletOne.GetComponent<SpriteRenderer> ();
		bulletOneRender.sprite = scoreSprite [0];
		
		bulletTwoRender = bulletTwo.GetComponent<SpriteRenderer> ();
		bulletTwoRender.sprite = scoreSprite [5];
		bulletTwoRender.enabled = true;

		//bulletIcon = GameObject.Find ("BulletIcon");
		//bulletIconRender = bulletIcon.GetComponent<SpriteRenderer>();

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

		scoreRendererFour = ScoreThousand.GetComponent<SpriteRenderer> ();
		scoreRendererFour.sprite = scoreSprite [score];

		bulletRifleIcon.SetActive(false);
		bulletShotGunIcon.SetActive(false);
		bulletSmgIcon.SetActive(false);
		bulletSniperIcon.SetActive(false);

		gunIndex = PlayerPrefs.GetInt ("gunIndex");
		if (gunIndex == 0 || gunIndex == 1) {
			gunIndex = 1;
			//bulletIconRender.sprite = bulletIcon_rifle;
			bulletRifleIcon.SetActive(true);
			anime = bulletRifleIcon.GetComponent<Animator>();
			//sniperTracker.SetActive (false);
			//sniperTracker.GetComponent<SpriteRenderer>().enabled = false;
			
			b = 12;
			bulletCounter = 2;
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
		}
		else if (gunIndex == 2) {
			gunIndex = 2;
			//bulletIconRender.sprite = bulletIcon_smg;
			bulletShotGunIcon.SetActive(true);
			anime = bulletShotGunIcon.GetComponent<Animator>();
			//sniperTracker.SetActive (false);
			//sniperTracker.GetComponent<SpriteRenderer>().enabled = false;
			
			b = 24;
			bulletCounter = 4;
			bulletOneRender.sprite = scoreSprite [4];
			bulletTwoRender.sprite = scoreSprite [2];
			
		}
		else if (gunIndex == 3) {
			gunIndex = 3;
			//bulletIconRender.sprite = bulletIcon_shotgun;
			bulletSmgIcon.SetActive(true);
			anime = bulletSmgIcon.GetComponent<Animator>();
			//sniperTracker.SetActive (false);
			//sniperTracker.GetComponent<SpriteRenderer>().enabled = false;
			
			b = 12;
			bulletCounter = 2;
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
		}
		else if (gunIndex == 4) {
			gunIndex = 4;
			//bulletIconRender.sprite = bulletIcon_sniper;
			bulletSniperIcon.SetActive(true);
			anime = bulletSniperIcon.GetComponent<Animator>();
			//sniperTracker.SetActive (true);
			//sniperTracker.GetComponent<SpriteRenderer>().enabled = true;
			
			b = 12;
			bulletCounter = 2;
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
		}
		timeLeft = totalTime;

	}

	void Update()
	{
		/*if (startDelay) {
			startTime += Time.deltaTime;
				}

		if (startTime > 3f) {
			startCanvas.SetActive(true);
				} */

		if (initFlamingo == true) {
			int index = Random.Range(0,2);
			GameObject flamingo = (GameObject)Instantiate (specialBird, new Vector2 (5.27f, 2.824509f), Quaternion.identity);
			if (gunIndex == 1) 
			{
				flamingo.GetComponent<Animator>().SetInteger("gunIndex", gunIndex);
			}
			else if (gunIndex == 2) 
			{
				flamingo.GetComponent<Animator>().SetInteger("gunIndex", gunIndex);
			}
			else if (gunIndex == 3) 
			{
				flamingo.GetComponent<Animator>().SetInteger("gunIndex", gunIndex);
			}
			else if (gunIndex == 4) 
			{
				flamingo.GetComponent<Animator>().SetInteger("gunIndex", gunIndex);
			}
			//birdCount = 0;
			initFlamingo = false;
		}
		
		if (isCombo) {
			//timeLeft = totalTime;
			timeLeft -= Time.deltaTime;
		}
		
		if (isCombo && timeLeft <= 0) {
			timeLeft = totalTime;
			isCombo = false;
			isEagleVisible = false;
			birdCount = 0;
			if(comboValue > 1){
				setScore ((score * comboValue)-score);
				Instantiate (goldenSpark, new Vector2 (coinIcon.transform.position.x, coinIcon.transform.position.y), Quaternion.identity);
				StartCoroutine (coinBeat());
			}
			comboValue = 0;
			GameObject cc = GameObject.FindGameObjectWithTag("ComboComponents");
			if(cc != null)
			{
				Destroy(cc);
			}

			GameObject go = GameObject.FindGameObjectWithTag("GameOver");

			if(b == 0 && go == null)
			{
				GameObject hunter = GameObject.FindGameObjectWithTag("Player");
				HunterMovement hm = hunter.GetComponent<HunterMovement>();
				hm.lost ();
				GameOver();
			}
		}
		
		if (birdCount == 5 && isEagleVisible) {
			Instantiate (eagle, new Vector2 (5.27f, -0.83f), Quaternion.identity);
			isEagleVisible = false;
			//birdCount = 0;
		}

		if (timeLeft <= 0) {
			timeLeft = totalTime;
			isCombo = false;
			isEagleVisible = false;
			birdCount = 0;
			comboValue = 0;
		}

		if (startgiftTimer) {
			giftTimeLeft -= Time.deltaTime;
				}

		if (giftTimeLeft <= 0) 
		{
			startgiftTimer = false;
			giftTimeLeft = 360;
		}

		if (slowDown) {
			Time.timeScale = 0.1f;
				}

		 if(isfinish) {
			StartCoroutine(finishGame());
			isfinish = false;
				}


	}

	IEnumerator finishGame()
	{
		yield return new WaitForSeconds (0f);
		GameObject hunter = GameObject.FindGameObjectWithTag("Player");
		HunterMovement hm = hunter.GetComponent<HunterMovement>();
		hm.lost ();
		GameOver();
	}

	public void slowMotion()
	{
		slowDown = true;
	}

	public bool getSlowMotion()
	{
		return slowDown;
	}

	public void resetGiftTimer()
	{
		startgiftTimer = true;
	}

	public bool getGiftTimer()
	{
		return startgiftTimer;
	}

	public string giftTimerLeft()
	{
		string minutes = Mathf.Floor(giftTimeLeft / 60).ToString("00");
		return minutes;
	}

	public void incrementBirdCount()
	{
		birdCount += 1;
		/*if (isCombo) {
			timeLeft = totalTime;
				} */

		isCombo = true;
		timeLeft = totalTime;
		/*if (timeLeft < 0) {
			timeLeft = totalTime;
			isCombo = false;
			isEagleVisible = false;
			birdCount = 0;
			comboValue = 0;
		} else */ 
		if (timeLeft > 0) {
			//timeLeft = totalTime;
			if(birdCount >= 2 && birdCount <= 99)
			{
				comboValue = birdCount;
				GameObject cc = GameObject.FindGameObjectWithTag("ComboComponents");
				if(cc != null)
				{
					Destroy(cc);
					Instantiate (comboComponents, new Vector2 (comboComponents.transform.position.x, comboComponents.transform.position.y), Quaternion.identity);
				}
				else{
					Instantiate (comboComponents, new Vector2 (comboComponents.transform.position.x, comboComponents.transform.position.y), Quaternion.identity);
				}
			}
			else{
				comboValue = birdCount;
			}

		}
		if(birdCount == 3)
		{
			isEagleVisible = true;
		}
		/*(if (b == 0) {
			GameObject hunter = GameObject.FindGameObjectWithTag("Player");
			Animator anime = hunter.GetComponent<Animator>();
			anime.SetBool("isLost", true);
			HunterMovement hm = hunter.GetComponent<HunterMovement>();
			hm.lost ();
			GameOver();
		}*/
		
	}

	public void setBulletIcon(int gI)
	{
		if (gI == 1) 
		{
			bulletRifleIcon.SetActive(true);
			bulletSmgIcon.SetActive(false);
			bulletShotGunIcon.SetActive(false);
			bulletSniperIcon.SetActive(false);
			gunIndex = 1;
		}
		else if (gI == 2) 
		{
			bulletRifleIcon.SetActive(false);
			bulletSmgIcon.SetActive(true);
			bulletShotGunIcon.SetActive(false);
			bulletSniperIcon.SetActive(false);
			gunIndex=2;
		}
		else if (gI == 3) 
		{
			bulletRifleIcon.SetActive(false);
			bulletSmgIcon.SetActive(false);
			bulletShotGunIcon.SetActive(true);
			bulletSniperIcon.SetActive(false);
			gunIndex = 3;
		}
		else if (gI == 4) 
		{
			bulletRifleIcon.SetActive(false);
			bulletSmgIcon.SetActive(false);
			bulletShotGunIcon.SetActive(false);
			bulletSniperIcon.SetActive(true);
			gunIndex = 4;
		}
	}

	public int getGunIndex()
	{
		return gunIndex;
	}

	public int getComboValue()
	{
		return comboValue;
	}

	public int getBirdKilled()
	{
		return birdKilled;
	}

	public void addFireShotNumber()
	{
		fireShot++;
	}

	public int getFireShotNumber()
	{
		return fireShot;
	}

	public void increaseBirdKiled()
	{
		birdKilled++;
		if (birdKilled % 5 == 0) {
			initFlamingo = true;
		}

		if (birdKilled <= 5) {
			initiatePelican ();
		}
		else if (birdKilled >=6 && birdKilled < 10) {
			GameObject tucan = GameObject.FindGameObjectWithTag("BirdEnemy2D");
			if(tucan != null)
			{
				initiatePelican();
			}
			else{
				StartCoroutine(InitiateEnemy(1));
			}
		} else if (birdKilled == 10){
			GameObject tucan = GameObject.FindGameObjectWithTag("BirdEnemy2D");
			if(tucan != null)
			{
				initiatePelican();
			}
			else{
				StartCoroutine(InitiateEnemy(1));
			}
		}
		else if(birdKilled > 10 && birdKilled < 20){
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
		else if(birdKilled == 20){
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
		else if(birdKilled > 20 && birdKilled < 30){
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
		else if(birdKilled == 30){
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
		else if(birdKilled > 30 && birdKilled < 40){
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
		else if(birdKilled == 40){
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
		else if(birdKilled > 40 && birdKilled < 50){
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
		else if(birdKilled == 50){
			fiftyOnwards();
		}
		else if(birdKilled > 50 && birdKilled < 60){
			fiftyOnwards();
		}
		else if(birdKilled == 60){
			fiftyOnwards();
		}
		else if(birdKilled > 60 && birdKilled < 70){
			fiftyOnwards();
		}
		else if(birdKilled == 70){
			fiftyOnwards();
		}
		else if(birdKilled > 70 && birdKilled < 80){
			fiftyOnwards();
		}
		else if(birdKilled == 80){
			fiftyOnwards();
		}
		else if(birdKilled > 80 && birdKilled < 90){
			fiftyOnwards();
		}
		else if(birdKilled == 90){
			fiftyOnwards();
		}
		else if(birdKilled > 90 && birdKilled < 100){
			fiftyOnwards();
		}
		else if(birdKilled == 100){
			fiftyOnwards();
		}
		else if(birdKilled > 100 && birdKilled <= 999){
			fiftyOnwards();
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

	public void decrementBirdCount()
	{
		birdCount = 0;
		coinIconRender.sprite = coinNormalIcon;
		if (comboValue > 1) {
			setScore ((score * comboValue)-score);
				}
		comboValue = 0;
		
		if (b == 0) {
			GameObject hunter = GameObject.FindGameObjectWithTag("Player");
			HunterMovement hm = hunter.GetComponent<HunterMovement>();
			hm.lost ();
			GameOver();
		}
	}

	public void addCoin()
	{
		setScore (5);
	}

	/*
	 * Set score and initiate the birds with respect to the level.
	 */

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

	public void setScoreToZero ()
	{
		GameObject explosion = GameObject.FindGameObjectWithTag ("BomberBirdExplosion");
		if (explosion != null) {
			Destroy (explosion);
		}

		fireShot = 0;
		score = 0;
		birdKilled = 0;
		birdCount = 0;

		scoreRenderer.sprite = scoreSprite [score];
		scoreRendererTwo.sprite = scoreSprite [score];
		scoreRendererThree.sprite = scoreSprite [score];
		bulletTwoRender.enabled = true;

		if (gunIndex == 0 || gunIndex == 1) {
			b = 12;
			bulletCounter = 2;
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
		}
		else if (gunIndex == 2) {
			b = 24;
			bulletCounter = 4;
			bulletOneRender.sprite = scoreSprite [4];
			bulletTwoRender.sprite = scoreSprite [2];
			
		}
		else if (gunIndex == 3) {
			b = 12;
			bulletCounter = 2;
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
		}
		else if (gunIndex == 4) {
			b = 12;
			bulletCounter = 2;
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
		}
	}
	
	public void setScore(int value)
	{

		score += value;
		
		if (value == 0) {
			return;
		}
		
		if (score <= 5) {
			scoreRendererThree.sprite = scoreSprite [score];
		}
		else if (score >=6 && score < 10) {
			scoreRendererThree.sprite = scoreSprite [score];

		} else if (score == 10){
			bulletCounter--;
			scoreRendererThree.sprite = scoreSprite [0];
			scoreRendererTwo.sprite = scoreSprite [1];

		}
		else if(score > 10 && score < 20){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}

			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [1];

		}
		else if(score == 20){
			bulletCounter--;
			scoreCounter = 2;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			

		}
		else if(score > 20 && score < 30){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}

			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [2];
			

		}
		else if(score == 30){
			//setMisses();
			scoreCounter = 3;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			

		}
		else if(score > 30 && score < 40){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [3];


		}
		else if(score == 40){
			scoreCounter = 4;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

		}
		else if(score > 40 && score < 50){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [4];
			

		}
		else if(score == 50){
			scoreCounter = 5;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

		}
		else if(score > 50 && score < 60){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [5];


		}
		else if(score == 60){
			scoreCounter = 6;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

		}
		else if(score > 60 && score < 70){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [6];


		}
		else if(score == 70){
			scoreCounter = 7;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

		}
		else if(score > 70 && score < 80){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [7];


		}
		else if(score == 80){
			scoreCounter = 8;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

		}
		else if(score > 80 && score < 90){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [8];


		}
		else if(score == 90){
			scoreCounter = 9;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

		}
		else if(score > 90 && score < 100){
			if(value > 1)
			{
				scoreCounter = score % 10;
			}
			else{
				scoreCounter++;
			}
			scoreRendererThree.sprite = scoreSprite [scoreCounter];
			scoreRendererTwo.sprite = scoreSprite [9];

		}
		else if(score == 100){
			scoreCounter = 1;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
			scoreRendererThree.sprite = scoreSprite [scoreCounter];

		}
		else if(score > 100 && score <= 999){
			
			int hundred = score / 100;
			scoreRenderer.sprite = scoreSprite [hundred];
			
			int ut = score % 100;
			int ten = ut / 10;
			int unit = ut % 10;
			
			scoreRendererTwo.sprite = scoreSprite [ten];
			scoreRendererThree.sprite = scoreSprite [unit];

		}
		else if(score >= 1000 && score <= 9999){

			int thousand = score/1000;
			scoreRendererFour.sprite = scoreSprite [thousand];

			int tempThousand = score % 1000;
			int hundred = tempThousand / 100;
			scoreRenderer.sprite = scoreSprite [hundred];
			
			int ut = tempThousand % 100;
			int ten = ut / 10;
			int unit = ut % 10;
			
			scoreRendererTwo.sprite = scoreSprite [ten];
			scoreRendererThree.sprite = scoreSprite [unit];
			
		}
		//coinAnimator.enabled = false;

		if (b == 0)
		{
			isfinish = true;
		}

	}
	
	IEnumerator coinBeat()
	{
		coinAnimator.SetBool ("isBeat", true);
		yield return new WaitForSeconds (0.3f);
		coinAnimator.SetBool ("isBeat", false);
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

	public void setEagleVisibility()
	{
		isEagleVisible = false;
	}

	public void addAmmo()
	{
		StartCoroutine (BulletIconBeating ());
		if(gunIndex == 1)
		{
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
			bulletTwoRender.enabled = true;
			b = 12;
			bulletCounter = 2;
		}
		else if(gunIndex == 2)
		{
			bulletOneRender.sprite = scoreSprite [4];
			bulletTwoRender.sprite = scoreSprite [2];
			bulletTwoRender.enabled = true;
			b = 24;
			bulletCounter = 4;
		}
		else if(gunIndex == 3)
		{
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
			bulletTwoRender.enabled = true;
			b = 12;
			bulletCounter = 2;
		}
		else if(gunIndex == 4)
		{
			bulletOneRender.sprite = scoreSprite [2];
			bulletTwoRender.sprite = scoreSprite [1];
			bulletTwoRender.enabled = true;
			b = 12;
			bulletCounter = 2;
		}
	}

	IEnumerator BulletIconBeating()
	{
		anime.SetBool ("isBeat", true);
		yield return new WaitForSeconds (0.3f);
		anime.SetBool ("isBeat", false);
	}

	public void bulletSpriteSetter()
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
			//isfinish = true;
		}
	}

	public int getBulletNumber()
	{
		return b;
	}

	private IEnumerator gameOVerWithWait()
	{
		yield return new WaitForSeconds (2f);
		GameOver();
	}

	public void GameOver()
	{
		int sc = PlayerPrefs.GetInt ("Score");
		sc = sc + score;
		PlayerPrefs.SetInt ("Score", sc);
		PlayerPrefs.SetInt ("MatchScore", score);
		/*if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", score); */
		GameObject go = (GameObject)Instantiate (gameOver, new Vector2 (gameOver.transform.position.x, gameOver.transform.position.y), Quaternion.identity);
		
		//gameObject.transform.position = new Vector2(transform.position.x, -1.98f);
		//anim.SetBool("isLost", true);
	}

}
