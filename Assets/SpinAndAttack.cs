using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpinAndAttack : MonoBehaviour {

	public float speed = 2f;
	public float movementSpeed = 1f;
	private bool isRight = true;
	float leftBorder;
	float rightBorder;

	// Use this for initialization
	void Start () {

		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		if(transform.position.x <= 0f)
		{
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(leftBorder, transform.position.y, 0f), speed));
			StartCoroutine(speedup());
			Destroy(gameObject, 5f);
			isRight = true;
		}
		else{
			//this.transform.Rotate (0,180,0);
			//StartCoroutine(MoveObject(transform, transform.position, new Vector3(7f, transform.position.y, 0f), speed));
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(rightBorder, transform.position.y, 0f), speed));
			StartCoroutine(speedup());
			Destroy(gameObject, 5f);
			isRight = false;
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

	IEnumerator speedup()
	{
		yield return new WaitForSeconds(2f);
		//transform.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed, ForceMode2D.Force);
		if(isRight) // if right then set the value to 7f - previous value was -7f
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(rightBorder+2f, transform.position.y, 0f), movementSpeed));
		else
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(leftBorder-2f, transform.position.y, 0f), movementSpeed));
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Bullet") {
			return;
		}
		
		if (col.gameObject.tag == "Platform") {
			return;
		}
		
		if (col.gameObject.tag == "Player") {
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
