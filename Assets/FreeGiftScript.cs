using UnityEngine;
using System.Collections;

public class FreeGiftScript : MonoBehaviour {

	public GameObject textObject;
	public Sprite freeGiftIn;
	public Sprite freeGift;
	public GameObject timerIcon;
	public GameObject giftButton;
	public GameObject minute;
	public Sprite[] numbers;

	private int prevtime = 0;
	GameObject gcc;
	GameController gc;
	// Use this for initialization
	void Start () {

		GameObject gcc = GameObject.FindGameObjectWithTag ("GameController");
		GameController gc = gcc.GetComponent<GameController> ();
		bool status = gc.getGiftTimer ();
		if (status) {
			giftButton.SetActive(false);
			timerIcon.SetActive(true);
			textObject.GetComponent<SpriteRenderer> ().sprite = freeGiftIn;
			int timerLeft = int.Parse(gc.giftTimerLeft ());
			prevtime = timerLeft;
			minute.GetComponent<SpriteRenderer> ().sprite = numbers [timerLeft];
		} else {
			timerIcon.SetActive(false);
			giftButton.SetActive(true);
			textObject.GetComponent<SpriteRenderer> ().sprite = freeGift;
		}
		/*int second= PlayerPrefs.GetInt ("GiftTime");
		int diff = System.DateTime.Today.Minute*60 - second;
		int timeLeft = PlayerPrefs.GetInt ("GiftTimeLeft");
		Debug.Log ("milliSecond: " + second);
		Debug.Log ("diff: " + diff);
		Debug.Log ("timeLeft: " + timeLeft);
		if (diff > 0) 
		{
			giftButton.SetActive(false);
			timerIcon.SetActive(true);
			textObject.GetComponent<SpriteRenderer> ().sprite = freeGiftIn;
			double t = System.TimeSpan.FromSeconds(timeLeft).TotalMinutes;
			timeLeft = (int)t;
			minute.GetComponent<SpriteRenderer>().sprite = numbers[timeLeft];
			diff = 360 - diff;
			PlayerPrefs.SetInt ("GiftTimeLeft", diff);
		} 
		else if (timeLeft <= 0)  {
			timerIcon.SetActive(false);
			giftButton.SetActive(true);
			PlayerPrefs.SetInt ("GiftTimeLeft", 0);
			textObject.GetComponent<SpriteRenderer> ().sprite = freeGift;
		} */
	}
	
	// Update is called once per frame
	void Update () {
		int timerLeft = int.Parse(gc.giftTimerLeft ());
		if (prevtime != timerLeft) {
			prevtime = timerLeft;
			minute.GetComponent<SpriteRenderer> ().sprite = numbers [timerLeft];
				}
	}
}
