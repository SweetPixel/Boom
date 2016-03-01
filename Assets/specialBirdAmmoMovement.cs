using UnityEngine;
using System.Collections;

public class specialBirdAmmoMovement : MonoBehaviour {

	private GameObject hunter;
	private HunterMovement hm;
	public GameObject bullet;
	public Sprite rifleB;
	public Sprite smgB;
	public Sprite shotgunB;
	public Sprite sniperB;
	private GameObject gameController;
	private GameController gc;

	// Use this for initialization
	void Start () {
		hunter = GameObject.Find ("Object");
		if (hunter == null) {
			hunter = GameObject.Find ("Object(Clone)");
		}
		hm = hunter.GetComponent<HunterMovement> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();
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

			int gunIndex = gc.getGunIndex();
			//int gunIndex = PlayerPrefs.GetInt ("gunIndex");
			if (gunIndex == 0 || gunIndex == 1) {
				bullet.GetComponent<SpriteRenderer>().sprite = rifleB;
			}
			else if (gunIndex == 2) {
				bullet.GetComponent<SpriteRenderer>().sprite = smgB;
			}
			else if (gunIndex == 3) {
				bullet.GetComponent<SpriteRenderer>().sprite = shotgunB;
			}
			else if (gunIndex == 4) {
				bullet.GetComponent<SpriteRenderer>().sprite = sniperB;
			}

			gameObject.GetComponent<Collider2D>().enabled = false;
			GameObject co = (GameObject)Instantiate(bullet, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			co.GetComponent<Rigidbody2D>().velocity = Vector2.up * 2;
			Destroy(col.gameObject);
			//gc.addAmmo();
			gc.incrementBirdCount();
			gc.increaseBirdKiled();
			Destroy(gameObject);
		} 
		
		
	}

}
