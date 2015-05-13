using UnityEngine;
using System.Collections;

public class HunterMovement : MonoBehaviour {

	private float minX = -3.2f;
	private float maxX = 3.2f;
	//bool isRight = true;

	public Vector3 pointB;
	public GameObject bulletSpawn;
	public GameObject bullet;

	//Speed variable
	public float bulletSpeed = 1600f;
	public float hunterSpeed= 3.0f;

	bool isFired = false;

	bool isRight = true;
	public GameObject shoot;
	Animator anim;
	Animator animshoot;

	private bool roundAvailable = true;
	public GUIText fireCount;
	int fc = 6;

	public Sprite[] bulletCount;
	private int countIndex = 0;
	public GameObject _bulletCount;
	//SpriteRenderer renderer;

	SpriteRenderer hunterSpriteRenderer;
	public Sprite idle;

	private bool start = false;
	private bool isRestart = false;

	private Animator hunterAnime;

	private float restartInitiate;

	public GameObject leftTree;
	public GameObject bird;

	/*
	 *  Score Variables
	*/
	private int score = 0;
	public Sprite[] scoreSprite;
	public GameObject ScoreObject;
	SpriteRenderer scoreRenderer;
	public GameObject ScoreObjectTwo;
	SpriteRenderer scoreRendererTwo;
	private int scoreCounter = 0;

	public GUIText timeObject;

	public GameObject gameOver;
	public bool isGameOver = false;

	private GameObject startButton;

	IEnumerator Start () {

		//gameOver.SetActive (false);

		startButton = GameObject.Find ("StartButton");

		hunterAnime = gameObject.GetComponent<Animator> ();

		animshoot=shoot.GetComponent<Animator>();

		hunterSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

		scoreRenderer = ScoreObject.GetComponent<SpriteRenderer> ();
		scoreRenderer.sprite = scoreSprite [score];

		scoreRendererTwo = ScoreObjectTwo.GetComponent<SpriteRenderer> ();
		scoreRendererTwo.enabled = false;

		roundAvailable = true;
		restartInitiate = 0;
		fireCount.text = "6";
		//renderer =  _bulletCount.GetComponent<SpriteRenderer> ();
		//renderer.sprite = bulletCount [countIndex];

		anim = GetComponent<Animator> ();

		Flip ();
		Vector3 pointA = transform.position;
		while (roundAvailable) {
			//yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));
			yield return StartCoroutine(MoveObject(transform, new Vector3(5.6f, -1.99f, 0.02769041f), new Vector3(10.5f, -1.99f, 0.02769041f), hunterSpeed));
			isRight = false;
			yield return StartCoroutine(MoveObject(transform, new Vector3(10.5f, -1.99f, 0.02769041f), new Vector3(5.6f, -1.99f, 0.02769041f), hunterSpeed));
			isRight = true;
		}

		//restartLevel ();

	}

	IEnumerator restartLevel()
	{
		while (true) {
			if(isRestart)
			yield return new WaitForSeconds(2);
			Application.LoadLevel ("MainScene");
				}
	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			if(roundAvailable == false)
			{
				//anim.speed = 0;
				//Application.LoadLevel ("MainScene");
				//hunterSpriteRenderer.sprite = idle;
				isRestart = true;
				restartInitiate = 0;
				break;
			}
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
	
	// Use this for initialization
	//void Start () {
	//}

	void Update () {
		if (transform.position.x == 5.6f || transform.position.x == 10.5f) {
						//Debug.Log ("flip");
						Flip ();
				}

		restartInitiate += Time.deltaTime;

		//if (roundAvailable == false && restartInitiate > 1500) {
		//	restartInitiate = 0;

		//		}

		if (isRestart && restartInitiate > 3.2) {

			DestroyAllComponents();

			GameObject go = (GameObject)Instantiate (gameOver, new Vector2 (8.029126f, 1.784778f), Quaternion.identity);
			//DontDestroyOnLoad(go);

			isRestart = false;

			//Application.LoadLevel("SecondLevelInfinite");

			//setGameOver(true);
			startButton.transform.position = new Vector2 (8.029126f, 0.14f);

			//if(Application.loadedLevel == 0)
			//{
				
			//}
				}

	}

	public void DestroyAllComponents()
	{
		/*
		 * Kill the main bird.
		 */
		GameObject b = GameObject.Find ("Bird2D(Clone)");
		Destroy (b);

		/* 
		 * Kill all the enemies.
		 */
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("BirdEnemy2D");

		for (int  i = 0; i< enemies.Length; i++) {
			Destroy (enemies[i].gameObject);
				}

	}

	public void gotHit()
	{
		roundAvailable = false;
		gameObject.transform.position = new Vector2(transform.position.x, -1.81f);
		hunterAnime.SetBool("isHit", true);
	}

	public void initiateBird()
	{

		score ++;
		PlayerPrefs.SetInt ("Score", score);
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", score);
		timeObject.text = ""+score;
		if (score < 10) {
						scoreRenderer.sprite = scoreSprite [score];
		} else if (score == 10){
			scoreRenderer.sprite = scoreSprite [1];
			scoreRendererTwo.enabled = true;
				}
		else if(score > 10 && score < 20){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 20){
			scoreCounter = 2;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 20 && score < 30){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 30){
			scoreCounter = 3;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 30 && score < 40){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 40){
			scoreCounter = 4;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 40 && score < 50){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 50){
			scoreCounter = 5;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 50 && score < 60){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 60){
			scoreCounter = 6;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 60 && score < 70){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 70){
			scoreCounter = 7;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 70 && score < 80){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 80){
			scoreCounter = 8;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 80 && score < 90){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 90){
			scoreCounter = 9;
			scoreRenderer.sprite = scoreSprite [scoreCounter];
			scoreCounter = 0;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score > 90 && score < 100){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		Instantiate (bird, new Vector2 (4.1f, 2.958249f), Quaternion.identity);
	}

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
	///	charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Mouse0) && roundAvailable && start) {
			if(isFired == false)
			{
				fc = fc - 1;
				countIndex++;
				//renderer.sprite = bulletCount[countIndex];

				fireCount.text = "" + fc;
				isFired = true;
				animshoot.SetBool("isFired", isFired);
				//checkBirdPosition();
				StartCoroutine(Fired());
			}
				}
						
	}

	void checkBirdPosition()
	{
		ObstacleTreeScript otScript = new ObstacleTreeScript ();
		if (otScript.getRange ()) {
						otScript.SetAllCollidersStatus (false);
				} else {
			otScript.SetAllCollidersStatus (true);
				}
	}

	IEnumerator Fired()
	{
		yield return new WaitForSeconds(0.2f);
		if (isRight) {
			GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,-10f));
			game.rigidbody2D.AddForce(Quaternion.Euler(0,0,-15f) * Vector2.up * bulletSpeed);
				} else {
			GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,10f));
			game.rigidbody2D.AddForce(Quaternion.Euler(0,0,15f) * Vector2.up * bulletSpeed);
				}
		isFired = false;
		animshoot.SetBool("isFired", isFired);
		//if (countIndex == 6) {
		//	Debug.Log("Game Over");
		//	roundAvailable = false;

				//}
	}

	public void lost()
	{
		roundAvailable = false;
		gameObject.transform.position = new Vector2(transform.position.x, -1.81f);
		hunterAnime.SetBool("isLost", true);
	}

	public void letStart()
	{
		start = true;
	}

	//void Flip()
	//{
	//	Vector3 charScale = transform.localScale;
	//	charScale.x *= -1;
	//	transform.localScale = charScale;
	//}

}
