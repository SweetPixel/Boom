using UnityEngine;
using System.Collections;

public class BalloonScript : MonoBehaviour {

	public float speed = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector2(gameObject.transform.position.x+0.01f, gameObject.transform.position.y);
		if(gameObject.transform.position.x > 3.4f)
		{
			Destroy(gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//Debug.Log (col.gameObject.name);
		if(col.gameObject.tag == "Bird2D") {
			return;
		}

		
		if (col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
			Destroy(col.gameObject);
		}
	}

}
