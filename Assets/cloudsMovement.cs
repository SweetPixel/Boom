using UnityEngine;
using System.Collections;

public class cloudsMovement : MonoBehaviour {

	public Vector3 newpos;

	// Use this for initialization
	void Start () {
		newpos.y = transform.position.y;
		newpos.z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		//float step = 2f * Time.deltaTime;
		//transform.position = Vector3.MoveTowards(transform.position, newpos, step);
		transform.Translate(Vector3.right * -0.2f * Time.deltaTime);

		if (transform.position.x < 5.5f) {
			transform.position = newpos;
				}

	}
}
