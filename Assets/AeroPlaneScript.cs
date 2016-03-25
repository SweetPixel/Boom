using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AeroPlaneScript : MonoBehaviour {

	public int Threshold = 3;
	private int count = 0;
	public GameObject Helicopter;

	private bool moveAway = false;
	private float[] pos = { 10.6f , 5.3f };

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(moveAway)
		{
			gameObject.GetComponent<ToAndFroMovement>().enabled = false;
			int index = Random.Range(0,2);
			moveAway = false;
			StartCoroutine(MoveObject(transform, transform.position, new Vector3(pos[index], transform.position.y, 0.02769041f), 1.2f));
		}
	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			if(moveAway)
			{
				break;
			}
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	public void setMoveAway()
	{
		moveAway = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Bullet") {
			count++;
			if(count == Threshold)
			{
				GameObject.Find("AirEnemyGenerator").GetComponent<AirEnemyGeneratorScript>().InitEnemy();
				if(GameObject.Find("Foreground").GetComponent<Image>().fillAmount < 1)
				{
					GameObject.Find("Foreground").GetComponent<Image>().fillAmount += 0.10f;
					if(GameObject.Find("Foreground").GetComponent<Image>().fillAmount == 1)
					{
						Instantiate(Helicopter, new Vector3(-6f, Helicopter.transform.position.y, Helicopter.transform.position.z), Quaternion.identity);
					}
				}
				Destroy(col.gameObject);
				Destroy(gameObject);
			}
			else{
				Destroy(col.gameObject);
			}
		}
		
	}

}
