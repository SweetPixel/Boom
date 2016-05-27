using UnityEngine;
using System.Collections;

public class ObstacleGenerator : MonoBehaviour {

	public GameObject mushroom;
	public GameObject carrot;
	public GameObject hound;
	public GameObject sinMovement;
	public GameObject kangaroo;
	public GameObject armadilo;

	public int frequency = 10;
	public float initialDelay = 2f;
	public float delayBetweenEnemies = 4f;
	private float delayForKangaroo= 10f;
	private float previousDelay;

	private float[] Xaxis = { 7f, -8f };

	public GameObject[] enemies;

	// Use this for initialization
	void Start () {

		StartCoroutine (InitiateEnemies ());

		/*StartCoroutine (InitiateCarrot ());
		StartCoroutine (InitiateMushroom ());
		StartCoroutine (InitiateHound ());
		StartCoroutine (InitiateSineWave ());
		StartCoroutine (InitiateKangaroo ());*/
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator InitiateEnemies()
	{
		yield return new WaitForSeconds(initialDelay);
		while(true)
		{
			GameObject enemy = (GameObject)Instantiate (enemies[1], new Vector2(8f, enemies[1].transform.position.y), Quaternion.identity);
			/*int i = Random.Range(0,2);
			int index = Random.Range(0, enemies.Length);
			if(i == 0)
			{
				GameObject enemy = (GameObject)Instantiate (enemies[index], new Vector2(8f, enemies[index].transform.position.y), Quaternion.identity);
			}
			else{
				GameObject enemy = (GameObject)Instantiate (enemies[index], new Vector2(-8f, enemies[index].transform.position.y), Quaternion.identity);
				/*if(index == 2)
				{
					enemy.GetComponent<HopMovement>().setRight();
				}
			}*/

			/*if(index == 2)
			{
				previousDelay = delayBetweenEnemies;
				delayBetweenEnemies = delayForKangaroo;
				yield return new WaitForSeconds(delayBetweenEnemies);
				delayBetweenEnemies = previousDelay;
			}
			else{
				yield return new WaitForSeconds(delayBetweenEnemies);
			}*/
			yield return new WaitForSeconds(delayBetweenEnemies);
			/*Instantiate (carrot, new Vector2(8f, -1.65f), Quaternion.identity);
			yield return new WaitForSeconds(delayBetweenEnemies);
			Instantiate (kangaroo, new Vector2(7f, kangaroo.transform.position.y), Quaternion.identity);
			yield return new WaitForSeconds(delayBetweenEnemies);*/
		}

	}

	IEnumerator InitiateMushroom()
	{
		yield return new WaitForSeconds(Random.Range(2f,5f));
		while(true)
		{
			for (int i=0;i<frequency;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (mushroom, new Vector2(7f, -2.38f), Quaternion.identity);
				yield return new WaitForSeconds(5f);

			}
		}
	}

	IEnumerator InitiateCarrot()
	{
		yield return new WaitForSeconds(Random.Range(5f,10f));
		while(true)
		{
			for (int i=0;i<frequency;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (carrot, new Vector2(8f, -2.678f), Quaternion.identity);
				yield return new WaitForSeconds(5f);
			}
		}
	}

	IEnumerator InitiateHound()
	{
		yield return new WaitForSeconds(Random.Range(5.5f, 7.2f));
		while(true)
		{
			for (int i=0;i<frequency;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hound, new Vector2(7f, hound.transform.position.y), Quaternion.identity);
				yield return new WaitForSeconds(6f);
			}
		}
	}

	IEnumerator InitiateSineWave()
	{
		yield return new WaitForSeconds(Random.Range(5.5f, 7.2f));
		while(true)
		{
			for (int i=0;i<frequency;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (sinMovement, new Vector2(7f, sinMovement.transform.position.y), Quaternion.identity);
				yield return new WaitForSeconds(8f);
			}
		}
	}

	IEnumerator InitiateKangaroo()
	{
		yield return new WaitForSeconds(Random.Range(5.5f, 7.2f));
		while(true)
		{
			for (int i=0;i<frequency;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (kangaroo, new Vector2(7f, kangaroo.transform.position.y), Quaternion.identity);
				yield return new WaitForSeconds(10f);
			}
		}
	}

}
