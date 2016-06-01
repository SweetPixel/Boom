using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StandAndFire : MonoBehaviour {

	public float speed = 2f;
	public float movementSpeed = 1f;
	private bool isRight = true;
	float leftBorder;
	float rightBorder;
	public float delay = 2f;
	public float fireSpeed = 350f;
	public GameObject bullet;
	public GameObject spawn;

	// Use this for initialization
	void Start () {

		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		if(transform.position.x <= 0f)
		{
			this.transform.Rotate (0,180,0);
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(leftBorder+1f, transform.position.y, 0f), speed));
			StartCoroutine(Fire());

			//Destroy(gameObject, 5f);
			isRight = true;
		}
		else{
			//this.transform.Rotate (0,180,0);
			//StartCoroutine(MoveObject(transform, transform.position, new Vector3(7f, transform.position.y, 0f), speed));
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(rightBorder-1f, transform.position.y, 0f), speed));
			StartCoroutine(Fire());
			//Destroy(gameObject, 5f);
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

	IEnumerator Fire()
	{
		yield return new WaitForSeconds(delay);
		while (true) {
			GameObject fire = (GameObject)Instantiate (bullet, spawn.transform.position, Quaternion.identity);
			if(isRight)
			{
				fire.transform.Rotate (0,180,0);
				fire.GetComponent<Rigidbody2D>().AddForce(Vector2.right * fireSpeed);
			}else{
				fire.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * fireSpeed);
			}
			yield return new WaitForSeconds(delay);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Bullet") {
			gameObject.GetComponentInChildren<Image> ().fillAmount -=  0.2f * col.gameObject.GetComponent<DamageScript> ().Damage;
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

	void Update()
	{
		if (gameObject.GetComponentInChildren<Image> ().fillAmount <= 0.2f) {
			Destroy (gameObject);
		}
	}

}
