using UnityEngine;
using System.Collections;

public class MiniBossMovement : MonoBehaviour {

	public float speed = 0.02f;
	public float x1 = -4f;
	public float x2 = 4f;
	public float y1 = 3.692791f;
	public float y2 = 3.0f;
	public int threshold = 10;
	private int count = 0;

	// Use this for initialization
	IEnumerator Start () {
		x1 = Random.Range(-3f, 3f);
		y1 = Random.Range(4f, 6f);
		
		y2 = Random.Range(4f, 6f);
		
		if (gameObject.transform.position.x == -4.0f) {
			yield return StartCoroutine(MoveObject(transform, new Vector2(-4.0f, y1), new Vector2(x1, y1), speed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, y1), new Vector2(x2, y2), speed));
		} else {
			//Flip();
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, transform.position.y), speed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, transform.position.y), new Vector2(x2, y2), speed));
		}
		
		while (true) {
			x1 = Random.Range(-3f, 3f);
			y1 = Random.Range(4f, 6f);
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, y1), speed)); //3.692791f
		}

	}

	IEnumerator MoveObject (Transform thisTransform, Vector2 startPos, Vector2 endPos, float time) {
		float i=0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector2.Lerp(startPos, endPos, i);
			yield return null;
		}
		
	}

	// Update is called once per frame
	void Update () {
		if(count == threshold)
		{
			Destroy(gameObject);
		}

	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log (col.gameObject.name);
		if(col.gameObject.tag == "Bird2D") {
			return;
		}
		
		
		if (col.gameObject.tag == "Bullet") {
			count++;
			Destroy(col.gameObject);
		}
	}

}
