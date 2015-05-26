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

	bool isRight = false;
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

	private int b = 50;
	private int bulletCounter = 9;
	public GameObject bulletOne;
	public GameObject bulletTwo;
	private SpriteRenderer bulletOneRender;
	private SpriteRenderer bulletTwoRender;

	float[] Yaxis = { 2.3f , 1.7f, 1.15f, 0.75f};
	float[] Xaxis = { 5.1f , 11.3f };
	public float nextFire;
	private bool startFiring = false;

	IEnumerator Start () {
		/* Bullet Renderers */

		b = 50;
		bulletCounter = 9;

		bulletOne = GameObject.Find ("BulletSprite");
		bulletTwo = GameObject.Find ("BulletSpriteTwo");

		bulletOneRender = bulletOne.GetComponent<SpriteRenderer> ();
		bulletOneRender.sprite = scoreSprite [0];

		bulletTwoRender = bulletTwo.GetComponent<SpriteRenderer> ();
		bulletTwoRender.sprite = scoreSprite [5];
		bulletTwoRender.enabled = true;

		/* End of Bullet Renderer */

		startButton = GameObject.Find ("StartButton");

		hunterAnime = gameObject.GetComponent<Animator> ();

		animshoot=shoot.GetComponent<Animator>();

		hunterSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

		/* Score Sprites */
		ScoreObject = GameObject.Find ("ScoreSprite");
		ScoreObjectTwo = GameObject.Find ("ScoreSpriteTwo");

		scoreRenderer = ScoreObject.GetComponent<SpriteRenderer> ();
		scoreRenderer.sprite = scoreSprite [score];

		scoreRendererTwo = ScoreObjectTwo.GetComponent<SpriteRenderer> ();
		scoreRendererTwo.enabled = false;

		/* Bullets Available */
		roundAvailable = true;
		restartInitiate = 0;



		anim = GetComponent<Animator> ();

		/* Flip Function */
		Flip ();

		/* Start Hunter Movement from the middle */
		yield return StartCoroutine(MoveObject(transform, new Vector3(8.15f, -1.99f, 0.02769041f), new Vector3(9.80f, -1.99f, 0.02769041f), hunterSpeed));

		Vector3 pointA = transform.position;
		while (roundAvailable) {
			yield return StartCoroutine(MoveObject(transform, new Vector3(9.80f, -1.99f, 0.02769041f), new Vector3(6.35f, -1.99f, 0.02769041f), hunterSpeed));
			isRight = true;
			yield return StartCoroutine(MoveObject(transform, new Vector3(6.35f, -1.99f, 0.02769041f), new Vector3(9.80f, -1.99f, 0.02769041f), hunterSpeed));
			isRight = false;
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

	void Update () {

		/*if (bulletCounter == 1) {
			//missOne.renderer.enabled = false;
			rendererOne.SetBool("isMissed", true);
		}
		else if (bulletCounter == 2) {
			//missTwo.renderer.enabled = false;
			rendererTwo.SetBool("isMissed", true);
		}
		else if (bulletCounter == 3) {
			//missThree.renderer.enabled = false;
			rendererThree.SetBool("isMissed", true);
			lost();
		}*/

		//if (transform.position.x == 6.35f || transform.position.x == 9.80f) {
						//Debug.Log ("flip");
		//				Flip ();
		//		}

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

			startButton.transform.position = new Vector2 (8.029126f, 0.14f);

			//Application.LoadLevel("SecondLevelInfinite");
				}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Coin(Clone)") {
			Destroy(col.gameObject);
			initiateBird();
				}

		if (col.gameObject.name == "HunterColliderLeft" ||col.gameObject.name == "HunterColliderRight") {
			Flip ();
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
		gameObject.transform.position = new Vector2(transform.position.x, -1.9f);
		hunterAnime.SetBool("isHit", true);
	}

	public void initiateBird()
	{

		score ++;
		PlayerPrefs.SetInt ("Score", score);
		if (PlayerPrefs.GetInt ("Score") > PlayerPrefs.GetInt ("HighScore"))
			PlayerPrefs.SetInt ("HighScore", score);
		if (score < 10) {
						scoreRenderer.sprite = scoreSprite [score];
		} else if (score == 10){
			bulletCounter--;
			//setMisses();
			scoreRenderer.sprite = scoreSprite [1];
			scoreRendererTwo.enabled = true;
				}
		else if(score > 10 && score < 20){
			scoreCounter++;
			scoreRendererTwo.sprite = scoreSprite [scoreCounter];
		}
		else if(score == 20){
			bulletCounter--;
			//setMisses();
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
			//setMisses();
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

		int index = Random.Range(0,4);
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

		Instantiate (bird, new Vector2 (x, y), Quaternion.identity);
	}

	/*public void setCounter()
	{
		bulletCounter++;
	}

	private void setMisses()
	{
		if (bulletCounter == 0) {
			rendererOne.SetBool("isMissed", false);
				}
		if (bulletCounter == 1) {
			rendererTwo.SetBool("isMissed", false);
		}
	} */

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
	///	charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
	}

	// Update is called once per frame
	void FixedUpdate () {
		/* if (Input.GetKey (KeyCode.Mouse0) && roundAvailable && start) 
		{
			if(isFired == false)
			{

				bulletSpriteSetter();
				isFired = true;
				animshoot.SetBool("isFired", isFired);
				//checkBirdPosition();
				StartCoroutine(Fired());
			}
		} */

		GameObject start = GameObject.Find ("StartButton");
		if (start == null) {
			startFiring = true;
				}

		if (Input.GetKey (KeyCode.Mouse0) && Time.time > nextFire && roundAvailable && startFiring) {
			nextFire = Time.time + 0.5f;
			if(isFired == false)
			{
				bulletSpriteSetter();
				isFired = true;
				animshoot.SetBool("isFired", isFired);
				StartCoroutine(Fired());
			}
		}


	}

	IEnumerator Fired()
	{
		yield return new WaitForSeconds(0.25f);
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

	void bulletSpriteSetter()
	{
		b = b - 1;
		if (b > 40) {
			bulletTwoRender.sprite = scoreSprite[4];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
				}
		else if (b == 40) {
			bulletTwoRender.sprite = scoreSprite[4];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 40 && b > 30) {
			bulletTwoRender.sprite = scoreSprite[3];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		else if (b == 30) {
			bulletTwoRender.sprite = scoreSprite[3];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 30 && b > 20) {
			bulletTwoRender.sprite = scoreSprite[2];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		else if (b == 20) {
			bulletTwoRender.sprite = scoreSprite[2];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 20 && b > 10) {
			bulletTwoRender.sprite = scoreSprite[1];
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		else if (b == 10) {
			bulletTwoRender.sprite = scoreSprite[1];
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter  = 9;
		}
		else if (b < 10 && b > 0) {
			bulletTwoRender.enabled = false;
			bulletOneRender.sprite = scoreSprite[bulletCounter];
			bulletCounter  = bulletCounter - 1;
		}
		if (b == 0) {
			bulletOneRender.sprite = scoreSprite[0];
			bulletCounter = 9;
			lost();
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

	/* IEnumerator lost()
	{
		roundAvailable = false;
		gameObject.transform.position = new Vector2(transform.position.x, -1.81f);
		hunterAnime.SetBool("isLost", true);
		yield return new WaitForSeconds (0f);
	} */

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

}
