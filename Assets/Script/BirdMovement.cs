using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour {

	public Vector3 pointB;
	public float x1 = -4f;
	public float x2 = 3.0f;
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
	private GameObject gameController;
	private GameController gc;

	private GameObject treeLeft;

	float birdLife = 0;
	private bool isLive = false;

	//public GameObject coinObject;
	public GameObject coin;
	public GameObject particleSystem;

	public Sprite prevSprite;
	private bool hunterIdle = false;
	private float[] pos = { 10.6f , 5.3f };

	public GameObject Helicopter;
	public GameObject balloon;
	public GameObject miniBoss;
	IEnumerator Start () {
		Flip ();
		birdLife = 0;

		treeLeft = GameObject.Find ("ObstacleTreeLeft");
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();

		hunter = GameObject.Find ("Object");
		if (hunter == null) {
			hunter = GameObject.Find ("Object(Clone)");
				}
		//hm = hunter.GetComponent<HunterMovement> ();

		anim = GetComponent<Animator> ();
		anim.SetBool ("isHit", false);

		Vector3 pointA = transform.position;

		x1 = Random.Range(-3f, 3f);
		//y1 = Random.Range(4f, 6f);

		//y2 = Random.Range(4f, 6f);

		if (gameObject.transform.position.x == -4.0f) {
			yield return StartCoroutine(MoveObject(transform, new Vector2(-4.0f, y1), new Vector2(x1, y1), birdSpeed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, y1), new Vector2(x2, y2), birdSpeed));
				} else {
			//Flip();

			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, transform.position.y), birdSpeed));
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, transform.position.y), new Vector2(x2, y2), birdSpeed));
				}

		while (!isHit) {
			x1 = Random.Range(-3f, 3f);
			//y1 = Random.Range(4f, 6f);
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

		/*if (prevSprite != GetComponent<SpriteRenderer> ().sprite) {
						Destroy (GetComponent<PolygonCollider2D> ());
						gameObject.AddComponent<PolygonCollider2D> ();
			prevSprite = GetComponent<SpriteRenderer> ().sprite;
				}*/

		birdLife += Time.deltaTime;
		if (birdLife > 5f) {
			isLive = true;
			birdLife = 0;
				}

		if (transform.position.y < -3.176471f) {
			Destroy(gameObject);
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
		//Vector2 charScale = transform.localScale;
		//charScale.x *= -1;
		//transform.localScale = charScale;
		gameObject.transform.Rotate (0,180,0);
		isLeft = !isLeft;
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		//Debug.Log (col.gameObject.name);
		if(col.gameObject.name == "Balloon") {
			return;
		}

		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}

		if(col.gameObject.name == "StartButton") {
			return;
		}

		if (col.gameObject.tag == "Bullet") {
			//particleSystem
			Instantiate(particleSystem, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			gameObject.GetComponent<Collider2D>().enabled = false;
			GameObject co = (GameObject)Instantiate(coin, new Vector3(gameObject.transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			//co.GetComponent<Rigidbody2D>().velocity = Vector2.up * -2;

			if(GameObject.Find("Foreground").GetComponent<Image>().fillAmount < 1)
			{
				GameObject.Find("Foreground").GetComponent<Image>().fillAmount += 0.05f;
				//gc.increaseBirdKiled();
				//Debug.Log(System.Math.Round(GameObject.Find("Foreground").GetComponent<Image>().fillAmount,2));
				if(System.Math.Round(GameObject.Find("Foreground").GetComponent<Image>().fillAmount,2)%0.25f == 0 && GameObject.Find("Foreground").GetComponent<Image>().fillAmount != 1)
				{
					Instantiate(miniBoss, new Vector3(-2.5f, balloon.transform.position.y, balloon.transform.position.z), Quaternion.identity);
				}
				/*else if((System.Math.Round(GameObject.Find("Foreground").GetComponent<Image>().fillAmount,2)+0.1)%0.25f == 0 && GameObject.Find("Foreground").GetComponent<Image>().fillAmount != 1)
				{
					Instantiate(balloon, new Vector3(-3.2f, balloon.transform.position.y, balloon.transform.position.z), Quaternion.identity);
				}*/
				else if(GameObject.Find("Foreground").GetComponent<Image>().fillAmount == 1)
				{
					Instantiate(Helicopter, new Vector3(-6f, Helicopter.transform.position.y, Helicopter.transform.position.z), Quaternion.identity);
				}
			}
			//isLive = false;
			//birdLife = 0;
			//gc.setScore(1);
			//gc.incrementBirdCount();
			//GameObject.FindGameObjectWithTag("PlayHand").GetComponent<StartGame>().initBirdOutside(1);
			//BirdHit ();
			GameObject.Find("AirEnemyGenerator").GetComponent<AirEnemyGeneratorScript>().InitEnemy();
			Destroy(gameObject);
			Destroy(col.gameObject);
			/*GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
			foreach(GameObject b in bullets)
			{
				Destroy (b);
			}*/
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
