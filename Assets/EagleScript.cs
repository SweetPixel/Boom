using UnityEngine;
using System.Collections;

public class EagleScript : MonoBehaviour {

	private GameObject hunter;
	private HunterMovement hm;
	Animator anim;
	public GameObject coin;
	public float birdSpeed = 1.5f;
	public GameObject flock;
	private bool isFlip = false;
	private bool isHit = false;
	GameObject gcc;
	GameController gc;


	// Use this for initialization
	IEnumerator Start () {

		yield return StartCoroutine(MoveObject(transform, new Vector2(3f,3f), new Vector2(13f, 3f), birdSpeed));
		Flip ();
		yield return StartCoroutine(MoveObject(transform, new Vector2(13f,3f), new Vector2(1f, 3f), birdSpeed));
		
		hunter = GameObject.FindGameObjectWithTag ("Player");
		hm = hunter.GetComponent<HunterMovement> ();


		//anim = GetComponent<Animator> ();
		//anim.SetBool ("isHit", false);
	}

	IEnumerator MoveObject (Transform thisTransform, Vector2 startPos, Vector2 endPos, float time) {
		float i=0.0f;
		float rate = 1.0f / time;
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
		if (transform.position.x == 1f) {
			Destroy(gameObject);
		}
	}

	void Flip()
	{
		gameObject.transform.Rotate (0,180,0);
		isFlip = !isFlip;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}

		if(col.gameObject.name == "Bird2D(Clone)") {
			return;
		}

		if(col.gameObject.name == "StartButton") {
			return;
		}
		
		if (col.gameObject.tag == "Bullet") {
			isHit = true;
			gameObject.GetComponent<Collider2D>().enabled = false;
			StartCoroutine(destroy(col.gameObject));
		}

	}

	IEnumerator destroy(GameObject col)
	{
		Destroy (col.gameObject);
		GameObject co = (GameObject)Instantiate(coin, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
		anim = GetComponent<Animator> ();
		anim.SetBool("isHit",true);
		if (isFlip) {
			gameObject.transform.Rotate (0,0,0);
				}
		Time.timeScale = 0.4f;
		yield return new WaitForSeconds (1f);
		Time.timeScale = 1f;
		GameObject fl = (GameObject)Instantiate(flock, new Vector3(3f,0f), Quaternion.identity);
		Destroy(gameObject);
	}

}
