﻿using UnityEngine;
using System.Collections;

public class DestroyOnPlatform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		Debug.Log (col.gameObject.name);
		if(col.gameObject.tag == "Platform") {
			Destroy(gameObject);
		}
	}

}
