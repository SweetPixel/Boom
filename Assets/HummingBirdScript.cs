using UnityEngine;
using System.Collections;

public class HummingBirdScript : MonoBehaviour {

	public float x1 = 6.35f;
	public float x2 = 6.73f;
	public float y1 = 3.692791f;
	public float y2 = 3.0f;
	
	bool isLeft = false;
	public bool isHit = false;

	public float birdSpeed = 1.5f;
	
	private float prevX1;
	private float prevX2;
	private bool faceleft=false;
	
	bool Samedirection = false;
	
	private GameObject hunter;
	private HunterMovement hm;

	private GameObject gameController;
	private GameController gc;

	private GameObject treeLeft;
	
	float birdLife = 0;
	private bool isLive = false;
	
	//public GameObject coinObject;
	public GameObject coin;
	private bool hunterIdle = false;
	private float[] pos = { 10.6f , 5.3f };
	
	IEnumerator Start () {
		//Flip ();

		hunter = GameObject.FindGameObjectWithTag ("Player");
		hm = hunter.GetComponent<HunterMovement> ();

		birdLife = 0;

		x1 = Random.Range(7.5f, 9.85f);
		y1 = Random.Range(1.5f, 2.3f);
		
		y2 = Random.Range(1.5f, 2.3f);
		
		if (gameObject.transform.position.x == 5.1f) {
			yield return StartCoroutine(MoveObject(transform, new Vector2(5.1f, 2.3f), new Vector2(x1, 2.3f), birdSpeed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, 2.3f), new Vector2(x2, y2), birdSpeed));
		} else {
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, transform.position.y), birdSpeed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, transform.position.y), new Vector2(x2, y2), birdSpeed));
		}
		
		while (!isHit) {
			x1 = Random.Range(6.4f, 9.8f);
			y1 = Random.Range(0.8f, 2.6f);
			if(hunterIdle)
			{
				int index = Random.Range(0,2);
				x1 = pos[index];
				birdSpeed = 0.75f;
			}
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

		if (transform.position.x == 10.6f || transform.position.x == 5.3f) {
			Destroy(gameObject);
		}

	}

	public void setHunterIdle()
	{
		hunterIdle = true;
	}

	void Flip()
	{
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
		
		if (col.gameObject.tag == "Bullet") {
			Destroy (col.gameObject);
			gameObject.GetComponent<Collider2D>().enabled = false;
			GameObject co = (GameObject)Instantiate(coin, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			//co.GetComponent<Rigidbody2D>().velocity = Vector2.up * -2;
			isLive = false;
			birdLife = 0;
			gameController = GameObject.FindGameObjectWithTag ("GameController");
			gc = gameController.GetComponent<GameController> ();

			gc.increaseBirdKiled();
			gc.setScore (3);
			gc.incrementBirdCount();
			Destroy(gameObject);
		} 
		
		
	}
	
	private void BirdHit()
	{
		isHit = true;
		GetComponent<Rigidbody2D>().velocity = Vector2.up * -5;
	}

}
