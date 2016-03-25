using UnityEngine;
using System.Collections;

public class SpinAndAttack : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {
		StartCoroutine(MoveObject(transform, new Vector3(7f, transform.position.y, 0f), new Vector3(5.5f, transform.position.y, 0f), 1.5f));
		StartCoroutine(speedup());
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
		transform.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed);
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
