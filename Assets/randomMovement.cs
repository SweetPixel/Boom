using UnityEngine;
using System.Collections;

public class randomMovement : MonoBehaviour {

	public float speed;
	public GameObject cube;
	Vector3 newpos;
	Animator anime;

	public GameObject coin;
	float birdLife = 0;
	private bool isLive = false;

	private GameObject hunter;
	private HunterMovement hm;
	Animator anim;
	bool isLeft = false;
	public bool isHit = false;

	void Start () {

		hunter = GameObject.Find ("Object");
		if (hunter == null) {
			hunter = GameObject.Find ("Object(Clone)");
		}
		hm = hunter.GetComponent<HunterMovement> ();
		
		anim = GetComponent<Animator> ();
		anim.SetBool ("isHit", false);

		anime = gameObject.GetComponent<Animator> ();
		anime.SetInteger ("movementValue", 0);
		newpos.x += 5f;
		newpos.y = cube.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		newpos.z = 0f;
		if (cube.transform.position.x == newpos.x && cube.transform.position.y == newpos.y) {
			move();
				}
		float step = speed * Time.deltaTime;

		Vector3 diff = newpos - transform.position;

		cube.transform.position = Vector3.MoveTowards(cube.transform.position, newpos, step);

		birdLife += Time.deltaTime;
		if (birdLife > 5f) {
			isLive = true;
			birdLife = 0;
		}
		
		if (transform.position.y < -3.176471f) {
			//Application.LoadLevel ("SecondLevelInfinite");
			//StartGame script = new StartGame();
			//script.enableObject();
			Destroy(gameObject);
		}

	}
	
	void move(){
		newpos =  this.gameObject.transform.position;
		int rand = Random.Range (0, 6);
		if (rand == 0) {
			anime.SetInteger ("movementValue", 0);
			float diff = 10.0f - transform.position.x;
			float randX = Random.Range (1f, diff);

			newpos.x += randX; //2f;
		} else if (rand == 1) {
			anime.SetInteger ("movementValue", 1);
			float diff = 10.0f - transform.position.x;
			float randX = Random.Range (1f, diff);

			float diffy = 4.0f - transform.position.y;
			float randY = Random.Range (1f, diffy);

			if(randX < randY)
			{
				newpos.x += randX; //2f;
				newpos.y += randX;
			}
			else{
				newpos.x += randY; //2f;
				newpos.y += randY;
			}

			//newpos.x += randX; //2f;
			//newpos.y += randY; //2f;
			
		} //else if (rand == 2) {
		//	anime.SetInteger ("movementValue", 2);
		//	float diffy = 4.0f - transform.position.y;
		//	float randY = Random.Range (1f, diffy);

		//	newpos.y += randY; //2f;
			
		//} 
		else if (rand == 2) {
			anime.SetInteger ("movementValue", 2);
			float diff = transform.position.x - 5.8f;
			float randX = Random.Range (1f, diff);

			float diffy = 4.0f - transform.position.y;
			float randY = Random.Range (1f, diffy);

			if(randX < randY)
			{
				newpos.x -= randX; //2f;
				newpos.y += randX;
			}
			else{
				newpos.x -= randY; //2f;
				newpos.y += randY;
			}

			//newpos.x -= randX; //2f;
			//newpos.y += randY; //2f;
			
		} else if (rand == 3) {
			anime.SetInteger ("movementValue", 3);
			float diff = transform.position.x - 5.8f;
			float randX = Random.Range (1f, diff);

			newpos.x -= randX; //2f;
			
		} else if (rand == 4) {
			anime.SetInteger ("movementValue", 4);
			float diff = transform.position.x - 5.8f;
			float randX = Random.Range (1f, diff);

			float diffy = transform.position.y - 0.2f;
			float randY = Random.Range (1f, diffy);

			if(randX < randY)
			{
				newpos.x -= randX; //2f;
				newpos.y -= randX; //2f;
			}
			else{
				newpos.x -= randY; //2f;
				newpos.y -= randY; //2f;
			}


			
		//} else if (rand == 5) {
		//	anime.SetInteger ("movementValue", 5);
		//	float diffy = transform.position.y - 0.2f;
		//	float randY = Random.Range (1f, diffy);

		//	newpos.y -= randY; //2f;
			
		} else if (rand == 5) {
			anime.SetInteger ("movementValue", 5);
			float diff = 10.0f - transform.position.x;
			float randX = Random.Range (1f, diff);

			float diffy = transform.position.y - 0.2f;
			float randY = Random.Range (1f, diffy);

			if(randX < randY)
			{
				newpos.x += randX; //2f;
				newpos.y -= randX;
			}
			else{
				newpos.x += randY; //2f;
				newpos.y -= randY;
			}

			//newpos.x += randX; //2f;
			//newpos.y -= randY; //2f;	
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
		
		/*if (col.gameObject.name == "Bullets(Clone)") {
			gameObject.collider2D.enabled = false;
			GameObject co = (GameObject)Instantiate(coin, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			co.rigidbody2D.velocity = Vector2.up * 2;
			isLive = false;
			birdLife = 0;
			hm.initiateBird();
			BirdHit ();
			Destroy (col.gameObject);
		} */
	}

	private void BirdHit()
	{
		isHit = true;
		anim.SetBool ("isHit", true);
		anim.SetBool("isLeft", isLeft);
		//rigidbody.velocity = Vector2.up * -2;
		GetComponent<Rigidbody2D>().velocity = Vector2.up * -8;
	}

}
