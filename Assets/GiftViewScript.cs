using UnityEngine;
using System.Collections;

public class GiftViewScript : MonoBehaviour {

	public float TotalTime = 3;
	private float timeLeft = 0;
	private GameObject gc;

	void Awake()
	{
		gc = GameObject.FindGameObjectWithTag ("GameController");
	}

	// Use this for initialization
	void Start () {
		timeLeft = TotalTime;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			gc.GetComponent<ButtonClickScript>().GameOverVisibility(true);
			Destroy(gameObject);
				}

	}
}
