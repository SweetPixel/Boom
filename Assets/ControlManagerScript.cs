using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		#if UNITY_IOS
		ActivateControl(true);
		#endif


		#if UNITY_STANDALONE_WIN
		ActivateControl(false);
		#endif



	}

	void ActivateControl(bool x)
	{
		GameObject.Find ("JoystickBase").GetComponent<Image> ().enabled = x;
		GameObject.Find ("Stick").GetComponent<Image> ().enabled = x;
		GameObject.Find ("Fire").GetComponent<Image> ().enabled = x;
		GameObject.Find ("Jump").GetComponent<Image> ().enabled = x;
	}

}
