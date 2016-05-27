using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GunShipMovement : MonoBehaviour {

	public float speed = 2f;
	private float leftBorder;
	private float rightBorder;
	private float x1;
	private float y1 = 3.0f;

	// Use this for initialization
	IEnumerator Start () {

		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		StartCoroutine(MoveObject(transform, transform.position, new Vector2(transform.position.y, y1), speed));

		while (true) {
			x1 = Random.Range(leftBorder, rightBorder);
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, transform.position.y), speed)); //3.692791f
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

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Bullet") {
			gameObject.GetComponentInChildren<Image> ().fillAmount -=  0.05f * col.gameObject.GetComponent<DamageScript> ().Damage;
			col.gameObject.SetActive(false);
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

	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponentInChildren<Image> ().fillAmount <= 0.2f) {
			Destroy (gameObject);
		}
	}
}
