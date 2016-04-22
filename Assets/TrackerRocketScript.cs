using UnityEngine;
using System.Collections;

public class TrackerRocketScript : MonoBehaviour {

	public Transform target;
	public float speed = 10f;
	Vector3 screenPos;

	// Use this for initialization
	void Start () {
		//screenPos  = Camera.main.WorldToScreenPoint (target.position);
		if(GameObject.FindGameObjectWithTag("Player") != null)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null){
			transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.name == "Platform") {
			Destroy(gameObject);
		}
		
		if (col.gameObject.tag == "Player") {
			GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
			GameController gc = gcc.GetComponent<GameController>();
			gc.GameOver();
			Destroy(col.gameObject);
		}

		if (col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
			col.gameObject.SetActive(false);
			//Destroy(col.gameObject);
		}

	}

}
