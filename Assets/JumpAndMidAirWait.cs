using UnityEngine;
using System.Collections;

public class JumpAndMidAirWait : MonoBehaviour {

	/*public float speed = 1f; 
	public bool moveDown = false;

	void Start()
	{

	}
	
	public void FixedUpdate(){
		if (transform.position.y < 1.5f) {
			transform.Translate((Vector2.up * speed * Time.deltaTime) + (-Vector2.right * speed/4 * Time.deltaTime));
			//gameObject.GetComponent<Rigidbody2D>().AddForce(((Vector2.up * speed) + (-Vector2.right * speed/2)));
		}

		if (transform.position.y >= 1.5f) {
			StartCoroutine(Wait());
		}

		if (moveDown && transform.position.y >= -1.35f) {
			//transform.Translate((-Vector2.up * speed * Time.deltaTime) + (-Vector2.right * speed/2 * Time.deltaTime));
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
			gameObject.GetComponent<Rigidbody2D>().AddForce(-transform.forward * speed * Time.deltaTime);
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
			//moveDown = false;
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

	}*/

	/*public float amplitudeX = -1.0f;
	public float amplitudeY = 1.0f;
	public float omegaX = 1.0f;
	public float omegaY = 2.0f;
	float index;*/

	private bool isgrounded= true;
	public float timeOnGround = 2f;
	public float amplitudeX = 100f;
	public float amplitudeY = 300f;

	private bool jumping = false;
	public float jumpDuration = 0.5f;
	public float jumpDistance = 3;
	private float jumpStartVelocityY;


	IEnumerator Start()
	{
		//transform.localPosition = new Vector3 (10.0f, gameObject.transform.position.y, 0f);
		//StartCoroutine(hop ());
		//jumpStartVelocityY = -jumpDuration * Physics.gravity.y / 2;
		while (true) {
			yield return StartCoroutine(MoveObject(transform, new Vector3(transform.position.x, transform.position.y, 0.02769041f), new Vector3(transform.position.x-0.5f, transform.position.y+1f, 0.02769041f), 1f));
			//isRight = true
			yield return StartCoroutine(MoveObject(transform, new Vector3(transform.position.x, transform.position.y, 0.02769041f), new Vector3(transform.position.x-0.5f, transform.position.y-1f, 0.02769041f), 1f));
			//isRight = false;
		}

	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos, float time) {
		float i = 0.0f;
		float rate = time; //1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}

	public void FixedUpdate(){
		if(isgrounded)
		{
			isgrounded = false;
			/*Vector3 forwardAndLeft = (transform.forward - transform.right) * jumpDistance;
			StartCoroutine(Jump(forwardAndLeft));*/
			//StartCoroutine(jumpAndWait());
		}
	}

	IEnumerator jumpAndWait()
	{
		StartCoroutine(MoveObject(transform, new Vector3(transform.position.x, transform.position.y, 0.02769041f), new Vector3(transform.position.x-0.5f, transform.position.y+1f, 0.02769041f), 1f));
		yield return new WaitForSeconds(3f);
		StartCoroutine(MoveObject(transform, new Vector3(transform.position.x, transform.position.y, 0.02769041f), new Vector3(transform.position.x-0.5f, transform.position.y-1f, 0.02769041f), 1f));
	}

	private IEnumerator Jump(Vector3 direction)
	{
		jumping = true;
		Vector3 startPoint = transform.position;
		Vector3 targetPoint = startPoint + direction;
		float time = 0;
		float jumpProgress = 0;
		float velocityY = jumpStartVelocityY;
		float height = startPoint.y;
		
		while (jumping)
		{
			jumpProgress = time / jumpDuration;
			
			if (jumpProgress > 1)
			{
				jumping = false;
				jumpProgress = 1;
			}
			
			Vector3 currentPos = Vector3.Lerp(startPoint, targetPoint, jumpProgress);
			currentPos.y = height;
			transform.position = currentPos;
			
			//Wait until next frame.
			yield return null;
			
			height += velocityY * Time.deltaTime;
			velocityY += Time.deltaTime * Physics.gravity.y;
			time += Time.deltaTime;
		}
		
		transform.position = targetPoint;
		yield break;
	}
	
	IEnumerator hop()
	{
		while (true) {
			//transform.localPosition= transform.localPosition +  new Vector3(-2f,2f,0) * Time.time;
			if(isgrounded)
			{
				isgrounded = false;
				gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.up * amplitudeY) + (-Vector2.right * amplitudeX));
				yield return new WaitForSeconds(0.6f);
				gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
				yield return new WaitForSeconds(0.6f);
				gameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
				gameObject.GetComponent<Rigidbody2D>().AddForce((Vector2.up * amplitudeY) + (-Vector2.right * amplitudeX));
			}
		}
		
		
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		
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
