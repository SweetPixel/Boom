using UnityEngine;
using System.Collections;

public class ObstacleTreeScript : MonoBehaviour {

	public GameObject bird;
	public Vector2 minPos;
	public Vector2 maxPos;

	private bool inRange = false;

	// Use this for initialization
	void Start () {
		//gameObject.collider2D.enabled = false;
		//SetAllCollidersStatus (false);
	}
	
	// Update is called once per frame
	void Update () {

		/* if ((bird.transform.position.x < maxPos.x && bird.transform.position.y < maxPos.y) || (bird.transform.position.x > minPos.x && bird.transform.position.y > minPos.y))
		{
						//gameObject.collider2D.enabled = true;
			SetAllCollidersStatus (true);
				} else {
						//gameObject.collider2D.enabled = false;
			SetAllCollidersStatus (false);
				} */

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Bird2D(Clone)") {
			//bird.collider2D.enabled = false;
			inRange = true;
		}
	//if (col.gameObject.name == "Bird2D(Clone)") {
	//		Debug.Log (col.gameObject.name);
	//		col.gameObject.collider2D.enabled = false;

	//	}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.name == "Bird2D(Clone)") {
			//bird.collider2D.enabled = false;
			inRange = true;
			}
		if (col.gameObject.name == "Bullets(Clone)") {
			//Destroy(gameObject);
			Destroy (col.gameObject);
		}
	}	

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.name == "Bird2D(Clone)") {
			//bird.collider2D.enabled = true;
			inRange = false;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.name == "Bird2D(Clone)") {
			//bird.collider2D.enabled = true;
			inRange = false;
		}
	}

	public bool getRange()
	{
		return inRange;
	}

	public void SetAllCollidersStatus (bool active) {
		foreach(Collider2D c in GetComponents<Collider2D> ()) {
			c.enabled = active;
		}
	}

}
