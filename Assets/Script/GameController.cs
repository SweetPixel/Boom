using UnityEngine;
using UnityEngine.UI;
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
	float[] Yaxis = { 4f , 4.5f, 5.2f,6.5f};
	float[] Xaxis = { -3.4f , 4f };

	/* Bullet Variables */
	private int b;
	public int TotalBullets;
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

	public Text coinsCounter;
	public Canvas CoinCanvas;
	public Text bCounter;
	public Canvas BulletCanvas;

	public AudioClip comboMultiAudio;
	public AudioClip noBulletAudio;

	public GameObject Tiger;
	float playedTime;
	public Text timeDisplay;
	public GameObject miniBoss;

	void Start()
	{
		int sc = PlayerPrefs.GetInt ("Score");

		score = 0;
		birdCount = 0;
		isCombo = false;
		bulletCounter = 9;
		timeLeft = 0f; 
		totalTime= 2f;
		b = TotalBullets;
		coinIconRender = coinIcon.GetComponent<SpriteRenderer> ();
		coinAnimator = coinIcon.GetComponent<Animator> ();

		coinsCounter.GetComponent<Text>().enabled = false;
		bCounter.text = b.ToString ();
		bulletRifleIcon.SetActive(false);
		bulletShotGunIcon.SetActive(false);
		bulletSmgIcon.SetActive(false);
		bulletSniperIcon.SetActive(false);

		timeLeft = totalTime;
		playedTime = 0f;

	}


	void Update()
	{
		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			playedTime += Time.deltaTime;
			timeDisplay.text = Mathf.RoundToInt(playedTime).ToString();
		}

		if(GameObject.Find("Foreground").GetComponent<Image>().fillAmount == 1 && GameObject.FindGameObjectWithTag("Boss") == null)
		{
			Instantiate(Tiger, new Vector3(0f, Tiger.transform.position.y, Tiger.transform.position.z), Quaternion.identity);
		}

		if(System.Math.Round(GameObject.Find("Foreground").GetComponent<Image>().fillAmount,2)%0.25f == 0 && GameObject.Find("Foreground").GetComponent<Image>().fillAmount != 1
		   && GameObject.Find("Foreground").GetComponent<Image>().fillAmount != 0)
		{
			GameObject[] miniBosses = GameObject.FindGameObjectsWithTag("MiniBoss");
			if(miniBosses.Length == 0)
			{
				Instantiate(miniBoss, new Vector3(-2.5f, miniBoss.transform.position.y, miniBoss.transform.position.z), Quaternion.identity);
			}
		}
	}

	public void setIsCombo(bool x)
	{
		isCombo = x;
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

		isCombo = true;
		timeLeft = totalTime; 
		if (timeLeft > 0) {
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

		if (b < 1) {
			Debug.Log ("decrementBirdCount GameOver");
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
		float x = 3.0f;
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

		bCounter.text = b.ToString ();
	}
	
	public void setScore(int value)
	{

		score += value;
		
		if (value == 0) {
			return;
		}

		coinsCounter.text = score.ToString();

		GameObject go = GameObject.FindGameObjectWithTag("GameOver");
		if (b < 1 && go == null)
		{
			//isfinish = true;
			GetComponent<AudioSource>().clip = comboMultiAudio;
			GetComponent<AudioSource>().Play();
			GameObject hunter = GameObject.FindGameObjectWithTag("Player");
			HunterMovement hm = hunter.GetComponent<HunterMovement>();
			Debug.Log("Score GameOver");
			hm.lost ();
			GameOver();
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

	public void disableCoinCanvas()
	{
		CoinCanvas.GetComponent<Canvas>().enabled = false;
		BulletCanvas.GetComponent<Canvas>().enabled = false;
	}

	public void activeCoinCanvas()
	{
		score = 0;
		coinsCounter.text = score.ToString ();
		bCounter.text = b.ToString ();
		//CoinCanvas.GetComponent<Canvas>().enabled = true;
		//StartCoroutine (waitAndEnableBulletCanvas ());
	}

	IEnumerator waitAndEnableBulletCanvas()
	{
		yield return new WaitForSeconds (0.5f);
		BulletCanvas.GetComponent<Canvas>().enabled = true;
	}

	public void setEagleVisibility()
	{
		isEagleVisible = false;
	}

	IEnumerator BulletIconBeating()
	{
		anime.SetBool ("isBeat", true);
		yield return new WaitForSeconds (0.3f);
		anime.SetBool ("isBeat", false);
	}

	public void setBullet()
	{
		b += 10;
		bulletSpriteSetter();
	}

	public void ammoDecrement()
	{
		b = b - 1;
		bCounter.text = b.ToString ();

		if(b == 0)
		{
			//Gameover Code.
			GameOver();
		}
	}

	public void bulletSpriteSetter()
	{
		b = b - 1;
		bCounter.text = b.ToString ();
	}

	public int getBulletNumber()
	{
		return b;
	}

	private IEnumerator gameOVerWithWait()
	{
		yield return new WaitForSeconds (2f);
		Debug.Log ("gameOVerWithWait GameOver");
		GameOver();
	}

	public void GameOver()
	{
		int sc = PlayerPrefs.GetInt ("Score");
		sc = sc + score;
		PlayerPrefs.SetInt ("Score", sc);
		PlayerPrefs.SetInt ("MatchScore", score);

		GameObject go = (GameObject)Instantiate (gameOver, new Vector2 (gameOver.transform.position.x, gameOver.transform.position.y), Quaternion.identity);
	}

}
