using UnityEngine;
using System.Collections;

public class HunterFlip : MonoBehaviour {

	public float timeLeft = 1f;
	private bool isFirst = true;
	private bool isRight = false;

	// Use this for initialization
	void Start () {
		Flip ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isFirst) {
			timeLeft = 1.1f;
			isFirst = false;
		}
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			timeLeft = 1.1f;
			Flip ();
				}
	}

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
		///	charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
		isRight = !isRight;
		GameObject.FindGameObjectWithTag ("Player").GetComponent<HunterMovement> ().setRight (isRight);
	}

}
