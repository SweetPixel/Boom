using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	public Vector3 pointB;
	public float x1 = 6.35f;
	public float x2 = 6.73f;
	public float y1 = 3.692791f;
	public float y2 = 3.0f;

	bool isLeft = false;
	public bool isHit = false;

	Animator anim;

	public float birdSpeed = 1.5f;

	private float prevX1;
	private float prevX2;
	private bool faceleft=false;

	bool Samedirection = false;

	private GameObject hunter;
	private HunterMovement hm;

	private GameObject treeLeft;

	float birdLife = 0;
	private bool isLive = false;

	//public GameObject coinObject;
	public GameObject coin;

	IEnumerator Start () {
		//Flip ();
		birdLife = 0;

		treeLeft = GameObject.Find ("ObstacleTreeLeft");

		hunter = GameObject.Find ("Object");
		if (hunter == null) {
			hunter = GameObject.Find ("Object(Clone)");
				}
		hm = hunter.GetComponent<HunterMovement> ();

		anim = GetComponent<Animator> ();
		anim.SetBool ("isHit", false);

		Vector3 pointA = transform.position;

		x1 = Random.Range(7.5f, 9.85f);
		y1 = Random.Range(1.5f, 2.3f);

		y2 = Random.Range(1.5f, 2.3f);

		if (gameObject.transform.position.x == 5.1f) {
			yield return StartCoroutine(MoveObject(transform, new Vector2(5.1f, 2.3f), new Vector2(x1, 2.3f), birdSpeed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, 2.3f), new Vector2(x2, y2), birdSpeed));
				} else {
			//Flip();
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, transform.position.y), birdSpeed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, transform.position.y), new Vector2(x2, y2), birdSpeed));
				}

		while (!isHit) {
			//yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));

			x1 = Random.Range(6.4f, 9.8f);
			y1 = Random.Range(0.8f, 2.6f);

			/* if(isLive && (faceleft==true))
			{
				yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(9.4f, -2.18f), birdSpeed)); //3.692791f
			}
			else if(isLive && (faceleft==false))
			{

				yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(6.4f, -2.6f), birdSpeed)); //3.692791f
			} */

			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, y1), birdSpeed)); //3.692791f

		}
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
			if(isHit)
			{
				break;
			}
		thisTransform.position = Vector2.Lerp(startPos, endPos, i);
		yield return null;
		}

	}
	
	// Update is called once per frame
	void Update () {

		birdLife += Time.deltaTime;
		if (birdLife > 5f) {
			isLive = true;
			birdLife = 0;
				}

		if (transform.position.y < -3.176471f) {
			Destroy(gameObject);
				}
	}

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
		//charScale.x *= -1;
		//transform.localScale = charScale;
		gameObject.transform.Rotate (0,180,0);
		isLeft = !isLeft;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}

		if(col.gameObject.name == "StartButton") {
			return;
		}

		if (col.gameObject.name == "Bullets(Clone)") {
			gameObject.GetComponent<Collider2D>().enabled = false;
			GameObject co = (GameObject)Instantiate(coin, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			co.GetComponent<Rigidbody2D>().velocity = Vector2.up * 2;
			isLive = false;
			birdLife = 0;
			hm.initiateCoin();
			hm.incrementBirdCount();
			//BirdHit ();
			Destroy(gameObject);
			Destroy (col.gameObject);
				} 


	}

	private void BirdHit()
	{
		isHit = true;
		anim.SetBool ("isHit", true);
		anim.SetBool("isLeft", isLeft);
		//rigidbody.velocity = Vector2.up * -2;
		GetComponent<Rigidbody2D>().velocity = Vector2.up * -5;
	}


	public bool getIsHit()
	{
		return isHit;
	}

}
