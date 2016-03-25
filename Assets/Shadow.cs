using UnityEngine;
using System.Collections;

public class Shadow : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<PirateMovement> ().isgrounded == true) {
			gameObject.transform.position = new Vector3 (GameObject.FindGameObjectWithTag ("Player").transform.position.x,
		                                            GameObject.FindGameObjectWithTag ("Player").transform.position.y - 0.5f,
		                                            GameObject.FindGameObjectWithTag ("Player").transform.position.z);
		}
		else{
			gameObject.transform.position = new Vector3 (GameObject.FindGameObjectWithTag ("Player").transform.position.x,
			                                             transform.position.y,
			                                             GameObject.FindGameObjectWithTag ("Player").transform.position.z);
		}
	}
}
