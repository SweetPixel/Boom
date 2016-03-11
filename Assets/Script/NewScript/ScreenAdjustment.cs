using UnityEngine;
using System.Collections;

public class ScreenAdjustment : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 1024 / 768;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
