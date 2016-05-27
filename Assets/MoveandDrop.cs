using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveandDrop : MonoBehaviour {

	public float speed = 0.02f;
	public float x1 = -4f;
	public float x2 = 4f;
	public float y1 = 3.692791f;
	public float y2 = 3.0f;
	public int threshold = 3;
	private int count = 0;

	public GameObject trackerRocket;
	public Transform spawnPosition;
	public float fireDelay = 1f;

	private float leftBorder;
	private float rightBorder;

	public float increaseRate = 0f;

	public GameObject[] enemies;

	// Use this for initialization
	IEnumerator Start () {
		StartCoroutine(Fire());

		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;

		x1 = Random.Range(leftBorder, rightBorder);
		y1 = Random.Range(4f, 6f);

		y2 = Random.Range(4f, 6f);

		if (gameObject.transform.position.x == -4.0f) {
			yield return StartCoroutine(MoveObject(transform, new Vector2(-4.0f, transform.position.y), new Vector2(x1, transform.position.y), speed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, transform.position.y), new Vector2(x2,transform.position.y), speed));
		} else {
			//Flip();
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, transform.position.y), speed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, transform.position.y), new Vector2(x2, transform.position.y), speed));
		}

		while (true) {
			x1 = Random.Range(leftBorder, rightBorder);
			y1 = Random.Range(4f, 6f);
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

	IEnumerator Fire()
	{
		while(true)
		{
			Instantiate(trackerRocket, spawnPosition.position, Quaternion.identity);
			yield return new WaitForSeconds(fireDelay);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log (col.gameObject.name);
		if(col.gameObject.tag == "Bird2D") {
			return;
		}


		if (col.gameObject.tag == "Bullet") {
			gameObject.GetComponentInChildren<Image> ().fillAmount -=  0.1f * col.gameObject.GetComponent<DamageScript> ().Damage;
			col.gameObject.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponentInChildren<Image> ().fillAmount <= 0.2f) {
			GameObject.Find ("Foreground").GetComponent<Image> ().fillAmount += increaseRate;
			GameObject[] miniboss = GameObject.FindGameObjectsWithTag ("MiniBoss");
			if (miniboss.Length == 0) {
				GameObject enemy = (GameObject)Instantiate (enemies [0], new Vector2(8f, enemies [0].transform.position.y), Quaternion.identity);
			} else {
				GameObject enemy = (GameObject)Instantiate (enemies [1], new Vector2(8f, enemies [1].transform.position.y), Quaternion.identity);
			}
			Destroy (gameObject);
		}

	}

}
