﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public Sprite[] scoreSprite;
	public GameObject pauseSmallCanvas;

	//Accuracy variables for gameobject and renderer
	public Image Acc_digitTen;
	public Image Acc_digitUnit;
	/*SpriteRenderer Acc_digitTenRenderer;
	SpriteRenderer Acc_digitUnitRenderer; */

	//Total Coin variables for gameobject and renderer
	public Image coinOne;
	public Image coinTwo;
	public Image coinThree;
	public Image coinFour;
	public Image coinFive;
	//public GameObject coinSix;
	//public GameObject coinSeven;
	/*SpriteRenderer coinOneRender;
	SpriteRenderer coinTwoRender;
	SpriteRenderer coinThreeRender;
	SpriteRenderer coinFourRender;
	SpriteRenderer coinFiveRender;*/
	//SpriteRenderer coinSixRender;
	//SpriteRenderer coinSevenRender;

	//Kill variables for gameobject and renderer
	public Image kill_digitTen;
	public Image kill_digitUnit;
	/*SpriteRenderer kill_digitTenRenderer;
	SpriteRenderer kill_digitUnitRenderer;*/

	//Match Score
	public Image msUnit;
	public Image msTen;
	public Image msHundred;
	public Image msThousand;
	public Image msTenThousand;
	/*SpriteRenderer msUnitRender;
	SpriteRenderer msTenRender;
	SpriteRenderer msHundredRender;
	SpriteRenderer msThousandRender;
	SpriteRenderer msTenThousandRender;*/

	GameObject gameController;
	GameController gc;

	GameObject hunter;
	HunterMovement hm;

	public Image textObject;
	public Sprite freeGiftIn;
	public Sprite freeGift;
	public Image timerIcon;
	public GameObject giftButton;
	public Image minute;
	public Sprite[] numbers;

	private int prevtime = 0;

	// Use this for initialization
	void Start () {

		pauseSmallCanvas = GameObject.FindGameObjectWithTag("pauseSmallCanvas");
		pauseSmallCanvas.SetActive (false);

		GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isEnd", true);
		GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isEnd", true);
		GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isStart", false);
		GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isStart", false);

		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();
		bool status = gc.getGiftTimer ();
		if (status) {
			giftButton.SetActive(false);
			timerIcon.enabled = true;
			textObject.sprite = freeGiftIn;
			int timerLeft = int.Parse(gc.giftTimerLeft ());
			prevtime = timerLeft;
			minute.sprite = numbers [timerLeft];
		} else {
			timerIcon.enabled = false;
			giftButton.SetActive(true);
			textObject.sprite = freeGift;
		}

		/*Acc_digitTenRenderer = Acc_digitTen.GetComponent<SpriteRenderer> ();
		Acc_digitTenRenderer.sprite = scoreSprite [0];
		Acc_digitUnitRenderer = Acc_digitUnit.GetComponent<SpriteRenderer> ();
		Acc_digitUnitRenderer.enabled = false;

		kill_digitTenRenderer = kill_digitTen.GetComponent<SpriteRenderer> ();
		kill_digitTenRenderer.sprite = scoreSprite [0];
		kill_digitUnitRenderer = kill_digitUnit.GetComponent<SpriteRenderer> ();
		kill_digitUnitRenderer.enabled = false;

		coinOneRender = coinOne.GetComponent<SpriteRenderer> ();
		coinOneRender.sprite = scoreSprite [0];
		coinTwoRender = coinTwo.GetComponent<SpriteRenderer> ();
		coinTwoRender.sprite = scoreSprite [0];
		coinThreeRender = coinThree.GetComponent<SpriteRenderer> ();
		coinThreeRender.sprite = scoreSprite [0];
		coinFourRender = coinFour.GetComponent<SpriteRenderer> ();
		coinFourRender.sprite = scoreSprite [0];
		coinFiveRender = coinFive.GetComponent<SpriteRenderer> ();
		coinFiveRender.sprite = scoreSprite [0];*/
		/*coinSixRender = coinSix.GetComponent<SpriteRenderer> ();
		coinSixRender.sprite = scoreSprite [0];
		coinSevenRender = coinSeven.GetComponent<SpriteRenderer> ();
		coinSevenRender.sprite = scoreSprite [0];*/

		/*msUnitRender = msUnit.GetComponent<SpriteRenderer> ();
		msUnitRender.sprite = scoreSprite [0];
		msTenRender = msTen.GetComponent<SpriteRenderer> ();
		msTenRender.sprite = scoreSprite [0];
		msHundredRender = msHundred.GetComponent<SpriteRenderer> ();
		msHundredRender.sprite = scoreSprite [0];
		msThousandRender = msThousand.GetComponent<SpriteRenderer> ();
		msThousandRender.sprite = scoreSprite [0];
		msTenThousandRender = msTenThousand.GetComponent<SpriteRenderer> ();
		msTenThousandRender.sprite = scoreSprite [0];*/

		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();
		//int Hs = PlayerPrefs.GetInt ("HighScore");

		calculateAccuracy ();
		calculateKills ();
		calculateTotalCoins ();
		calculateMatchScore ();

		hunter = GameObject.FindGameObjectWithTag ("Player");
		hm = hunter.GetComponent<HunterMovement> ();
		//gc.setScoreToZero ();
	}

	private void calculateAccuracy()
	{
		//Accuracy
		int birdCount = gc.getBirdKilled (); //(float)matchscore;
		int shotFired = gc.getFireShotNumber (); //hm.getFireShotNumber ();
		float percentage = (float) birdCount / shotFired * 100;

		Debug.Log ("BirdCount: " + birdCount);
		Debug.Log ("shotFired: " + shotFired);
		Debug.Log ("Percentage: " + percentage);

		if (percentage < 1) {
			Acc_digitTen.sprite = scoreSprite [0];
		}
		else if (percentage > 1 && percentage < 10) {
			int percent = (int)percentage;
			Acc_digitTen.sprite = scoreSprite [percent];
		} else if(percentage < 100) {
			int ten = Mathf.FloorToInt(percentage/10f);
			int unit = Mathf.FloorToInt(percentage%10f);

			Acc_digitTen.sprite = scoreSprite [ten];
			Acc_digitUnit.enabled = true;
			Acc_digitUnit.sprite = scoreSprite [unit];
		}
	}

	private void calculateKills()
	{
		//Accuracy
		int birdCount = gc.getBirdKilled (); //(float)matchscore;
		
		if (birdCount < 1) {
			kill_digitTen.sprite = scoreSprite [0];
		}
		else if (birdCount > 1 && birdCount < 10) {
			kill_digitTen.sprite = scoreSprite [birdCount];
		} else {
			int ten = Mathf.FloorToInt(birdCount/10f);
			int unit = Mathf.FloorToInt(birdCount%10f);
			
			kill_digitTen.sprite = scoreSprite [ten];
			kill_digitUnit.enabled = true;
			kill_digitUnit.sprite = scoreSprite [unit];
		}
	} 

	private void calculateTotalCoins()
	{
		int sc = PlayerPrefs.GetInt ("Score");

		Debug.Log ("Total Coins: " + sc);

		//Total Coin Logic
		if (sc < 1) {
			coinOne.sprite = scoreSprite [0];
		}
		else if (sc < 10) {
			coinOne.sprite = scoreSprite [sc];
		} else if (sc >= 10 && sc <= 99) {
			int ten = Mathf.FloorToInt(sc/10f);
			int unit = Mathf.FloorToInt(sc%10f);
			
			coinTwo.sprite = scoreSprite [ten];
			coinOne.sprite = scoreSprite [unit];
		}
		else if (sc >= 100 && sc <= 999) {
			int hund = Mathf.FloorToInt(sc/100f);
			
			int temp = Mathf.FloorToInt(sc%100f);
			
			int ten = Mathf.FloorToInt(temp/10f);
			int unit = Mathf.FloorToInt(temp%10f);
			
			coinThree.sprite = scoreSprite [hund];
			coinTwo.sprite = scoreSprite [ten];
			coinOne.sprite = scoreSprite [unit];
		}
		else if (sc >= 1000 && sc <= 9999) {
			
			int thousand = Mathf.FloorToInt(sc/1000f);
			int temp = Mathf.FloorToInt(sc%1000f);
			
			int hund = Mathf.FloorToInt(temp/100f);
			int tempHun = Mathf.FloorToInt(temp%100f);
			
			int ten = Mathf.FloorToInt(tempHun/10f);
			int unit = Mathf.FloorToInt(tempHun%10f);
			
			coinFour.sprite = scoreSprite [thousand];
			coinThree.sprite = scoreSprite [hund];
			coinTwo.sprite = scoreSprite [ten];
			coinOne.sprite = scoreSprite [unit];
		}
		
		else if (sc >= 10000 && sc <= 99999) {
			
			int Tenthousand = Mathf.FloorToInt(sc/10000f);
			int TTtemp = Mathf.FloorToInt(sc%10000f);
			
			int thousand = Mathf.FloorToInt(TTtemp/1000f);
			int temp = Mathf.FloorToInt(TTtemp%1000f);
			
			int hund = Mathf.FloorToInt(temp/100f);
			int tempHun = Mathf.FloorToInt(temp%100f);
			
			int ten = Mathf.FloorToInt(tempHun/10f);
			int unit = Mathf.FloorToInt(tempHun%10f);
			
			coinFive.sprite = scoreSprite [Tenthousand];
			coinFour.sprite = scoreSprite [thousand];
			coinThree.sprite = scoreSprite [hund];
			coinTwo.sprite = scoreSprite [ten];
			coinOne.sprite = scoreSprite [unit];
		}
	}

	private void calculateMatchScore()
	{
		//Current match score
		int matchscore = PlayerPrefs.GetInt ("MatchScore");
		Debug.Log ("Match Score: " + matchscore);

		if (matchscore < 1) {
			msUnit.sprite = scoreSprite [0];
		}
		else if (matchscore > 1 && matchscore < 10) {
			Debug.Log ("Match Score: " + matchscore);
			msUnit.sprite = scoreSprite [matchscore];
		} else if (matchscore >= 10 && matchscore <= 99) {
			int ten = Mathf.FloorToInt(matchscore/10f);
			int unit = Mathf.FloorToInt(matchscore%10f);
			
			msTen.sprite = scoreSprite [ten];
			msUnit.sprite = scoreSprite [unit];
		}
		else if (matchscore >= 100 && matchscore <= 999) {
			int hund = Mathf.FloorToInt(matchscore/100f);
			
			int temp = Mathf.FloorToInt(matchscore%100f);
			
			int ten = Mathf.FloorToInt(temp/10f);
			int unit = Mathf.FloorToInt(temp%10f);
			
			msHundred.sprite = scoreSprite [hund];
			msTen.sprite = scoreSprite [ten];
			msUnit.sprite = scoreSprite [unit];
		}
		else if (matchscore >= 1000 && matchscore <= 9999) {
			
			int thousand = Mathf.FloorToInt(matchscore/1000f);
			int temp = Mathf.FloorToInt(matchscore%1000f);
			
			int hund = Mathf.FloorToInt(temp/100f);
			int tempHun = Mathf.FloorToInt(temp%100f);
			
			int ten = Mathf.FloorToInt(tempHun/10f);
			int unit = Mathf.FloorToInt(tempHun%10f);
			
			msThousand.sprite = scoreSprite [thousand];
			msHundred.sprite = scoreSprite [hund];
			msTen.sprite = scoreSprite [ten];
			msUnit.sprite = scoreSprite [unit];
		}
		
		else if (matchscore >= 10000 && matchscore <= 99999) {
			
			int Tenthousand = Mathf.FloorToInt(matchscore/10000f);
			int TTtemp = Mathf.FloorToInt(matchscore%10000f);
			
			int thousand = Mathf.FloorToInt(TTtemp/1000f);
			int temp = Mathf.FloorToInt(TTtemp%1000f);
			
			int hund = Mathf.FloorToInt(temp/100f);
			int tempHun = Mathf.FloorToInt(temp%100f);
			
			int ten = Mathf.FloorToInt(tempHun/10f);
			int unit = Mathf.FloorToInt(tempHun%10f);
			
			msTenThousand.sprite = scoreSprite [Tenthousand];
			msThousand.sprite = scoreSprite [thousand];
			msHundred.sprite = scoreSprite [hund];
			msTen.sprite = scoreSprite [ten];
			msUnit.sprite = scoreSprite [unit];
		}

	}

	// Update is called once per frame
	void Update () {
		int timerLeft = int.Parse(gc.giftTimerLeft ());
		if (prevtime != timerLeft) {
			prevtime = timerLeft;
			minute.sprite = numbers [timerLeft];
		}
	}
}
