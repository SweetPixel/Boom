using UnityEngine;
using System.Collections;

public class CarrotMovement : MonoBehaviour {

	public float speed = 3f;
	
	// Use this for initialization
	void Start () {
		if(transform.position.x == 7f)
		{
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(-8f, transform.position.y, 0f), speed));
			Destroy(gameObject, 5f);
		}
		else{
			this.transform.Rotate (0,180,0);
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(7f, transform.position.y, 0f), speed));
			Destroy(gameObject, 5f);
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
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Platform") {
			return;
		}
		
		if (col.gameObject.tag == "Player") {
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.GameOver();
			Destroy(col.gameObject);
		}
		
	}

}
