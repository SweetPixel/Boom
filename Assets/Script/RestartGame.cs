using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	//SpriteRenderer Levelrender;
	
	SpriteRenderer render;
	public int counter = 0;

	public GameObject hunter;
	HunterMovement hunterMovement;
	public GameObject playHandPrefab;
	
	bool firstWave = true;
	
	BoxCollider2D collider;
	private bool secondTouch = false;
	private bool restart = false;

	// Use this for initialization
	void Start () {
		/*hunterMovement = hunter.GetComponent<HunterMovement> ();
		hunterMovement.letStart();*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp()
	{
		//Destroy the hunter
		GameObject hunt = GameObject.FindGameObjectWithTag("Player");
		Destroy(hunt);

		//Destroy the bullets which are on the ground.
		GameObject[] bullets = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject b in bullets) {
			Destroy(b);
		}

		//Destroy the bomber bird explosion.
		GameObject[] bbExplosion = GameObject.FindGameObjectsWithTag ("BomberBirdExplosion");
		if (bbExplosion != null) {
			foreach(GameObject exp in bbExplosion)
			{
				Destroy (exp);
			}
		}

		//Destroy GameOver object.
		GameObject[] go = GameObject.FindGameObjectsWithTag ("GameOver");
		for (int i = 0; i< go.Length; i++) {
						Destroy (go [i].gameObject);
				}
		//hRestart.setScoreToZero ();

		//Destroy the glassBreak which appears when user(hunter) is idle.
		GameObject glassBreak = GameObject.FindGameObjectWithTag("Glass Break");
		if (glassBreak != null) {
			Destroy (glassBreak);
		}

		//Destroy any sandhillCrane object.
		GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
		if (shc != null) {
			Destroy (shc);
				}

		//Destroy all the pelicans
		GameObject[] be = GameObject.FindGameObjectsWithTag("Bird2D");
		for (int i=0; i < be.Length; i++) {
			Destroy(be[i]);
				}

		//Destroy the enemy birds (bird with the bomb).
		GameObject[] birds = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
		for (int i=0; i < birds.Length; i++) {
			Destroy(birds[i]);
		}

		GameObject playhand = GameObject.FindGameObjectWithTag("PlayHand");
		//Destroy (playhand);

		//Get Gamecontroller object and set the values to zero.
		GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
		GameController gc = gcc.GetComponent<GameController> ();
		gc.setScoreToZero ();

		//GameObject ph = (GameObject)Instantiate(playHandPrefab, new Vector3(11f, 11f, 0.02769041f), Quaternion.identity);
		StartGame sg = playhand.GetComponent<StartGame>();
		sg.initBird (3);

			GameObject h = (GameObject)Instantiate(hunter, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
			//gameObject.GetComponent<Collider2D>().name = "StartButton";
			
			HunterMovement hRestart = h.GetComponent<HunterMovement> ();
			hRestart.letStart();

		/*sg.initEmenyBird();
		if(birds.Length == 2)
		{
			sg.initBird(1);
		}
		else if(birds.Length == 1){
			sg.initBird(2);
		}*/

	}

}
