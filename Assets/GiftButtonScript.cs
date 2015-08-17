using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GiftButtonScript : MonoBehaviour {

	public GameObject gift;
	private GameObject gtemp;
	public float TotalTime = 0;
	private float timeLeft = 0;
	private bool showCanvas = false;

	public Sprite[] numbers;
	Image[] images;

	public GameObject textObject;
	public Sprite freeGiftIn;
	public GameObject timerIcon;
	public GameObject minute;
	int val = 0;
	// Use this for initialization
	void Start () {
		timeLeft = TotalTime;
		timerIcon.SetActive (false);
		//gift = GameObject.Find ("GiftView");
	}
	
	// Update is called once per frame
	void Update () {
		if (showCanvas) {
			timeLeft -= Time.deltaTime;
				}

		if (timeLeft <= 0) {
			showCanvas = false;
			//gift.SetActive(false);
			Destroy(gtemp);
			textObject.GetComponent<SpriteRenderer>().sprite = freeGiftIn;
			timerIcon.SetActive (true);
			minute.GetComponent<SpriteRenderer>().sprite = numbers[6];

			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.resetGiftTimer();

			int sc = PlayerPrefs.GetInt ("Score");
			sc = sc + val;
			PlayerPrefs.SetInt ("Score", sc);
			/*int second = System.DateTime.Now.Second;
			PlayerPrefs.SetInt("GiftTime",second);
			int time = PlayerPrefs.GetInt("GiftTimeLeft");
			Debug.Log("time from GiftButton: " + time);
			if(time <= 0)
			{
				PlayerPrefs.SetInt("GiftTimeLeft",360);
				double t = System.TimeSpan.FromSeconds(360).TotalMinutes;
				time = (int)t;
				minute.GetComponent<SpriteRenderer>().sprite = numbers[time];
			}
			else if(time > 0){
				double t = System.TimeSpan.FromSeconds(time).TotalMinutes;
				time = (int)t;
				minute.GetComponent<SpriteRenderer>().sprite = numbers[time];
				PlayerPrefs.SetInt("GiftTimeLeft",time);
			} */
			Destroy(gameObject);
		}

	}

	void OnMouseUp()
	{
		//gift.SetActive(true);
		showCanvas = true;
		gtemp = (GameObject)Instantiate (gift, new Vector2 (gift.transform.position.x, gift.transform.position.y), Quaternion.identity);

		images = GameObject.Find ("GiftPanel").GetComponentsInChildren<Image> ();

		val = Random.Range(40, 150);
		if (val < 100) {
						int t = val / 10;
						int u = val % 10;

			images[2].sprite = numbers [t];
			images[3].sprite = numbers [u];

				} else {

			int h = val / 100;
			int ht = val % 100;

			int t = ht / 10;
			int u = ht % 10;

			images[1].sprite = numbers[h];
			images[2].sprite = numbers [t];
			images[3].sprite = numbers [u];
				}
	}

}
