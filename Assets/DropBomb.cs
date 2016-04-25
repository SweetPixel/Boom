using UnityEngine;
using System.Collections;

public class DropBomb : MonoBehaviour {

	public int frequency = 10;
	public float delay = 2f;
	public GameObject bomb;
	public GameObject spawn;
	private bool isFirstLevel = true;

	// Use this for initialization
	void Start () {
		StartCoroutine(InitiateBombs());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator InitiateBombs()
	{
		yield return new WaitForSeconds(1f);
		while(true)
		{
			for (int i=0;i<frequency;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				//Quaternion spawnRotation = Quaternion.identity;
				//Instantiate (bomb, spawn.transform.position, Quaternion.identity);

				GameObject bomb = LandMinePooledScript.current.GetPooledObject();
				bomb.transform.position = spawn.transform.position;
				bomb.transform.rotation = Quaternion.identity;
				bomb.SetActive(true);

				if(isFirstLevel)
				{
					yield return new WaitForSeconds(delay);
				}
				else{
					yield return new WaitForSeconds(Random.Range(0.2f, delay));
				}
			}
		}
	}

}
