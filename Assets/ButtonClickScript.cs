﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonClickScript : MonoBehaviour {

	public GameObject guns;
	public GameObject maps;
	//private StartGame sg;
	private GameObject playHand;
	public GameObject startCanvas;
	public GameObject hunterPrefab;
	public GameObject pauseCanvas;
	public GameObject pauseSmallCanvas;
	public Image pause;

	public GameObject gift;
	private GameObject gtemp;
	public float TotalTime = 3;
	private float timeLeft = 0;
	private bool showCanvas = false;
	
	public Sprite[] numbers;
	public Sprite[] score;
	Image[] images;
	
	//public Image textObject;
	public Sprite freeGiftIn;
	public Image timerIcon;
	public Text minute;
	int val = 0;
	private GameObject gameover;

	private bool isGuncanvasOpen = false;
	private ScrollRectCsharp sr;
	public Sprite select;

	public Sprite buyThousand;
	public Sprite buyTwoThousand;
	public Sprite buyFiveThousand;

	private int gunIndex=1;
	private bool isAvailable = false;

	public int smgValue = 2500;
	public int shotgunValue = 5000;
	public int sniperValue = 10000;
	public GameObject progressBar;
	public Sprite playIcon;

	public AudioClip buttonAudio;
	private int direction = 0;
	private bool isRight = true;

	// Use this for initialization
	void Start () {

		timeLeft = TotalTime;

		guns.SetActive (false);

		//pauseCanvas = GameObject.Find ("PauseLargeCanvas");
		pauseCanvas.SetActive(false);
		//PauseCanvasVisibility(false);
		sr = GameObject.FindGameObjectWithTag("GameController").GetComponent<ScrollRectCsharp>();
	}
	
	// Update is called once per frame
	void Update () {

		/*if (direction == 1) {
			GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector2(5f,-1.4f) * Time.deltaTime);
		}

		if (direction == -1) {
			GameObject.FindGameObjectWithTag("Player").transform.Translate(new Vector2(5f,-1.4f) * Time.deltaTime);
		}

		if (showCanvas) {
			timeLeft -= Time.deltaTime;
		}*/


	}

	public void PauseCanvasVisibility(bool x)
	{
		//pauseSmallCanvas.SetActive (x);
		pause.GetComponent<Image> ().enabled = false;
	}

	public void ButtonClick(string buttonName)
	{
		//GetComponent<AudioSource>().clip = buttonAudio;
		//GetComponent<AudioSource>().Play();
		playHand = GameObject.FindGameObjectWithTag ("PlayHand");
		//sg = playHand.GetComponent<StartGame> ();
		if (buttonName == "GunsButton") 
		{
			HunterMovement hm = GameObject.FindGameObjectWithTag("Player").GetComponent<HunterMovement>();
			hm.stopStart();
			sr.reset(PlayerPrefs.GetInt("gunIndex")-1);
			PlayerPrefs.SetInt ("isGuncanvasOpen", 1);
			isGuncanvasOpen = true;
			guns.SetActive (true);
		} 
		else if (buttonName == "BackButton") 
		{
			PlayerPrefs.SetInt ("isGuncanvasOpen", 0);
			isGuncanvasOpen = false;
			guns.SetActive (false);
			//sg.deactiveCanvas();
		}
		if (buttonName == "StartButton") {
			/**/
			GameObject.FindGameObjectWithTag("GameTitle").GetComponent<Animator>().SetBool("isDown", true);
			GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isStart", true);
			GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isStart", true);
			PlayerPrefs.SetInt ("isGuncanvasOpen", 0);
			StartCoroutine(startanimation());
				}

		if (buttonName == "MapButton") {
			HunterMovement hm = GameObject.FindGameObjectWithTag("Player").GetComponent<HunterMovement>();
			hm.stopStart();
			MapScrollScript sr = GameObject.FindGameObjectWithTag("GameController").GetComponent<MapScrollScript>();
			sr.reset(0);
			maps.SetActive (true);
		}

		if (buttonName == "BackMapButton") {
			maps.SetActive (false);
			//sg.deactiveCanvas();
		}

		if (buttonName == "Play") {


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
			gtemp = (GameObject)Instantiate (gift, new Vector2 (gift.transform.position.x, gift.transform.position.y), Quaternion.identity);
			gtemp.SetActive(true);


			Text giftText = GameObject.FindGameObjectWithTag ("GiftCoin").GetComponent<Text> ();

			val = Random.Range(50, 100);
			giftText.text = val.ToString();

			timerIcon = GameObject.FindGameObjectWithTag ("GreenStripeTimer").GetComponent<Image> ();
			timerIcon.enabled = false;

			minute = GameObject.FindGameObjectWithTag ("GreenStripeMinute").GetComponent<Text> ();

			Text textObject = GameObject.FindGameObjectWithTag ("FreeGiftText").GetComponent<Text> ();
			textObject.text = "FREE GIFT IN";

			/*Image label = GameObject.FindGameObjectWithTag ("FreeGiftIn_Label").GetComponent<Image> ();
			label.enabled = true;*/

			timerIcon.enabled = true;
			minute.text = "6:00";
			
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.resetGiftTimer();
			timeLeft = TotalTime;
			int sc = PlayerPrefs.GetInt ("Score");
			sc = sc + val;
			PlayerPrefs.SetInt ("Score", sc);

			GameObject giftButton = GameObject.FindGameObjectWithTag ("GreenStripeButton");
			giftButton.SetActive(false);
			//GameOverVisibility(false);

			GameOverScript go_script = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverScript>();
			go_script.calculateTotalCoins();
		}

		if (buttonName == "Restart") {
			GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isStart", true);
			GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isStart", true);
			GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isEnd", false);
			GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isEnd", false);
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().activeCoinCanvas ();
			//sg.deactiveCanvas();
			restartLevel();
		}

		if (buttonName == "Menu") {
			Application.LoadLevel (0);
		}

		if (buttonName == "VideoButton") {
			VideoAds gamecontroller = GameObject.FindGameObjectWithTag("GameController").GetComponent<VideoAds>();
			//gamecontroller.loadAd();
		}

		if (buttonName == "RestartLevel") {
			Application.LoadLevel("MainScene");
		}

		if (buttonName == "MoveLeft") {

			GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickMovement>().buttonClick("left");

			/*if(isRight)
			{
				isRight = false;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PirateMovement>().Flip();
			}
			direction = -1;*/
		}

		if (buttonName == "MoveRight") {

			if(GameObject.FindGameObjectWithTag("Player") != null)
			{
			GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickMovement>().buttonClick("right");
			}
			/*if(!isRight)
			{
				isRight = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PirateMovement>().Flip();
			}
			direction = 1;*/
		}

		if (buttonName == "SeeUp") {

			if(GameObject.FindGameObjectWithTag("Player") != null)
			{
			GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickMovement>().buttonClick("up");
			}
			/*if(!isRight)
			{
				isRight = true;
				GameObject.FindGameObjectWithTag("Player").GetComponent<PirateMovement>().Flip();
			}
			direction = 1;*/
		}

		if (buttonName == "Still") {
			//direction = 0;
			if(GameObject.FindGameObjectWithTag("Player") != null)
			{
			GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickMovement>().standStill();
			}
		}

		if (buttonName == "Fire") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFireScript>().InitiateFire();
		}

		if (buttonName == "Jump" && GameObject.FindGameObjectWithTag("Player") != null) {
			if(GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickMovement>().grounded)
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<PirateMovement>().isgrounded = false;
				//GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 900f));
				GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickMovement>().activateJump();
			}
		}



	}


	public void GameOverVisibility(bool x)
	{
		//gameover.SetActive (x);
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

		GameObject[] Flamingo = GameObject.FindGameObjectsWithTag ("Flamingo");
		foreach (GameObject b in Flamingo) {
			Destroy(b);
		}

		GameObject[] eagle = GameObject.FindGameObjectsWithTag ("Eagle");
		foreach (GameObject b in eagle) {
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

		//Destroy any Flock object.
		GameObject flock = GameObject.FindGameObjectWithTag("Flock");
		if (flock != null) {
			Destroy (flock);
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


		GameObject h = (GameObject)Instantiate(hunterPrefab, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.Euler(new Vector3(0f,180f,0f)));
		//gameObject.GetComponent<Collider2D>().name = "StartButton";
		
		GameObject hand = GameObject.Find("PlayHand");
		hand.transform.position = new Vector2(8.089996f, 0.15f);
		//pauseSmallCanvas.SetActive (true);
		sg.activatePlayMode();

		GameObject.FindGameObjectWithTag("smallPause").GetComponent<Image>().enabled = true;
	}

	public void activateCanvas()
	{
		startCanvas.SetActive(true);
	}

	public void disablePauseCanvas()
	{
		//pauseSmallCanvas.SetActive (false);
	}

	IEnumerator startanimation() 
	{
		GameObject startbutton = GameObject.Find ("Start3Buttons");
		Animator anim = startbutton.GetComponent<Animator> ();
		//yield return new WaitForSeconds (1f);
		anim.SetBool ("IsPressed", true);
		yield return new WaitForSeconds (0.7f);

		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().activeCoinCanvas ();

		GameObject temp = (GameObject)Instantiate (progressBar, new Vector2 (progressBar.transform.position.x, progressBar.transform.position.y), Quaternion.identity);
		temp.GetComponent<CircularProgressbar> ().enabled = false;
		GameObject hand = GameObject.Find("PlayHand");
		hand.transform.position = new Vector2(8.089996f, 0.15f);
		//pauseSmallCanvas.SetActive (true);
		pause.GetComponent<Image>().enabled = true;
		//sg.activatePlayMode();
		startCanvas.SetActive(false);
		anim.SetBool ("IsPressed", false);
	}
}
