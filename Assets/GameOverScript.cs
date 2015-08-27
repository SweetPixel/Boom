using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public Sprite[] scoreSprite;
	public GameObject gamecontroller;

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
	/*public Image msUnit;
	public Image msTen;
	public Image msHundred;
	public Image msThousand;
	public Image msTenThousand;*/
	/*SpriteRenderer msUnitRender;
	SpriteRenderer msTenRender;
	SpriteRenderer msHundredRender;
	SpriteRenderer msThousandRender;
	SpriteRenderer msTenThousandRender;*/

	GameObject gameController;
	GameController gc;

	GameObject hunter;
	HunterMovement hm;

	//public Image textObject;
	public Sprite freeGiftIn;
	public Sprite freeGift;
	public Image timerIcon;
	public GameObject giftButton;
	public Text minute;
	public Sprite[] numbers;

	private int prevtime = 0;
	private int counter = 0;
	private bool startTimer = true;
	Image label;

	public Text msTenThousand;
	public Text msThousand;
	public Text msHundred;
	public Text msTen;
	public Text msUnit;

	public Text tcTenThousand;
	public Text tcThousand;
	public Text tcHundred;
	public Text tcTen;
	public Text tcUnit;

	public Text accuracy;
	public Text kill;
	float percentage = 0f;

	public Sprite goldBadge;
	public Sprite silverBadge;
	public Sprite bronzeBadge;

	public Text freeGiftText;

	// Use this for initialization
	void Start () {

		gamecontroller = GameObject.FindGameObjectWithTag("GameController");
		gamecontroller.GetComponent<ButtonClickScript> ().PauseCanvasVisibility (true);

		StartCoroutine (Wait());

		//label = GameObject.FindGameObjectWithTag ("FreeGiftIn_Label").GetComponent<Image> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();
		bool status = gc.getGiftTimer ();
		Debug.Log (status);
		if (status) {
			giftButton.SetActive(false);
			timerIcon.enabled = true;
			//textObject.sprite = freeGiftIn;
			//label.sprite = freeGiftIn;
			//label.transform.localScale = new Vector2(1.3f, 1.3f);
			freeGiftText.text = "FREE GIFT IN";
			//textObject.enabled = false;
			int timerLeft = int.Parse(gc.giftTimerLeft ());
			prevtime = timerLeft;
			minute.text = "6:00"; //numbers [timerLeft];
		} else {
			timerIcon.enabled = false;
			Debug.Log (label);
			giftButton.SetActive(true);
			freeGiftText.text = "FREE GIFT";
			//label.sprite = freeGift;
			//label.transform.localScale = new Vector2(1.1f, 1.1f);
			//textObject.enabled = true;
		}

		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();

		calculateAccuracy ();
		calculateKills ();
		calculateTotalCoins ();
		calculateMatchScore ();

		hunter = GameObject.FindGameObjectWithTag ("Player");
		hm = hunter.GetComponent<HunterMovement> ();
		//gc.setScoreToZero ();

		GameObject progressbar = GameObject.FindGameObjectWithTag("ProgressBar");
		if (progressbar != null) {
			progressbar.SetActive (false);
				}


	}

	IEnumerator Wait()
	{
		GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isEnd", true);
		GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isEnd", true);
		GameObject.FindGameObjectWithTag("ButtonCountDown").GetComponent<Animator>().SetBool("isStart", false);
		GameObject.FindGameObjectWithTag("CoinObject").GetComponent<Animator>().SetBool("isStart", false);
		yield return new WaitForSeconds (0.2f);
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().disableCoinCanvas ();
	}


	private void calculateAccuracy()
	{
		//Accuracy
		int birdCount = gc.getBirdKilled (); //(float)matchscore;
		int shotFired = gc.getFireShotNumber (); //hm.getFireShotNumber ();
		percentage = (float) birdCount / shotFired * 100;

		/*Debug.Log ("BirdCount: " + birdCount);
		Debug.Log ("shotFired: " + shotFired);
		Debug.Log ("Percentage: " + percentage);*/

		if((int)percentage >100)
		{
			percentage = 100;
		}

		accuracy.text = ((int)percentage).ToString();

		/*if (percentage < 1) {
			Acc_digitUnit.sprite = scoreSprite [0];
		}
		else if (percentage > 1 && percentage < 10) {
			int percent = (int)percentage;
			Acc_digitUnit.sprite = scoreSprite [percent];
		} else if(percentage < 100) {
			int ten = Mathf.FloorToInt(percentage/10f);
			int unit = Mathf.FloorToInt(percentage%10f);

			Acc_digitTen.sprite = scoreSprite [ten];
			Acc_digitUnit.enabled = true;
			Acc_digitUnit.sprite = scoreSprite [unit];
		}
		else if(percentage >= 100) {
			Acc_digitTen.sprite = scoreSprite [9];
			Acc_digitUnit.sprite = scoreSprite [9];
		}*/
	}

	private void calculateKills()
	{
		//Accuracy
		int birdCount = gc.getBirdKilled (); //(float)matchscore;

		kill.text = birdCount.ToString ();

		if (percentage > 75 && birdCount > 15) 
		{
			GameObject.FindGameObjectWithTag("Badge").GetComponent<Image>().sprite = silverBadge;
		}
		else if (percentage > 50 && birdCount > 30) 
		{
			GameObject.FindGameObjectWithTag("Badge").GetComponent<Image>().sprite = goldBadge;
		}
		else if (percentage < 10 && birdCount < 15) 
		{
			GameObject.FindGameObjectWithTag("Badge").GetComponent<Image>().sprite = bronzeBadge;
		}
		/*if (birdCount < 1) {
			kill_digitUnit.sprite = scoreSprite [0];
		}
		else if (birdCount > 1 && birdCount < 10) {
			kill_digitUnit.sprite = scoreSprite [birdCount];
		} else {
			int ten = Mathf.FloorToInt(birdCount/10f);
			int unit = Mathf.FloorToInt(birdCount%10f);
			
			kill_digitTen.sprite = scoreSprite [ten];
			kill_digitUnit.enabled = true;
			kill_digitUnit.sprite = scoreSprite [unit];
		}*/
	} 

	public void calculateTotalCoins()
	{
		int sc = PlayerPrefs.GetInt ("Score");

		Debug.Log ("Total Coins: " + sc);

		if (sc < 10) {
			tcTenThousand.text = "0";
			tcThousand.text = "0";
			tcHundred.text = "0";
			tcTen.text = "0";
			tcUnit.text = sc.ToString ();
				} 
		else if (sc >= 10 && sc < 100) 
		{
			tcTenThousand.text = "0";
			tcThousand.text = "0";
			tcHundred.text = "0";

			int ten = sc/10;
			int unit = sc%10;

			tcTen.text = ten.ToString();
			tcUnit.text = unit.ToString ();
		}
		else if (sc >= 100 && sc < 1000) 
		{
			tcTenThousand.text = "0";
			tcThousand.text = "0";

			int hundred = sc/100;
			int temp = sc%100;

			int ten = temp/10;
			int unit = temp%10;

			tcHundred.text = hundred.ToString();
			tcTen.text = ten.ToString();
			tcUnit.text = unit.ToString ();
		}
		else if (sc >= 1000 && sc < 10000) 
		{
			tcTenThousand.text = "0";

			int thousand = sc/1000;
			int Thtemp = sc%1000;
			
			int hundred = Thtemp/100;
			int temp = Thtemp%100;
			
			int ten = temp/10;
			int unit = temp%10;

			
			tcThousand.text = thousand.ToString();
			tcHundred.text = hundred.ToString();
			tcTen.text = ten.ToString();
			tcUnit.text = unit.ToString ();
		}
		else if (sc >= 10000) 
		{
			int tenThousand = sc/10000;
			int tenThTemp = sc%10000;
			
			int thousand = tenThTemp/1000;
			int Thtemp = tenThTemp%1000;
			
			int hundred = Thtemp/100;
			int temp = Thtemp%100;
			
			int ten = temp/10;
			int unit = temp%10;

			tcTenThousand.text = tenThousand.ToString();
			tcThousand.text = thousand.ToString();
			tcHundred.text = hundred.ToString();
			tcTen.text = ten.ToString();
			tcUnit.text = unit.ToString ();
		}


		//Total Coin Logic
		/*if (sc < 1) {
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
		}*/
	}

	private void calculateMatchScore()
	{
		//Current match score
		int matchscore = PlayerPrefs.GetInt ("MatchScore");
		Debug.Log ("Match Score: " + matchscore);

		if (matchscore < 10) {
			msTenThousand.text = "0";
			msThousand.text = "0";
			msHundred.text = "0";
			msTen.text = "0";
			msUnit.text = matchscore.ToString ();
		} 
		else if (matchscore >= 10 && matchscore < 100) 
		{
			msTenThousand.text = "0";
			msThousand.text = "0";
			msHundred.text = "0";
			
			int ten = matchscore/10;
			int unit = matchscore%10;
			
			msTen.text = ten.ToString();
			msUnit.text = unit.ToString ();
		}
		else if (matchscore >= 100 && matchscore < 1000) 
		{
			msTenThousand.text = "0";
			msThousand.text = "0";
			
			int hundred = matchscore/100;
			int temp = matchscore%100;
			
			int ten = temp/10;
			int unit = temp%10;
			
			msHundred.text = hundred.ToString();
			msTen.text = ten.ToString();
			msUnit.text = unit.ToString ();
		}
		else if (matchscore >= 1000 && matchscore < 10000) 
		{
			msTenThousand.text = "0";
			
			int thousand = matchscore/1000;
			int Thtemp = matchscore%1000;
			
			int hundred = Thtemp/100;
			int temp = Thtemp%100;
			
			int ten = temp/10;
			int unit = temp%10;
			
			
			msThousand.text = thousand.ToString();
			msHundred.text = hundred.ToString();
			msTen.text = ten.ToString();
			msUnit.text = unit.ToString ();
		}
		else if (matchscore >= 10000) 
		{
			int tenThousand = matchscore/10000;
			int tenThTemp = matchscore%10000;
			
			int thousand = tenThTemp/1000;
			int Thtemp = tenThTemp%1000;
			
			int hundred = Thtemp/100;
			int temp = Thtemp%100;
			
			int ten = temp/10;
			int unit = temp%10;
			
			msTenThousand.text = tenThousand.ToString();
			msThousand.text = thousand.ToString();
			msHundred.text = hundred.ToString();
			msTen.text = ten.ToString();
			msUnit.text = unit.ToString ();
		}
		
		/*if (matchscore < 1) {
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
		}*/

	}

	public void UpdateTotalCoins()
	{

	}

	// Update is called once per frame
	void Update () {

		if (startTimer) {
			//label = GameObject.FindGameObjectWithTag ("FreeGiftIn_Label").GetComponent<Image> ();
			int timerLeft = int.Parse(gc.giftTimerLeft ());
			if (prevtime != timerLeft && timerLeft > 0) {
				prevtime = timerLeft;
				minute.text = timerLeft.ToString() + ":00";
			}
			/*if (timerLeft > 0) {
				giftButton.SetActive(false);
				timerIcon.enabled = true;
				//textObject.sprite = freeGiftIn;
				label.enabled = true;
				textObject.enabled = false;
				int t = int.Parse(gc.giftTimerLeft ());
				prevtime = t;
				minute.sprite = numbers [t];
			} else {
				timerIcon.enabled = false;
				giftButton.SetActive(true);
				label.enabled = false;
				textObject.enabled = true;
			}*/
		}
	}
}
