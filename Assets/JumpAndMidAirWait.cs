using UnityEngine;
using System.Collections;

public class JumpAndMidAirWait : MonoBehaviour {

	public float speed = 1f; 
	public bool moveDown = false;

	void Start()
	{

	}
	
	public void Update(){
		if (transform.position.y < 2) {
			transform.Translate((Vector2.up * speed * Time.deltaTime) + (-Vector2.right * speed/2 * Time.deltaTime));
		}

		if (transform.position.y >= 2f) {
			StartCoroutine(Wait());
		}

		if (moveDown && transform.position.y >= -1.35f) {
			//transform.Translate((-Vector2.up * speed * Time.deltaTime) + (-Vector2.right * speed/2 * Time.deltaTime));
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
			gameObject.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * speed/2 * Time.deltaTime);
			//transform.position = new Vector3(transform.position.x - speed/2, transform.position.y - speed, transform.position.z);
		}

		if (transform.position.y <= -1.30f) {
			moveDown = false;
		}

	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (0.5f);
		moveDown = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.tag == "Platform") {
			moveDown = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
			return;
		}
		
		if (col.gameObject.tag == "Obstacle") {
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
				if(col.gameObject.transform.position.y > gameObject.transform.position.y && col.gameObject.transform.position.y > -1)
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
