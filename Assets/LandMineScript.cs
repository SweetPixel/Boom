﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LandMineScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log(col.gameObject.tag);

		if (col.gameObject.tag == "Bullet") {
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			gameObject.GetComponent<Animator>().SetBool("isGrounded", true);
			//Destroy(gameObject,0.2f);
			gameObject.SetActive(false);
			col.gameObject.SetActive(false);
			//Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "Platform") {
			gameObject.GetComponent<CircleCollider2D>().enabled = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
			gameObject.GetComponent<Animator>().SetBool("isGrounded", true);
			//Destroy(gameObject, 1f);
			gameObject.SetActive(false);
		}
		
		if (col.gameObject.tag == "Player") {
			gameObject.SetActive(false);
			col.gameObject.GetComponentInChildren<Image> ().fillAmount -= (gameObject.GetComponent<DamageScript> ().Damage * 1f) / 100f;
			if (col.gameObject.GetComponentInChildren<Image> ().fillAmount <= 0.2f) {
				GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
				GameController gc = gcc.GetComponent<GameController>();
				gc.GameOver();
				Destroy (col.gameObject);
			}
		}
		
	}

}
