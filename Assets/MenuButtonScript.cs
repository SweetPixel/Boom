using UnityEngine;
using System.Collections;

public class MenuButtonScript : MonoBehaviour {

	public GameObject guns;
	private StartGame sg;
	//ButtonClickScript btnScript;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp()
	{
		//btnScript.activateCanvas ();
		//guns.SetActive (false);
		//sg.deactiveCanvas();
		Application.LoadLevel (0);

	}
}
