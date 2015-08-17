using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonClickScript : MonoBehaviour {

	public GameObject guns;
	public GameObject maps;
	private StartGame sg;
	private GameObject playHand;
	public GameObject startCanvas;
	public GameObject hunterPrefab;
	public GameObject pauseCanvas;
	public GameObject pauseSmallCanvas;

	public GameObject gift;
	private GameObject gtemp;
	public float TotalTime = 3;
	private float timeLeft = 0;
	private bool showCanvas = false;
	
	public Sprite[] numbers;
	Image[] images;
	
	public Image textObject;
	public Sprite freeGiftIn;
	public Image timerIcon;
	public Image minute;
	int val = 0;
	private GameObject gameover;

	// Use this for initialization
	void Start () {

		timeLeft = TotalTime;

		guns.SetActive (false);

		//pauseCanvas = GameObject.Find ("PauseLargeCanvas");
		pauseCanvas.SetActive(false);
		pauseSmallCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if (showCanvas) {
			timeLeft -= Time.deltaTime;
		}

		/*if (timeLeft <= 0) {
			showCanvas = false;
			//gift.SetActive(false);
			Destroy(gtemp);
			textObject.sprite = freeGiftIn;
			timerIcon.enabled = true;
			minute.sprite = numbers[6];
			
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.resetGiftTimer();
			timeLeft = TotalTime;
			int sc = PlayerPrefs.GetInt ("Score");
			sc = sc + val;
			PlayerPrefs.SetInt ("Score", sc);
			//Destroy(gameObject);
		}*/

	}

	public void ButtonClick(string buttonName)
	{
		playHand = GameObject.FindGameObjectWithTag ("PlayHand");
		sg = playHand.GetComponent<StartGame> ();
		if (buttonName == "GunsButton") {
						guns.SetActive (true);
		} else if (buttonName == "BackButton") {
			guns.SetActive (false);
			sg.deactiveCanvas();
				}

		if (buttonName == "StartButton") {
			/**/
			GameObject.FindGameObjectWithTag("GameTitle").GetComponent<Animator>().SetBool("isDown", true);
			GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isStart", true);
			GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isStart", true);

			StartCoroutine(startanimation());
				}

		if (buttonName == "MapButton") {
			maps.SetActive (true);
		}

		if (buttonName == "BackMapButton") {
			maps.SetActive (false);
			sg.deactiveCanvas();
		}

		if (buttonName == "Play") {
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}

		if (buttonName == "Pause") {
			Time.timeScale = 0;
			pauseCanvas.SetActive(true);
			pauseSmallCanvas.SetActive (false);
		}

		if (buttonName == "Resume") {
			Time.timeScale = 1;
			pauseCanvas.SetActive(false);
			pauseSmallCanvas.SetActive (true);
		}

		if (buttonName == "GiftButton") {

			gameover = GameObject.FindGameObjectWithTag("GameOver");

			//showCanvas = true;
			gtemp = (GameObject)Instantiate (gift, new Vector2 (gift.transform.position.x, gift.transform.position.y), Quaternion.identity);
			gtemp.SetActive(true);

			//images = GameObject.Find ("GiftPanel").GetComponentsInChildren<Image> ();

			Image hundred = GameObject.FindGameObjectWithTag ("gc-hundred").GetComponent<Image> ();
			Image ten = GameObject.FindGameObjectWithTag ("gc-ten").GetComponent<Image> ();
			Image unit = GameObject.FindGameObjectWithTag ("gc-unit").GetComponent<Image> ();

			val = Random.Range(40, 150);
			if (val < 100) {
				int t = val / 10;
				int u = val % 10;
				
				ten.sprite = numbers [t];
				unit.sprite = numbers [u];
				
			} else {
				
				int h = val / 100;
				int ht = val % 100;
				
				int t = ht / 10;
				int u = ht % 10;
				
				hundred.sprite = numbers[h];
				ten.sprite = numbers [t];
				unit.sprite = numbers [u];
			}

			timerIcon = GameObject.FindGameObjectWithTag ("GreenStripeTimer").GetComponent<Image> ();
			timerIcon.enabled = false;

			minute = GameObject.FindGameObjectWithTag ("GreenStripeMinute").GetComponent<Image> ();

			textObject = GameObject.FindGameObjectWithTag ("GreenStripeLabel").GetComponent<Image> ();
			textObject.sprite = freeGiftIn;
			timerIcon.enabled = true;
			minute.sprite = numbers[6];
			
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.resetGiftTimer();
			timeLeft = TotalTime;
			int sc = PlayerPrefs.GetInt ("Score");
			sc = sc + val;
			PlayerPrefs.SetInt ("Score", sc);

			GameObject giftButton = GameObject.FindGameObjectWithTag ("GreenStripeButton");
			giftButton.SetActive(false);
			GameOverVisibility(false);
		}

		if (buttonName == "Restart") {
			GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isStart", true);
			GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isStart", true);
			GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isEnd", false);
			GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isEnd", false);
			sg.deactiveCanvas();
			restartLevel();
		}

		if (buttonName == "Menu") {
			Application.LoadLevel (0);
		}

		if (buttonName == "VideoButton") {
			VideoAds gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<VideoAds>();
			gamecontroller.loadAd();
		}

		/* if (buttonName == "PlayWithShotgun") {
			PlayerPrefs.SetInt ("gunIndex", 3);
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}

		if (buttonName == "PlayWithSniper") {
			PlayerPrefs.SetInt ("gunIndex", 4);
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}*/

		/*if (buttonName == "RestartButton") {
			gameObject.transform.position = new Vector2 (11f, 11f);
			GameObject hunt = GameObject.Find("Object");
			if(hunt == null)
			{
				hunt = GameObject.Find ("Object(Clone)");
			}
			Destroy(hunt);
			Destroy(GameObject.Find ("GameOverCanvas(Clone)"));
			GameObject h = (GameObject)Instantiate(hunterPrefab, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
			
			HunterMovement hRestart = h.GetComponent<HunterMovement> ();
			hRestart.letStart();
			
			GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird2D");

			GameObject playhand = GameObject.Find("PlayHand");
			StartGame sg = playHand.GetComponent<StartGame>();

			sg.initEmenyBird();
			if(birds.Length == 2)
			{
				sg.initBird(1);
			}
			else if(birds.Length == 1){
				sg.initBird(2);
			}
		}


		if (buttonName == "MenuButton") {
			startCanvas.SetActive(true);
			guns.SetActive (false);
			sg.deactiveCanvas();
			GameObject gc = GameObject.Find("GameOverCanvas(Clone)");
			Destroy(gc);
				}*/

	}

	public void GameOverVisibility(bool x)
	{
		gameover.SetActive (x);
	}

	private void restartLevel()
	{
		GameObject hunt = GameObject.FindGameObjectWithTag("Player");
		Destroy(hunt);
		
		//Destroy the bullets which are on the ground.
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject b in bullets) {
			Destroy(b);
		}
		
		//Destroy the bomber bird explosion.
		GameObject[] bbExplosion = GameObject.FindGameObjectsWithTag ("BomberBirdExplosion");
		if (bbExplosion != null) {
			foreach(GameObject exp in bbExplosion)
			{
				Destroy (exp);
			}
		}
		
		//Destroy GameOver object.
		GameObject[] go = GameObject.FindGameObjectsWithTag ("GameOver");
		for (int i = 0; i< go.Length; i++) {
			Destroy (go [i].gameObject);
		}
		//hRestart.setScoreToZero ();
		
		//Destroy the glassBreak which appears when user(hunter) is idle.
		GameObject glassBreak = GameObject.FindGameObjectWithTag("Glass Break");
		if (glassBreak != null) {
			Destroy (glassBreak);
		}
		
		//Destroy any sandhillCrane object.
		GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
		if (shc != null) {
			Destroy (shc);
		}
		
		//Destroy all the pelicans
		GameObject[] be = GameObject.FindGameObjectsWithTag("Bird2D");
		for (int i=0; i < be.Length; i++) {
			Destroy(be[i]);
		}
		
		//Destroy the enemy birds (bird with the bomb).
		GameObject[] birds = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
		for (int i=0; i < birds.Length; i++) {
			Destroy(birds[i]);
		}
		
		GameObject playhand = GameObject.FindGameObjectWithTag("PlayHand");
		//Destroy (playhand);
		
		//Get Gamecontroller object and set the values to zero.
		GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
		GameController gc = gcc.GetComponent<GameController> ();
		gc.setScoreToZero ();
		
		//GameObject ph = (GameObject)Instantiate(playHandPrefab, new Vector3(11f, 11f, 0.02769041f), Quaternion.identity);
		StartGame sg = playhand.GetComponent<StartGame>();
		sg.initBird (3);
		
		GameObject h = (GameObject)Instantiate(hunterPrefab, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
		//gameObject.GetComponent<Collider2D>().name = "StartButton";
		
		HunterMovement hRestart = h.GetComponent<HunterMovement> ();
		hRestart.letStart();


	}

	public void activateCanvas()
	{
		startCanvas.SetActive(true);
	}

	IEnumerator startanimation() 
	{
		GameObject startbutton = GameObject.Find ("Start3Buttons");
		Animator anim = startbutton.GetComponent<Animator> ();
		//yield return new WaitForSeconds (1f);
		anim.SetBool ("IsPressed", true);
		yield return new WaitForSeconds (2.5f);
		sg.activatePlayMode();
		startCanvas.SetActive(false);
		GameObject hand = GameObject.Find("PlayHand");
		hand.transform.position = new Vector2(8.089996f, 0.15f);
		pauseSmallCanvas.SetActive (true);
		anim.SetBool ("IsPressed", false);
	}
}
