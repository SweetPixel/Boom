
using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public Sprite[] scoreSprite;
	//public Sprite score;
	//public Sprite scoreTwo;
	//public Sprite best;
	//public Sprite bestTwo;

	//Accuracy variables for gameobject and renderer
	public GameObject Acc_digitTen;
	public GameObject Acc_digitUnit;
	SpriteRenderer Acc_digitTenRenderer;
	SpriteRenderer Acc_digitUnitRenderer;

	//Total Coin variables for gameobject and renderer
	public GameObject coinOne;
	public GameObject coinTwo;
	public GameObject coinThree;
	public GameObject coinFour;
	public GameObject coinFive;
	//public GameObject coinSix;
	//public GameObject coinSeven;
	SpriteRenderer coinOneRender;
	SpriteRenderer coinTwoRender;
	SpriteRenderer coinThreeRender;
	SpriteRenderer coinFourRender;
	SpriteRenderer coinFiveRender;
	//SpriteRenderer coinSixRender;
	//SpriteRenderer coinSevenRender;

	//Kill variables for gameobject and renderer
	public GameObject kill_digitTen;
	public GameObject kill_digitUnit;
	SpriteRenderer kill_digitTenRenderer;
	SpriteRenderer kill_digitUnitRenderer;

	//Match Score
	public GameObject msUnit;
	public GameObject msTen;
	public GameObject msHundred;
	public GameObject msThousand;
	public GameObject msTenThousand;
	SpriteRenderer msUnitRender;
	SpriteRenderer msTenRender;
	SpriteRenderer msHundredRender;
	SpriteRenderer msThousandRender;
	SpriteRenderer msTenThousandRender;

	GameObject hunter;
	HunterMovement hm;

	// Use this for initialization
	void Start () {

		Acc_digitTenRenderer = Acc_digitTen.GetComponent<SpriteRenderer> ();
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
		coinFiveRender.sprite = scoreSprite [0];
		/*coinSixRender = coinSix.GetComponent<SpriteRenderer> ();
		coinSixRender.sprite = scoreSprite [0];
		coinSevenRender = coinSeven.GetComponent<SpriteRenderer> ();
		coinSevenRender.sprite = scoreSprite [0];*/

		msUnitRender = msUnit.GetComponent<SpriteRenderer> ();
		msUnitRender.sprite = scoreSprite [0];
		msTenRender = msTen.GetComponent<SpriteRenderer> ();
		msTenRender.sprite = scoreSprite [0];
		msHundredRender = msHundred.GetComponent<SpriteRenderer> ();
		msHundredRender.sprite = scoreSprite [0];
		msThousandRender = msThousand.GetComponent<SpriteRenderer> ();
		msThousandRender.sprite = scoreSprite [0];
		msTenThousandRender = msTenThousand.GetComponent<SpriteRenderer> ();
		msTenThousandRender.sprite = scoreSprite [0];

		hunter = GameObject.FindGameObjectWithTag ("Player");
		hm = hunter.GetComponent<HunterMovement> ();
		//int Hs = PlayerPrefs.GetInt ("HighScore");

		calculateAccuracy ();
		calculateKills ();
		calculateTotalCoins ();
		calculateMatchScore ();

		GameObject h = GameObject.FindGameObjectWithTag ("Player");
		HunterMovement hRestart = h.GetComponent<HunterMovement> ();
		hRestart.setScoreToZero ();
	}

	private void calculateAccuracy()
	{
		//Accuracy
		int birdCount = hm.getBirdKilled (); //(float)matchscore;
		int shotFired = hm.getFireShotNumber ();
		float percentage = (float) birdCount / shotFired * 100;

		Debug.Log ("BirdCount: " + birdCount);
		Debug.Log ("shotFired: " + shotFired);
		Debug.Log ("Percentage: " + percentage);

		if (percentage < 1) {
			Acc_digitTenRenderer.sprite = scoreSprite [0];
		}
		else if (percentage > 1 && percentage < 10) {
			int percent = (int)percentage;
			Acc_digitTenRenderer.sprite = scoreSprite [percent];
		} else {
			int ten = Mathf.FloorToInt(percentage/10f);
			int unit = Mathf.FloorToInt(percentage%10f);

			Acc_digitTenRenderer.sprite = scoreSprite [ten];
			Acc_digitUnitRenderer.enabled = true;
			Acc_digitUnitRenderer.sprite = scoreSprite [unit];
		}
	}

	private void calculateKills()
	{
		//Accuracy
		int birdCount = hm.getBirdKilled (); //(float)matchscore;
		
		if (birdCount < 1) {
			kill_digitTenRenderer.sprite = scoreSprite [0];
		}
		else if (birdCount > 1 && birdCount < 10) {
			kill_digitTenRenderer.sprite = scoreSprite [birdCount];
		} else {
			int ten = Mathf.FloorToInt(birdCount/10f);
			int unit = Mathf.FloorToInt(birdCount%10f);
			
			kill_digitTenRenderer.sprite = scoreSprite [ten];
			kill_digitUnitRenderer.enabled = true;
			kill_digitUnitRenderer.sprite = scoreSprite [unit];
		}
	}

	private void calculateTotalCoins()
	{
		int sc = PlayerPrefs.GetInt ("Score");

		Debug.Log ("Total Coins: " + sc);

		//Total Coin Logic
		if (sc < 1) {
			coinOneRender.sprite = scoreSprite [0];
		}
		else if (sc < 10) {
			coinOneRender.sprite = scoreSprite [sc];
		} else if (sc >= 10 && sc <= 99) {
			int ten = Mathf.FloorToInt(sc/10f);
			int unit = Mathf.FloorToInt(sc%10f);
			
			coinTwoRender.sprite = scoreSprite [ten];
			coinOneRender.sprite = scoreSprite [unit];
		}
		else if (sc >= 100 && sc <= 999) {
			int hund = Mathf.FloorToInt(sc/100f);
			
			int temp = Mathf.FloorToInt(sc%100f);
			
			int ten = Mathf.FloorToInt(temp/10f);
			int unit = Mathf.FloorToInt(temp%10f);
			
			coinThreeRender.sprite = scoreSprite [hund];
			coinTwoRender.sprite = scoreSprite [ten];
			coinOneRender.sprite = scoreSprite [unit];
		}
		else if (sc >= 1000 && sc <= 9999) {
			
			int thousand = Mathf.FloorToInt(sc/1000f);
			int temp = Mathf.FloorToInt(sc%1000f);
			
			int hund = Mathf.FloorToInt(temp/100f);
			int tempHun = Mathf.FloorToInt(temp%100f);
			
			int ten = Mathf.FloorToInt(tempHun/10f);
			int unit = Mathf.FloorToInt(tempHun%10f);
			
			coinFourRender.sprite = scoreSprite [thousand];
			coinThreeRender.sprite = scoreSprite [hund];
			coinTwoRender.sprite = scoreSprite [ten];
			coinOneRender.sprite = scoreSprite [unit];
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
			
			coinFiveRender.sprite = scoreSprite [Tenthousand];
			coinFourRender.sprite = scoreSprite [thousand];
			coinThreeRender.sprite = scoreSprite [hund];
			coinTwoRender.sprite = scoreSprite [ten];
			coinOneRender.sprite = scoreSprite [unit];
		}
	}

	private void calculateMatchScore()
	{
		//Current match score
		int matchscore = PlayerPrefs.GetInt ("MatchScore");

		if (matchscore < 1) {
			Debug.Log ("Match Score: " + matchscore);
			msUnitRender.sprite = scoreSprite [0];
		}
		else if (matchscore > 1 && matchscore < 10) {
			Debug.Log ("Match Score: " + matchscore);
			msUnitRender.sprite = scoreSprite [matchscore];
		} else if (matchscore >= 10 && matchscore <= 99) {
			int ten = Mathf.FloorToInt(matchscore/10f);
			int unit = Mathf.FloorToInt(matchscore%10f);
			
			msTenRender.sprite = scoreSprite [ten];
			msUnitRender.sprite = scoreSprite [unit];
		}
		else if (matchscore >= 100 && matchscore <= 999) {
			int hund = Mathf.FloorToInt(matchscore/100f);
			
			int temp = Mathf.FloorToInt(matchscore%100f);
			
			int ten = Mathf.FloorToInt(temp/10f);
			int unit = Mathf.FloorToInt(temp%10f);
			
			msHundredRender.sprite = scoreSprite [hund];
			msTenRender.sprite = scoreSprite [ten];
			msUnitRender.sprite = scoreSprite [unit];
		}
		else if (matchscore >= 1000 && matchscore <= 9999) {
			
			int thousand = Mathf.FloorToInt(matchscore/1000f);
			int temp = Mathf.FloorToInt(matchscore%1000f);
			
			int hund = Mathf.FloorToInt(temp/100f);
			int tempHun = Mathf.FloorToInt(temp%100f);
			
			int ten = Mathf.FloorToInt(tempHun/10f);
			int unit = Mathf.FloorToInt(tempHun%10f);
			
			msThousandRender.sprite = scoreSprite [thousand];
			msHundredRender.sprite = scoreSprite [hund];
			msTenRender.sprite = scoreSprite [ten];
			msUnitRender.sprite = scoreSprite [unit];
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
			
			msTenThousandRender.sprite = scoreSprite [Tenthousand];
			msThousandRender.sprite = scoreSprite [thousand];
			msHundredRender.sprite = scoreSprite [hund];
			msTenRender.sprite = scoreSprite [ten];
			msUnitRender.sprite = scoreSprite [unit];
		}

	}

	// Update is called once per frame
	void Update () {
	
	}
}
