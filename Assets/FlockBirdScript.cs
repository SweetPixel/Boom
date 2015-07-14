using UnityEngine;
using System.Collections;

public class FlockBirdScript : MonoBehaviour {

	private GameObject hunter;
	private HunterMovement hm;
	Animator anim;
	bool isLeft = false;
	private bool isLive = false;
	public GameObject coin;

	// Use this for initialization
	void Start () {


		hunter = GameObject.Find ("Object");
		if (hunter == null) {
			hunter = GameObject.Find ("Object(Clone)");
		}
		hm = hunter.GetComponent<HunterMovement> ();
		
		anim = GetComponent<Animator> ();
		anim.SetBool ("isHit", false);
	}
	
	// Update is called once per frame
	void Update () {
	
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
			//co.GetComponent<Rigidbody2D>().velocity = Vector2.up * -2;
			isLive = false;
			hm.setScore();
			//hm.incrementBirdCount();
			//BirdHit ();
			Destroy(gameObject);
			Destroy (col.gameObject);
		}
	}

}
