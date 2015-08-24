using UnityEngine;
using System.Collections;

public class StartSceneFadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator exit()
	{
		GameObject.FindGameObjectWithTag ("Start3Buttons").GetComponent<Animator> ().SetBool ("IsPressed", true);
		yield return new WaitForSeconds(0f);
	}

}
