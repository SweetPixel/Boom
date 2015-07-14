using UnityEngine;
using System.Collections;

public class SpecialBirdCoinMovement : MonoBehaviour {
	private GameObject hunter;
	private HunterMovement hm;
	public GameObject coin;
	public GameObject coinCollector;
	float radius = 5f;

	// Use this for initialization
	void Start () {
		hunter = GameObject.Find ("Object");
		if (hunter == null) {
			hunter = GameObject.Find ("Object(Clone)");
		}
		hm = hunter.GetComponent<HunterMovement> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * 0.5f * Time.deltaTime);

		if (transform.position.x == 10.5f) {
			Destroy(gameObject);
				}

	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}
		
		if(col.gameObject.name == "StartButton") {
			return;
		}
		
		if (col.gameObject.tag == "Bullet") {
			gameObject.GetComponent<Collider2D>().enabled = false;
			GameObject co = (GameObject)Instantiate(coin, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			//co.GetComponent<Rigidbody2D>().velocity = Vector2.up * 2;

			//co.transform.position = Vector2.MoveTowards(co.transform.position, coinCollector.transform.position, 50f * Time.deltaTime);

			Destroy(col.gameObject);
			hm.addCoin();
			Destroy(gameObject);
		}
	}
}
