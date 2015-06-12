using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public Sprite[] scoreSprite;
	//public Sprite score;
	//public Sprite scoreTwo;
	//public Sprite best;
	//public Sprite bestTwo;

	SpriteRenderer scoreRenderer;
	SpriteRenderer scoreRendererTwo;

	SpriteRenderer coinOneRender;
	SpriteRenderer coinTwoRender;
	SpriteRenderer coinThreeRender;
	SpriteRenderer coinFourRender;
	SpriteRenderer coinFiveRender;
	SpriteRenderer coinSixRender;
	SpriteRenderer coinSevenRender;

	public GameObject scoreObject;
	public GameObject scoreObjectTwo;

	public GameObject coinOne;
	public GameObject coinTwo;
	public GameObject coinThree;
	public GameObject coinFour;
	public GameObject coinFive;
	public GameObject coinSix;
	public GameObject coinSeven;

	// Use this for initialization
	void Start () {

		scoreRenderer = scoreObject.GetComponent<SpriteRenderer> ();
		scoreRenderer.sprite = scoreSprite [0];
		
		scoreRendererTwo = scoreObjectTwo.GetComponent<SpriteRenderer> ();
		scoreRendererTwo.enabled = false;

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

		coinSixRender = coinSix.GetComponent<SpriteRenderer> ();
		coinSixRender.sprite = scoreSprite [0];

		coinSevenRender = coinSeven.GetComponent<SpriteRenderer> ();
		coinSevenRender.sprite = scoreSprite [0];

		int sc = PlayerPrefs.GetInt ("Score");
		int Hs = PlayerPrefs.GetInt ("HighScore");

		int matchscore = PlayerPrefs.GetInt ("MatchScore");
		float score = (float)matchscore;
		float percentage = score / 50f * 100;

		if (percentage < 1) {
			scoreRenderer.sprite = scoreSprite [0];
				}
		else if (percentage < 10) {
						scoreRenderer.sprite = scoreSprite [sc];
				} else {
			int ten = Mathf.FloorToInt(percentage/10f);
			int unit = Mathf.FloorToInt(percentage%10f);

			scoreRenderer.sprite = scoreSprite [ten];
			scoreRendererTwo.enabled = true;
			scoreRendererTwo.sprite = scoreSprite [unit];
				}

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

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
