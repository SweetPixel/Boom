using UnityEngine;
using System.Collections;

public class FlockMovement : MonoBehaviour {

	public bool isHit = false;
	public float birdSpeed = 1.5f;
	private float prevX1;
	private float prevX2;
	private bool faceleft=false;
	bool Samedirection = false;
	float birdLife = 0;
	private int randX;

	IEnumerator Start () {
		birdLife = 0;

		randX = Random.Range (0, 2);

		if (randX == 1) {
			//Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector2(13f,0f), new Vector2(3f, 2.85f), birdSpeed));
			Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector2(3f,0f), new Vector2(14f, 2.85f), birdSpeed));
		} else {
			Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector2(3f,0f), new Vector2(12f, 2.85f), birdSpeed));
			Flip ();
			yield return StartCoroutine(MoveObject(transform, new Vector2(13f,0f), new Vector2(1f, 3f), birdSpeed));
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector2 startPos, Vector2 endPos, float time) {
		float i=0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector2.Lerp(startPos, endPos, i);
			yield return null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x == 14f || transform.position.x == 1f) {
			GameObject.FindGameObjectWithTag("PlayHand").GetComponent<StartGame>().initBirdOutside(3);
			Destroy(gameObject);
		}
	}
	
	void Flip()
	{
		gameObject.transform.Rotate (0,180,0);
	}

}
