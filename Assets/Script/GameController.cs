using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public float timer = 90.0f;

	private float tempTimer = 0f;

	public GUIText timeObject;
	public GameObject birdEnemy;

	private bool firstWave = true;

	// Use this for initialization
	void Start () {
		//timer -= Time.deltaTime;
		timeObject.text = "" + timer;
	}

	void Update() {

		tempTimer++;
		if (tempTimer % 100 == 0) {
			timer --; //= Time.deltaTime;
			timeObject.text = "" + timer;
				}
	}

	//void onGUI()
	//{
	//	GUI.Box(new Rect(0,0, 50, 20), "" + timer.ToString("0"));
	//	//timeObject.text = timer.ToString ("0");
	//}

	IEnumerator SpawnWaves()
	{
		Quaternion spawnRotation = Quaternion.identity;
		Instantiate (birdEnemy, new Vector2 (4.1f, 2.0f), spawnRotation);
		yield return new WaitForSeconds(2f);

		//while(firstWave)
		//{
		//	for (int i=0;i<1;i++) 
		//	{
		//		//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
		//		Quaternion spawnRotation = Quaternion.identity;
		//		Instantiate (birdEnemy, new Vector2 (4.1f, 2.0f), spawnRotation);
		//		yield return new WaitForSeconds(2f);
		//		Debug.Log("First Wave");
		//	}
		//	yield return new WaitForSeconds(2f);
		//	firstWave = true;
		//}
	}

	public void GameOver()
	{

	}

}
