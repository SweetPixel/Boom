using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	float timer = 90.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
	}

	void onGUI()
	{
		GUI.Box(new Rect(0,0, 50, 20), "" + timer.ToString("0"));
		//timeObject.text = timer.ToString ("0");
	}

}
