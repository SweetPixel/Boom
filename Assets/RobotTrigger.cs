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
		if(col.gameObject.name == "Player" && col.gameObject.transform.position.y > gameObject.transform.position.y)
		{
			col.gameObject.GetComponent<JoystickMovement>().bounce();
			Destroy (gameObject.transform.parent.gameObject);
		}
	}

}
