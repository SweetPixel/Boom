using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Sprite tap;
	public Sprite start;
	public GameObject levelLabel;
	public Sprite levelOne;
	public Sprite levelTwo;
	public GameObject hunterPrefab;
	//SpriteRenderer Levelrender;

	SpriteRenderer render;
	public int counter = 0;

	public GameObject hunter;
	HunterMovement hunterMovement;

	public GameObject bird;
	BirdMovement birdMovement;
	public GameObject birdEnemy;

	bool firstWave = true;

	BoxCollider2D collider;
	private bool secondTouch = false;
	private bool restart = false;

	public GameObject gameOver;
	public float birdSpawnWait = 3f;

	float[] Yaxis = { 2.3f , 1.7f, 1.15f, 0.75f};
	float[] Xaxis = { 5.1f , 11.3f };

	// Use this for initialization
	void Start () {

		//SpriteRenderer goRender = gameOver.GetComponent<SpriteRenderer> ();
		//gameOver = GameObject.Find ("GameOver");
		//gameOver.transform.position = new Vector2 (14f, 0.3494778f);

		render = this.gameObject.GetComponent<SpriteRenderer> ();
		//Levelrender = levelLabel.GetComponent<SpriteRenderer> ();
		//Time.timeScale = 0;
		counter = 0;
		//Time.timeScale = 0;


		hunterMovement = hunter.GetComponent<HunterMovement> ();
		collider = gameObject.GetComponent<BoxCollider2D> ();

		GameObject go = GameObject.Find ("GameOver(Clone)");
		if (go == null) {
			Destroy(go);
				}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) && secondTouch) {
						hunterMovement.letStart ();
						//Destroy(gameObject);
						gameObject.transform.position = new Vector2 (11f, 11f);
						render.sprite = start;
			StartCoroutine(waitTime(gameObject));	
				}



	}

	IEnumerator waitTime(GameObject gobject)
	{
		yield return new WaitForSeconds(1f);
		gobject.collider2D.name = "RestartButton";
	}

	void OnMouseDown()
	{
		//gameObject.transform.localScale = new Vector2 (0.65f, 0.65f);
		//Time.timeScale = 1;
		//gameObject.collider2D.enabled = false;
	}

	void OnMouseUp()
	{

		if (gameObject.collider2D.name == "StartButton") {
						startLevel ();
			gameObject.collider2D.name = "Taptostart";

				}
		else if (gameObject.collider2D.name == "RestartButton") {
			//startLevel ();
			gameObject.transform.position = new Vector2 (11f, 11f);
			GameObject hunt = GameObject.Find("Object");
			if(hunt == null)
			{
				hunt = GameObject.Find ("Object(Clone)");
			}
			Destroy(hunt);
			Destroy(GameObject.Find ("GameOver(Clone)"));
			GameObject h = (GameObject)Instantiate(hunterPrefab, new Vector3(8.15f, -1.99f, 0.02769041f), Quaternion.identity);
			gameObject.collider2D.name = "StartButton";

			HunterMovement hRestart = h.GetComponent<HunterMovement> ();
			hRestart.letStart();

			GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird2D");
			if(birds.Length == 2)
			{
				StartCoroutine(InitiateBird (1));
			}
			else if(birds.Length == 1){
				StartCoroutine(InitiateBird (2));
			}

		}
	}

	public void startLevel()
	{
		if (counter == 0) {
			gameObject.transform.localScale = new Vector2 (0.7f, 0.7f);
			
			//GameObject clone =(GameObject) Instantiate (levelLabel, levelLabel.transform.position, Quaternion.identity);
			//clone.transform.position= new Vector2(10f,10f);
			//clone.renderer.enabled=false;
			//sclone.renderer.enabled=true;
			//StartCoroutine(wait());

			render.sprite = tap;
			render.enabled = false;
			enableObject();
			counter++;
		}
	}

	public void enableObject()
	{
		render.enabled = true;
		StartCoroutine(InitiateBird (3));
		//Vector2 size = new Vector2(6.0f, 6.0f);
		//this.collider.size = size;
		secondTouch = true;
	}

	IEnumerator InitiateBird(int length)
	{
		//yield return new WaitForSeconds(1.5f);
		int prevY = 0;

		while(firstWave)
		{
			for (int i=0;i<length;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);

				int index = Random.Range(0,4);
				if(index == prevY)
				{
					index = Random.Range(0,4);
				}
				float y = Yaxis[index];
				float x = 5.1f;
				if(index == 0 || index == 2)
				{
					x = Xaxis[0];
				}
				else if(index == 1 || index == 3)
				{
					x = Xaxis[1];
				}

				Quaternion spawnRotation = Quaternion.identity;
				//Instantiate (bird, new Vector2 (5.1f, 2.958249f), Quaternion.identity);
				Instantiate (bird, new Vector2 (x, y), Quaternion.identity);
				yield return new WaitForSeconds(birdSpawnWait);
				prevY = index;
			}
			firstWave = false;
		}
	}

	//public void initiateBird()
	//{
	//	Instantiate (bird, new Vector2 (5.1f, 2.958249f), Quaternion.identity);
	//}

	IEnumerator InitiateEnemy()
	{
		//yield return new WaitForSeconds(1.5f);
		while(firstWave)
		{
			for (int i=0;i<1;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (birdEnemy, new Vector2 (4.1f, Random.Range(1.2f, 3f)), spawnRotation);
				yield return new WaitForSeconds(3f);
			}
			firstWave = false;
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (10);
	}

}
