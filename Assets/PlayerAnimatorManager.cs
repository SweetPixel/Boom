using UnityEngine;
using System.Collections;

public class PlayerAnimatorManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float h = Mathf.Abs(CnControls.CnInputManager.GetAxis("Horizontal"));
		//float v = Mathf.Abs(CnControls.CnInputManager.GetAxis("Vertical"));

		h = Mathf.Abs(h);

		if(!GameObject.FindGameObjectWithTag("Player").GetComponent<JoystickMovement>().lookingUp && (h != 0f && h>0.08f) )
		{
			gameObject.GetComponent<Animator>().SetBool("isRunning",true);
		}
		else{
			gameObject.GetComponent<Animator>().SetBool("isRunning",false);
		}

	}
}
