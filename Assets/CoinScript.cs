using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<Rigidbody2D>().AddForce ( Vector2.up *30);
	}

	void OnCollisionEnter2D(Collision2D col)
	{

	}

}
