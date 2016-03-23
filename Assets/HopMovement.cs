﻿using UnityEngine;
using System.Collections;

public class HopMovement : MonoBehaviour {

	/*public float amplitudeX = -1.0f;
	public float amplitudeY = 1.0f;
	public float omegaX = 1.0f;
	public float omegaY = 2.0f;
	float index;*/
	private bool isgrounded= true;
	public float timeOnGround = 2f;
	public float amplitudeX = 100f;
	public float amplitudeY = 300f;
	
	void Start()
	{
		//transform.localPosition = new Vector3 (10.0f, gameObject.transform.position.y, 0f);
		StartCoroutine(hop ());

	}
	
	public void Update(){
		//index += Time.smoothDeltaTime;
		//float x = amplitudeX*Mathf.Sin(index * omegaX);
		//float y = amplitudeY*Mathf.Sin (omegaY*index);
		//transform.localPosition= transform.localPosition +  new Vector3(-0.1f,0.1f,0);
	}

	IEnumerator hop()
	{
		while (true) {
			//transform.localPosition= transform.localPosition +  new Vector3(-2f,2f,0) * Time.time;
			if(isgrounded)
			{
				isgrounded = false;
				gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.up * amplitudeY) + (-Vector2.right * amplitudeX));
				//yield return new WaitForSeconds(2f);
			}
			else if(!isgrounded){
				yield return new WaitForSeconds(timeOnGround);
			}
		}


	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Platform") {
			isgrounded = true;
			Debug.Log("Kangaroo hit is onGround");
			return;
		}

		if (col.gameObject.tag == "Obstacle") {
			return;
		}

		if (col.gameObject.tag == "Player") {
			if(col.gameObject.GetComponent<PirateMovement>().isgrounded == true)
			{
				Debug.Log("Player is grounded " + col.gameObject.GetComponent<PirateMovement>().isgrounded);
				GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
				GameController gc = gcc.GetComponent<GameController>();
				gc.GameOver();
				Destroy(GameObject.Find("Shadow"));
				Destroy(col.gameObject);
			}
			else {
				if(col.gameObject.transform.position.y > gameObject.transform.position.y && col.gameObject.transform.position.y > -1)
				{
					Destroy (gameObject);
				}
				else{
					GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
					GameController gc = gcc.GetComponent<GameController>();
					gc.GameOver();
					Destroy(GameObject.Find("Shadow"));
					Destroy(col.gameObject);
				}
				//Destroy (gameObject.transform.parent.gameObject);
			}
		}
		
	}
}
