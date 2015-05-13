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
		if (sc < 1) {
			scoreRenderer.sprite = scoreSprite [0];
				}
		else if (sc < 10) {
						scoreRenderer.sprite = scoreSprite [sc];
				} else {
			int ten = sc/10;
			int unit = sc%10;

			scoreRenderer.sprite = scoreSprite [ten];
			scoreRendererTwo.enabled = true;
			scoreRendererTwo.sprite = scoreSprite [unit];
				}
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
