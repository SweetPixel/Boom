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
	SpriteRenderer bestRenderer;
	SpriteRenderer bestRendererTwo;

	public GameObject scoreObject;
	public GameObject scoreObjectTwo;
	public GameObject bestObject;
	public GameObject bestObjectTwo;

	// Use this for initialization
	void Start () {

		scoreRenderer = scoreObject.GetComponent<SpriteRenderer> ();
		scoreRenderer.sprite = scoreSprite [0];
		
		scoreRendererTwo = scoreObjectTwo.GetComponent<SpriteRenderer> ();
		scoreRendererTwo.enabled = false;

		bestRenderer = bestObject.GetComponent<SpriteRenderer> ();
		bestRenderer.sprite = scoreSprite [0];
		
		bestRendererTwo = bestObjectTwo.GetComponent<SpriteRenderer> ();
		bestRendererTwo.enabled = false;

		int sc = PlayerPrefs.GetInt ("Score");
		int Hs = PlayerPrefs.GetInt ("HighScore");

		Debug.Log ("Score: " + sc);

		float score = (float)sc;
		float percentage = score / 50f * 100;

		Debug.Log ("Percentage: " + percentage);

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

		/*if (percentage < 1) {
			scoreRenderer.sprite = scoreSprite [0];
		}
		else if (percentage < 10) {
			scoreRenderer.sprite = scoreSprite [sc];
		} else {
			int ten = percentage/10;
			int unit = percentage%10;
			
			scoreRenderer.sprite = scoreSprite [ten];
			scoreRendererTwo.enabled = true;
			scoreRendererTwo.sprite = scoreSprite [unit];
		} */

		if (Hs < 1) {
			bestRenderer.sprite = scoreSprite [0];
		}
		else if (Hs < 10) {
			bestRenderer.sprite = scoreSprite [Hs];
		} else {
			int ten = Hs/10;
			int unit = Hs%10;
			
			bestRenderer.sprite = scoreSprite [ten];
			bestRendererTwo.enabled = true;
			bestRendererTwo.sprite = scoreSprite [unit];
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
