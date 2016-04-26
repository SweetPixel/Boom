using UnityEngine;
using System.Collections;

public class HopMovement : MonoBehaviour {

	/*public float amplitudeX = -1.0f;
	public float amplitudeY = 1.0f;
	public float omegaX = 1.0f;
	public float omegaY = 2.0f;
	float index;*/
	private bool isgrounded= true;
	public float timeOnGround = 2f;
	//public float amplitudeX = 100f;
	//public float amplitudeY = 300f;

	public GameObject carrot;
	public GameObject spawner;
	private float x = -2f;
	public float xAxis = 2f;
	public float y=12f;
	private bool isRight = false;
	public float fireSpeed = 350f;
	public float threshold = 2f;
	private int counter = 0;

	void Start()
	{
		//transform.localPosition = new Vector3 (10.0f, gameObject.transform.position.y, 0f);
		if(transform.position.x <= 7f && transform.position.x >= 3f)
		{
			x = -xAxis;
			StartCoroutine(hop ());
		}
		else{
			this.transform.Rotate (0,180,0);
			x = xAxis;
			StartCoroutine(hop ());
		}
		Destroy (gameObject, 20f);
	}
	
	public void Update(){
		//index += Time.smoothDeltaTime;
		//float x = amplitudeX*Mathf.Sin(index * omegaX);
		//float y = amplitudeY*Mathf.Sin (omegaY*index);
		//transform.localPosition= transform.localPosition +  new Vector3(-0.1f,0.1f,0);
	}

	public void setRight()
	{
		isRight = true;
	}

	IEnumerator hop()
	{
		while (true) {
			//transform.localPosition= transform.localPosition +  new Vector3(-2f,2f,0) * Time.time;
			if(isgrounded)
			{
				isgrounded = false;
				//gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.up * amplitudeY) + (-Vector2.right * amplitudeX));
				gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(x, y);
				//yield return new WaitForSeconds(2f);
			}
			else if(!isgrounded){
				yield return new WaitForSeconds(timeOnGround/2);
				GameObject fire = (GameObject)Instantiate (carrot, spawner.transform.position, Quaternion.identity);
				if(isRight)
				{
					fire.transform.Rotate (0,180,0);
					fire.GetComponent<Rigidbody2D>().AddForce(Vector2.right * fireSpeed);
				}else{
					fire.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * fireSpeed);
				}
				yield return new WaitForSeconds(timeOnGround/2);
			}
		}


	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Bullet") {
			counter++;
			if(counter==threshold)
			{
				Destroy(gameObject);
				//Destroy(col.gameObject);
				col.gameObject.SetActive(false);
			}
		}

		if (col.gameObject.tag == "Platform") {
			isgrounded = true;
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
				//Destroy(col.gameObject);
				col.gameObject.SetActive(false);
			}
			/*else {
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
			}*/
		}
		
	}
}
