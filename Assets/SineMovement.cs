using UnityEngine;
using System.Collections;

public class SineMovement : MonoBehaviour {

	/*public float CurveSpeed = 5;
	public float MoveSpeed = 1;
	
	float fTime = 0;
	Vector3 vLastPos = Vector3.zero;
	
	// Use this for initialization
	void Start () 
	{
		vLastPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		vLastPos = transform.position;
		
		fTime += Time.deltaTime * CurveSpeed;
		
		Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);
		Vector3 vLin = new Vector3(MoveSpeed, MoveSpeed, 0);
		
		transform.position += (vSin + vLin) * Time.deltaTime;
		
		Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
	}*/

	public float amplitudeX = -1.0f;
	public float amplitudeY = 1.0f;
	public float omegaX = 1.0f;
	public float omegaY = 2.0f;
	float index;

	void Start()
	{
		transform.localPosition = new Vector3 (10.0f, gameObject.transform.position.y-1.45f, 0f);
	}

	public void Update(){
		index += Time.deltaTime;
		float x = transform.position.x + amplitudeX * index * omegaX;
		float y = amplitudeY*Mathf.Sin (omegaY*index);
		transform.localPosition= new Vector3(x,y-1.0f,0);
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Bullet") {
			Destroy(gameObject);
		}

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
