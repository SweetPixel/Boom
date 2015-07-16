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
		//GameComponent.transform.position = new Vector2 (6.24f, GameComponent.transform.position.y);

		GameObject explosion = GameObject.FindGameObjectWithTag ("BomberBirdExplosion");
		Destroy (explosion);

		//gameObject.transform.position = new Vector2 (11f, 11f);
		GameObject hunt = GameObject.FindGameObjectWithTag("Player");
		Destroy(hunt);

		Destroy(GameObject.Find ("GameOver(Clone)"));
		GameObject h = (GameObject)Instantiate(hunter, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
		//gameObject.GetComponent<Collider2D>().name = "StartButton";
		
		HunterMovement hRestart = h.GetComponent<HunterMovement> ();
		hRestart.letStart();
		//hRestart.setScoreToZero ();

		GameObject shc = GameObject.FindGameObjectWithTag("SandhillCrane");
		if (shc != null) {
			Destroy (shc);
				}

		GameObject[] be = GameObject.FindGameObjectsWithTag("Bird2D");
		for (int i=0; i < be.Length; i++) {
			Destroy(be[i]);
				}

		GameObject[] birds = GameObject.FindGameObjectsWithTag("BirdEnemy2D");
		for (int i=0; i < birds.Length; i++) {
			Destroy(birds[i]);
		}

		GameObject playhand = GameObject.FindGameObjectWithTag("PlayHand");
		//Destroy (playhand);

		//GameObject ph = (GameObject)Instantiate(playHandPrefab, new Vector3(11f, 11f, 0.02769041f), Quaternion.identity);
		StartGame sg = playhand.GetComponent<StartGame>();
		sg.initBird (3);

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
