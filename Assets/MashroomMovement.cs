using UnityEngine;
using System.Collections;

public class MashroomMovement : MonoBehaviour {

	public float speed = 10f;
	RaycastHit2D hitup;
	RaycastHit2D hitForward;

	// Use this for initialization
	void Start () {
		if(transform.position.x == 7f)
		{
			StartCoroutine(MoveObject(transform, new Vector3(7f, transform.position.y, 0f), new Vector3(-8f, transform.position.y, 0f), speed));
			Destroy (gameObject, 7f);
		}
		else{
			StartCoroutine(MoveObject(transform, new Vector3(-8f, transform.position.y, 0f), new Vector3(7f, transform.position.y, 0f), speed));
			Destroy (gameObject, 7f);
		}

	}
	
	// Update is called once per frame
	void Update () {


		/*if (gameObject.transform.position.x < -7f) {
			Destroy(gameObject);
		}*/
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	/*void OnCollisionEnter2D(Collision2D col)
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
		
	}*/

}
