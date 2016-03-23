using UnityEngine;
using System.Collections;

public class MainCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Platform") {
			return;
		}
		
		if (col.gameObject.tag == "Player") {
			if(col.gameObject.GetComponent<PirateMovement>().isgrounded == true)
			{
				GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
				GameController gc = gcc.GetComponent<GameController>();
				gc.GameOver();
				Destroy(col.gameObject);
			}
			{
				Destroy (gameObject.transform.parent.gameObject);
			}
		}
		
	}

}
