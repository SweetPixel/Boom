using UnityEngine;
using System.Collections;

public class BananaScript : MonoBehaviour {

	public Sprite bananaSmash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		//Debug.Log (col.gameObject.name);
		
		if(col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
			Destroy(col.gameObject);
		}

		if(col.gameObject.name == "Platform") {
			gameObject.GetComponent<SpriteRenderer>().sprite = bananaSmash;
			Destroy(gameObject, 0.1f);
		}

		if (col.gameObject.tag == "Player") {
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.GameOver();
			Destroy(col.gameObject);
		}

	}

}
