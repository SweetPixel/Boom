using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

	public float angle = 45;
	public float speed= 5.0f;

	// Use this for initialization
	void Start () {
		float amtToMove = speed*Time.deltaTime;
		transform.Translate(Vector3.down*amtToMove);
	}
	
	// Update is called once per frame
	void Update () {

		/*
		var dir = rigidbody2D.velocity;
		if (dir != Vector2.zero) {
			angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(angle, -Vector3.forward);
		}
		*/

	}
}
