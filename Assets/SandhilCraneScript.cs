﻿using UnityEngine;
using System.Collections;

public class SandhilCraneScript : MonoBehaviour {

	public bool isHit = false;
	public float birdSpeed = 1.5f;
	float birdLife = 0;
	private int randX;
	public float y1 = 3.692791f;
	public GameObject coin;
	private GameObject hunter;
	private PirateMovement hm;
	private GameObject gameController;
	private GameController gc;
	private bool hunterIdle = false;
	private float[] pos = { 10.8f , 5.1f };

	IEnumerator Start () {

		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();

		hunter = GameObject.FindGameObjectWithTag ("Player");
		hm = hunter.GetComponent<PirateMovement> ();

		birdLife = 0;
		
		randX = Random.Range (0, 2);

		while (true) {
			y1 = Random.Range(0.8f, 2.6f);
			yield return StartCoroutine(MoveObject(transform, new Vector2(5.1f,y1), new Vector2(10.8f, y1), birdSpeed));
			y1 = Random.Range(0.8f, 2.6f);
			yield return StartCoroutine(MoveObject(transform, new Vector2(10.8f,y1), new Vector2(5.1f, y1), birdSpeed));
				}

	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector2 startPos, Vector2 endPos, float time) {
		float i=0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			if(hunterIdle)
			{
				birdSpeed = 0.75f;
			}
			thisTransform.position = Vector2.Lerp(startPos, endPos, i);
			yield return null;
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x == 10.8f || transform.position.x == 5.1f) {
			Flip ();
			if(hunterIdle)
			{
				Destroy(gameObject);
			}
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}
		
		if(col.gameObject.name == "StartButton") {
			return;
		}
		
		if (col.gameObject.tag == "Bullet") {
			gameObject.GetComponent<Collider2D>().enabled = false;
			GameObject co = (GameObject)Instantiate(coin, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			//hm.incrementBirdCount();
			//BirdHit ();
			gc.increaseBirdKiled();
			gc.setScore (2);
			gc.incrementBirdCount();
			Destroy(gameObject);
			Destroy (col.gameObject);
		}
	}

	public void setHunterIdle()
	{
		hunterIdle = true;
	}

	void Flip()
	{
		gameObject.transform.Rotate (0,180,0);
	}

}
