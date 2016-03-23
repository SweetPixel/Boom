using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		Debug.Log ("debugger");

		if (col.gameObject.tag == "Player") 
		{
			foreach (Transform child in gameObject.transform.parent.transform)
			{
				child.gameObject.GetComponent<BoxCollider2D>().enabled = false;
				Destroy(child.gameObject);
			}
			Destroy (gameObject.transform.parent.gameObject);
			//Destroy (gameObject);
		}
		
	}

}
