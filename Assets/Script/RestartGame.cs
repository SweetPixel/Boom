using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

	//SpriteRenderer Levelrender;
	
	SpriteRenderer render;
	public int counter = 0;

	public GameObject hunter;
	HunterMovement hunterMovement;

	
	bool firstWave = true;
	
	BoxCollider2D collider;
	private bool secondTouch = false;
	private bool restart = false;

	// Use this for initialization
	void Start () {
		hunterMovement = hunter.GetComponent<HunterMovement> ();
		hunterMovement.letStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp()
	{
		//GameComponent.transform.position = new Vector2 (6.24f, GameComponent.transform.position.y);
		
		//gameObject.transform.position = new Vector2 (11f, 11f);
		GameObject hunt = GameObject.Find("Object");
		if(hunt == null)
		{
			hunt = GameObject.Find ("Object(Clone)");
		}
		Destroy(hunt);
		Destroy(GameObject.Find ("GameOver(Clone)"));
		GameObject h = (GameObject)Instantiate(hunter, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
		//gameObject.GetComponent<Collider2D>().name = "StartButton";
		
		HunterMovement hRestart = h.GetComponent<HunterMovement> ();
		hRestart.letStart();
		
		GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird2D");

		GameObject playhand = GameObject.Find("PlayHand");
		StartGame sg = playhand.GetComponent<StartGame>();
		
		sg.initEmenyBird();
		if(birds.Length == 2)
		{
			sg.initBird(1);
		}
		else if(birds.Length == 1){
			sg.initBird(2);
		}
	}

}
