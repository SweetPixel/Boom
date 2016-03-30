﻿using UnityEngine;
using System.Collections;

public class CarrotMovement : MonoBehaviour {

	public float speed = 3f;
	
	// Use this for initialization
	void Start () {
		StartCoroutine(MoveObject(transform, transform.position, new Vector3(-8f, -1.65f, 0f), speed));
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x < -7f) {
			Destroy(gameObject);
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Platform") {
			return;
		}
		
		if (col.gameObject.tag == "Player") {
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.GameOver();
			Destroy(col.gameObject);
		}
		
	}

}