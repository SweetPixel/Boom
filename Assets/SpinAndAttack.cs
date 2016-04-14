using UnityEngine;
using System.Collections;

public class SpinAndAttack : MonoBehaviour {

	public float speed = 2f;
	public float movementSpeed = 1f;
	private bool isRight = true;


	// Use this for initialization
	void Start () {
		if(transform.position.x == 7f)
		{
			StartCoroutine(MoveObject(transform, new Vector3(7f, transform.position.y, 0f), new Vector3(5.5f, transform.position.y, 0f), 1.5f));
			StartCoroutine(speedup());
			Destroy(gameObject, 5f);
			isRight = true;
		}
		else{
			//this.transform.Rotate (0,180,0);
			//StartCoroutine(MoveObject(transform, transform.position, new Vector3(7f, transform.position.y, 0f), speed));
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(-5.5f, transform.position.y, 0f), 1.5f));
			StartCoroutine(speedup());
			Destroy(gameObject, 5f);
			isRight = false;
		}


	}
	
	// Update is called once per frame
	void Update () {
	
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
		if(isRight)
		StartCoroutine(MoveObject(transform, transform.position, new Vector3(-7f, transform.position.y, 0f), movementSpeed));
		else
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(7f, transform.position.y, 0f), movementSpeed));
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
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.GameOver();
			Destroy(col.gameObject);
		}
		
	}
}
