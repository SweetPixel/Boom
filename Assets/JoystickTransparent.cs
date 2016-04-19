using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class JoystickTransparent : MonoBehaviour {

	public float alphaLevel = 0.2f;

	// Use this for initialization
	void Start () {
	
		GameObject.Find ("JoystickBase").GetComponent<Image>().color = new Color (1f, 1f, 1f, alphaLevel);
		GameObject.Find ("Stick").GetComponent<Image>().color = new Color (1f, 1f, 1f, alphaLevel);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
