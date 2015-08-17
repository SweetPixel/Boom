using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject pauseCanvas;
	Animator anim;

	// Use this for initialization
	void Start () {
		pauseCanvas.SetActive (false);
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("Mouse down");
		anim.SetBool ("isPause", true);
	}

	void OnMouseUp()
	{
		anim.SetBool ("isPause", false);
		pauseCanvas.SetActive (true);
		Time.timeScale = 0;
	}


}
