using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public Sprite tap;
	public Sprite start;
	public GameObject levelLabel;
	public Sprite levelOne;
	public Sprite levelTwo;
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

		if (Application.loadedLevel == 1) {
						//Levelrender.sprite = levelTwo;
			gameObject.transform.position = new Vector2(15f, 4f);
						startLevel();
						StartCoroutine (InitiateEnemy ());
		} else if(Application.loadedLevel == 0) {
			StartCoroutine (InitiateEnemy ());
				}

		GameObject go = GameObject.Find ("GameOver(Clone)");
		if (go == null) {
			Destroy(go);
				}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0) && secondTouch) {
			hunterMovement.letStart();
			//Destroy(gameObject);
			gameObject.transform.position = new Vector2 (11f, 11f);
			render.sprite = start;
				}


	}


	void OnMouseDown()
	{
		gameObject.transform.localScale = new Vector2 (0.65f, 0.65f);
		//Time.timeScale = 1;
		//gameObject.collider2D.enabled = false;
	}

	void OnMouseUp()
	{
		startLevel ();
	}

	public void startLevel()
	{
		if (counter == 0) {
			gameObject.transform.localScale = new Vector2 (0.7f, 0.7f);
			
			GameObject clone =(GameObject) Instantiate (levelLabel, levelLabel.transform.position, Quaternion.identity);
			clone.transform.position= new Vector2(10f,10f);
			clone.renderer.enabled=false;
			//sclone.renderer.enabled=true;
			//StartCoroutine(wait());

			render.sprite = tap;
			render.enabled = false;
			
			counter++;
		}
	}

	public void enableObject()
	{
		render.enabled = true;
		initiateBird ();
		//Vector2 size = new Vector2(6.0f, 6.0f);
		//this.collider.size = size;
		secondTouch = true;
	}

	public void initiateBird()
	{
		Instantiate (bird, new Vector2 (4.1f, 2.958249f), Quaternion.identity);
	}

	IEnumerator InitiateEnemy()
	{
		yield return new WaitForSeconds(1.5f);
		while(firstWave)
		{
			for (int i=0;i<3;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (birdEnemy, new Vector2 (4.1f, Random.Range(1.2f, 3f)), spawnRotation);
				yield return new WaitForSeconds(1f);
			}
			firstWave = false;
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds (10);
	}

}
