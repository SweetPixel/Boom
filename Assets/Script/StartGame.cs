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

	//Start variable.
	public GameObject startCanvas;
	private bool canvasIsActive = false;

	public GameObject GameComponent;

	//PlayHand variable;
	private bool isPlayHand = false;

	// Use this for initialization
	void Start () {

		render = this.gameObject.GetComponent<SpriteRenderer> ();
		counter = 0;
		//Time.timeScale = 0;

		startLevel ();

		//GameComponent.transform.position = new Vector2 (6.24f, GameComponent.transform.position.y);

		hunter = GameObject.FindGameObjectWithTag ("Player");
		hunterMovement = hunter.GetComponent<HunterMovement> ();
		collider = gameObject.GetComponent<BoxCollider2D> ();

		startCanvas = GameObject.Find ("StartCanvas");
		startCanvas.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetMouseButton (0) && secondTouch) {
			hunterMovement.letStart ();
			startLevel();
						gameObject.transform.position = new Vector2 (11f, 11f);
						render.sprite = start;
			StartCoroutine(waitTime(gameObject));	
				} */



	}

	IEnumerator waitTime(GameObject gobject)
	{
		//startCanvas.SetActive (false);
		yield return new WaitForSeconds(1f);
		//gobject.GetComponent<Collider2D>().name = "RestartButton";
	}

	void OnMouseDown()
	{
		//gameObject.transform.localScale = new Vector2 (0.65f, 0.65f);
		//Time.timeScale = 1;
		//gameObject.collider2D.enabled = false;
	}

	void OnMouseUp()
	{
		if (gameObject.GetComponent<Collider2D>().name == "PlayHand" && isPlayHand) {
						startLevel ();

			if(startCanvas.activeSelf && canvasIsActive)
			{
				print("StartCanvas is active");
			}
			else{
				//print("StartCanvas is not active");
				//gameObject.GetComponent<Collider2D>().name = "Taptostart";
				//startCanvas.SetActive (false);

				hunter = GameObject.FindGameObjectWithTag ("Player");
				hunterMovement = hunter.GetComponent<HunterMovement> ();
				hunterMovement.letStart ();
				startLevel();
				gameObject.transform.position = new Vector2 (11f, 11f);
				render.sprite = start;
				StartCoroutine(waitTime(gameObject));	
			}
			isPlayHand = false;
				}
		/*else if (gameObject.GetComponent<Collider2D>().name == "RestartButton") {
			//startLevel ();

			GameComponent.transform.position = new Vector2 (6.24f, GameComponent.transform.position.y);

			gameObject.transform.position = new Vector2 (11f, 11f);
			GameObject hunt = GameObject.Find("Object");
			if(hunt == null)
			{
				hunt = GameObject.Find ("Object(Clone)");
			}
			Destroy(hunt);
			Destroy(GameObject.Find ("GameOver(Clone)"));
			GameObject h = (GameObject)Instantiate(hunterPrefab, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
			gameObject.GetComponent<Collider2D>().name = "StartButton";

			HunterMovement hRestart = h.GetComponent<HunterMovement> ();
			hRestart.letStart();

			GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird2D");
			StartCoroutine(InitiateEnemy());
			if(birds.Length == 2)
			{
				firstWave = true;
				StartCoroutine(InitiateBird (1));
			}
			else if(birds.Length == 1){
				firstWave = true;
				StartCoroutine(InitiateBird (2));
			}
		}*/

	}

	public void startLevel()
	{
		if (counter == 0) {
			//gameObject.transform.localScale = new Vector2 (0.7f, 0.7f);
			//render.sprite = tap;
			//render.enabled = false;
			enableObject();
			counter++;
			//StartCoroutine(InitiateEnemy());
		}
	}

	public void enableObject()
	{
		render.enabled = true;
		StartCoroutine(InitiateBird (3));
	}

	public void setSecondTouch()
	{
		secondTouch = false;
		canvasIsActive = true;
		//hunterMovement.hiddenObjects ();
	}

	public void deactiveCanvas()
	{
		canvasIsActive = false;
		//hunterMovement.hiddenObjects ();
	}

	public void activatePlayMode()
	{
		isPlayHand = true;
		//GameComponent.transform.position = new Vector2 (6.35f, GameComponent.transform.position.y);
	}

	public void initBird(int length)
	{
		firstWave = true;
		StartCoroutine(InitiateBird (length));
	}

	public void initEmenyBird()
	{
		//StartCoroutine(InitiateEnemy());
	}

	IEnumerator InitiateBird(int length)
	{
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

	IEnumerator InitiateEnemy()
	{
		while(true)
		{
			for (int i=0;i<1;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (birdEnemy, new Vector2 (4.1f, Random.Range(1.2f, 3f)), spawnRotation);
				yield return new WaitForSeconds(0.5f);
			}
			break;
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (10);
	}

}
