using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelicopterMovementAndFire : MonoBehaviour {
	
	public float x1 = -4f;
	public float x2 = 4f;
	public float y1 = 3.692791f;
	public float y2 = 3.0f;

	public float speed = 5f;
	public GameObject Banana;
	public GameObject bananaspawn;
	public int frequency = 10;


	// Use this for initialization
	IEnumerator Start () {
		StartCoroutine(InitiateEnemy());
		while (true) {
			x1 = Random.Range(-3f, 3f);
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, transform.position.y), speed)); //3.692791f
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

	IEnumerator InitiateEnemy()
	{
		yield return new WaitForSeconds(0.2f);
		while(true)
		{
			for (int i=0;i<frequency;i++) 
			{
				//Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValue.x, spawnValue.x),Random.Range(1.2f, 4f),spawnValue.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (Banana, bananaspawn.transform.position, Quaternion.identity);
				yield return new WaitForSeconds(2f);
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		//Debug.Log (col.gameObject.name);
		
		if(col.gameObject.tag == "Bullet") {
			Destroy(col.gameObject);
			if(GameObject.Find("Foreground").GetComponent<Image>().fillAmount > 0)
			{
				GameObject.Find("Foreground").GetComponent<Image>().fillAmount -= 0.05f;
			}
			else if(GameObject.Find("Foreground").GetComponent<Image>().fillAmount == 0)
			{
				Destroy(gameObject);
			}
		}
		
	}

}
