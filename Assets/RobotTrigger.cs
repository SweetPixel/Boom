using UnityEngine;
using System.Collections;

public class RobotTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("Pirate y: + " + col.gameObject.transform.position.y + " and kangY: " + gameObject.transform.position.y);
		if(col.gameObject.name == "Pirate" && col.gameObject.transform.position.y > gameObject.transform.position.y)
		{
			Destroy (gameObject.transform.parent.gameObject);
		}
	}

}
