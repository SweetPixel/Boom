using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour {

	public float speed = 3f;
	public GameObject blast;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.down * speed);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		Debug.Log (col.gameObject.name);
		if(col.gameObject.tag == "Platform") {
			Instantiate(blast, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}

}
