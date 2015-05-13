using UnityEngine;
using System.Collections;

public class RestartGame : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
		hunterMovement = hunter.GetComponent<HunterMovement> ();
		hunterMovement.letStart();
		initiateBird ();
		StartCoroutine (InitiateEnemy ());
	}
	
	// Update is called once per frame
	void Update () {
		
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

}
