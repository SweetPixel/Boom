using UnityEngine;
using System.Collections;

public class ButtonClickScript : MonoBehaviour {

	public GameObject guns;
	public GameObject maps;
	private StartGame sg;
	private GameObject playHand;
	public GameObject startCanvas;
	public GameObject hunterPrefab;

	// Use this for initialization
	void Start () {
		guns.SetActive (false);
		playHand = GameObject.FindGameObjectWithTag ("PlayHand");
		sg = playHand.GetComponent<StartGame> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonClick(string buttonName)
	{
		if (buttonName == "GunsButton") {
						guns.SetActive (true);
		} else if (buttonName == "BackButton") {
			guns.SetActive (false);
			sg.deactiveCanvas();
				}

		if (buttonName == "StartButton") {
			sg.activatePlayMode();
			startCanvas.SetActive(false);
			GameObject hand = GameObject.Find("PlayHand");
			hand.transform.position = new Vector2(8.089996f, 0.15f);
				}

		if (buttonName == "MapButton") {
			maps.SetActive (true);
		}

		if (buttonName == "BackMapButton") {
			maps.SetActive (false);
			sg.deactiveCanvas();
		}

		if (buttonName == "Play") {
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}

		/*if (buttonName == "PlayWithRifle") {
			PlayerPrefs.SetInt ("gunIndex", 1);
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}

		if (buttonName == "PlayWithAk47") {
			PlayerPrefs.SetInt ("gunIndex", 2);
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}

		if (buttonName == "PlayWithShotgun") {
			PlayerPrefs.SetInt ("gunIndex", 3);
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}

		if (buttonName == "PlayWithSniper") {
			PlayerPrefs.SetInt ("gunIndex", 4);
			guns.SetActive (false);
			sg.deactiveCanvas();
			restartLevel();
		}*/

		/*if (buttonName == "RestartButton") {
			gameObject.transform.position = new Vector2 (11f, 11f);
			GameObject hunt = GameObject.Find("Object");
			if(hunt == null)
			{
				hunt = GameObject.Find ("Object(Clone)");
			}
			Destroy(hunt);
			Destroy(GameObject.Find ("GameOverCanvas(Clone)"));
			GameObject h = (GameObject)Instantiate(hunterPrefab, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
			
			HunterMovement hRestart = h.GetComponent<HunterMovement> ();
			hRestart.letStart();
			
			GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird2D");

			GameObject playhand = GameObject.Find("PlayHand");
			StartGame sg = playHand.GetComponent<StartGame>();

			sg.initEmenyBird();
			if(birds.Length == 2)
			{
				sg.initBird(1);
			}
			else if(birds.Length == 1){
				sg.initBird(2);
			}
		}


		if (buttonName == "MenuButton") {
			startCanvas.SetActive(true);
			guns.SetActive (false);
			sg.deactiveCanvas();
			GameObject gc = GameObject.Find("GameOverCanvas(Clone)");
			Destroy(gc);
				}*/

	}

	private void restartLevel()
	{
		GameObject hunt = GameObject.Find("Object");
		if(hunt == null)
		{
			hunt = GameObject.Find ("Object(Clone)");
		}
		Destroy(hunt);
		Destroy(GameObject.Find ("GameOver(Clone)"));
		GameObject h = (GameObject)Instantiate(hunterPrefab, new Vector3(8.15f, -2.15f, 0.02769041f), Quaternion.identity);
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

	public void activateCanvas()
	{
		startCanvas.SetActive(true);
	}

}
