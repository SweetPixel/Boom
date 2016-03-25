using UnityEngine;
using System.Collections;

public class AirEnemyGeneratorScript : MonoBehaviour {

	public GameObject[] enemies;
	public float delay = 1f;
	public float[] Xaxis = { -6f , 6f };
	public int frequency = 5;

	private bool isInitial = true;

	// Use this for initialization
	void Start () {
		StartCoroutine(InitiateBird());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitEnemy()
	{
		Quaternion spawnRotation = Quaternion.identity;
		//Instantiate (bird, new Vector2 (5.1f, 2.958249f), Quaternion.identity);\
		int objIndex = Random.Range(0,2);
		if(objIndex == 0)
		{
			
			int index = Random.Range(0,2);
			float x = 3.6f;
			if(index == 0)
			{
				x = Xaxis[0];
			}
			else if(index == 1)
			{
				x = Xaxis[1];
			}
			Instantiate (enemies[objIndex], new Vector2(x,enemies[objIndex].transform.position.y) , Quaternion.identity);
		}
		else{
			Instantiate (enemies[objIndex], new Vector2(7f, enemies[objIndex].transform.position.y), Quaternion.identity);
		}
	}

	IEnumerator InitiateBird()
	{
		for (int i=0;i<frequency;i++) 
		{
			Quaternion spawnRotation = Quaternion.identity;
			//Instantiate (bird, new Vector2 (5.1f, 2.958249f), Quaternion.identity);\
			int objIndex = Random.Range(0,2);
			int index = Random.Range(0,2);
			float x = 3.6f;
			if(index == 0)
			{
				x = Xaxis[0];
			}
			else if(index == 1)
			{
				x = Xaxis[1];
			}
			Instantiate (enemies[1], new Vector2(x,enemies[objIndex].transform.position.y) , Quaternion.identity);
			yield return new WaitForSeconds(delay);
		}
	}

}
