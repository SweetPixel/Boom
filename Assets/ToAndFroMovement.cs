using UnityEngine;
using System.Collections;

public class ToAndFroMovement : MonoBehaviour {

	float leftBorder;
	float rightBorder;
	private bool isFlipped = true;
	bool isRight = true;
	public float speed = 5f;
	private bool isHit = false;

	// Use this for initialization
	IEnumerator Start () {
		var dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		yield return StartCoroutine(MoveObject(transform, new Vector3(rightBorder-0.3f, transform.position.y, 0.02769041f), new Vector3(leftBorder+0.3f, transform.position.y, 0.02769041f), speed));
		while (true) {
			Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector3(leftBorder+0.3f, transform.position.y, 0.02769041f), new Vector3(rightBorder-0.3f, transform.position.y, 0.02769041f), speed));
			Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector3(rightBorder-0.3f, transform.position.y, 0.02769041f), new Vector3(leftBorder+0.3f, transform.position.y, 0.02769041f), speed));

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			if(isHit)
			{
				break;
			}
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	public void Flip()
	{
		this.transform.Rotate (0,180,0);
		isRight = !isRight;
		isFlipped = !isFlipped;
	}

	public void isDead()
	{
		isHit = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Platform") {
			return;
		}
		
		if (col.gameObject.tag == "Player") {
			if(col.gameObject.GetComponent<PirateMovement>().isgrounded == true)
			{
				Debug.Log("Player is grounded " + col.gameObject.GetComponent<PirateMovement>().isgrounded);
				GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
				GameController gc = gcc.GetComponent<GameController>();
				gc.GameOver();
				Destroy(GameObject.Find("Shadow"));
				Destroy(col.gameObject);
			}
			else {
				if(col.gameObject.transform.position.y > -1.0f)
				{
					Destroy (gameObject);
				}
				else{
					GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
					GameController gc = gcc.GetComponent<GameController>();
					gc.GameOver();
					Destroy(GameObject.Find("Shadow"));
					Destroy(col.gameObject);
				}
				//Destroy (gameObject.transform.parent.gameObject);
			}
		}
		
	}

}
