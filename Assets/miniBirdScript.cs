using UnityEngine;
using System.Collections;

public class miniBirdScript : MonoBehaviour {

	public float x1 = 5.5f;
	public float x2 = 10.3f;
	public float y1 = 3.692791f;
	public float y2 = 3.0f;
	public float birdSpeed = 2.0f;

	// Use this for initialization
	IEnumerator Start () {
		while (true) {
			y1 = Random.Range(5f, 7f);
			y2 = Random.Range(8f, 10f);
			yield return StartCoroutine(MoveObject(transform, new Vector2(x1, y1), new Vector2(x2, y2), birdSpeed)); //3.692791f
			
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
	
	}
}
