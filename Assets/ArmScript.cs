using UnityEngine;
using System.Collections;

public class ArmScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		//Vector3 difference = Camera.main.ScreenToWorldPoint(CnControls.CnInputManager.GetAxis("Horizontal"));
		//difference.Normalize();

		//float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler(0f,0f, rotZ + 90);

		var rotatePosY = CnControls.CnInputManager.GetAxis("Horizontal");
		var rotatePosX = CnControls.CnInputManager.GetAxis("Vertical");

		float rotY = Mathf.Atan2(rotatePosX , rotatePosY) * Mathf.Rad2Deg;
		float rotX = rotatePosX * Mathf.Rad2Deg;

		this.transform.rotation = Quaternion.Euler(0f,0f, rotY);

	}
}
