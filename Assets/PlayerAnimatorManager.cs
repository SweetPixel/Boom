using UnityEngine;
using System.Collections;

public class PlayerAnimatorManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float h = CnControls.CnInputManager.GetAxis("Horizontal");

		if(h < 0.1 && h > -0.1)
		{
			gameObject.GetComponent<Animator>().SetBool("isRunning",false);
		}
		else{
			gameObject.GetComponent<Animator>().SetBool("isRunning",true);
		}

	}
}
