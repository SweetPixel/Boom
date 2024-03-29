﻿using UnityEngine;
using System.Collections;

public class MoverInfinite : MonoBehaviour {

	
	private bool faceleft=false;
	bool isLeft = false;
	bool Samedirection = false;
	bool isHit = false;
	public float birdSpeed = 1.5f;

	public float x1 = 3f;
	public float x2 = 5.2f;
	public float y1 = 3.692791f;
	public float y2 = 2.0f;

	// Use this for initialization
	IEnumerator Start () {
		//rigidbody.velocity = transform.right * 2;

		Vector3 pointA = transform.position;
		//float time = 1.5f;

		x1 = 9.5f;
		x2 = 5.2f;
		y2 = 2.0f;
		
		yield return StartCoroutine(MoveObject(transform, new Vector2(4.1f, 2.0f), new Vector2(x1, 2.0f), birdSpeed));
		yield return StartCoroutine(MoveObject(transform, new Vector2(x1, 2.0f), new Vector2(x2, y2), birdSpeed));
		
		while (!isHit) {
			//yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
			
			x1 = Random.Range(5.3f, 9.3f);

			var diff = transform.position.x - x1;
			if(diff < 0.8)
			{
				x1 += 0.8f;
			}

			y1 = Random.Range(1.2f, 3f);
			
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, y1), birdSpeed)); //3.692791f
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator MoveObject (Transform thisTransform, Vector2 startPos, Vector2 endPos, float time) {
		float i=0.0f;
		float rate = 1.0f / time;
		if((startPos.x<endPos.x)&&(faceleft==true))
		{
			//Debug.Log ("moving right");
			Flip();
			faceleft=false;
		}
		else if((startPos.x>endPos.x)&&(faceleft==false))
		{
			Flip();
			faceleft=true;
			//Debug.Log ("moving left");
		}
		while (i < 1.0f) {
						i += Time.deltaTime * rate;
						if (isHit) {
								break;
						}
						thisTransform.position = Vector2.Lerp (startPos, endPos, i);
						yield return null;
				}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log (col.gameObject.name);

		if(col.gameObject.name == "Bird2D(Clone)") {
			return;
		}

		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}

		if(col.gameObject.name == "StartButton") {
			return;
		}
		
		if (col.gameObject.name == "Bullets(Clone)") {
			Destroy(col.gameObject);
			Destroy (gameObject);
			Application.LoadLevel ("SecondLevel");
		} 
		//else {
			//Time.timeScale = 0;

		//}
	}

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
		//charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
		isLeft = !isLeft;
	}

}
