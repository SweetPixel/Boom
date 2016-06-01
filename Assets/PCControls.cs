using UnityEngine;
using System.Collections;

public class PCControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.A)) {
			if(GameObject.Find("Player").GetComponent<JoystickMovement>().isRight)
			{
				GameObject.Find("Player").GetComponent<JoystickMovement>().isRight = false;
				transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);

				GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Player").GetComponent<JoystickMovement>().sprites[0];
				gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(GameObject.Find("Player").GetComponent<JoystickMovement>().spawners[0]);
				//bulletAngle = -90f;
				gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
				//shootAngle = 0f;
				gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
				gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.right);
				GameObject.Find("Player").GetComponent<JoystickMovement>().lookingUp = false;

			}
			GameObject.Find("Player").GetComponent<JoystickMovement>().h = -0.7f;
		}

		if (Input.GetKey (KeyCode.D)) {
			if(!GameObject.Find("Player").GetComponent<JoystickMovement>().isRight)
			{
				GameObject.Find("Player").GetComponent<JoystickMovement>().isRight = true;
				transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);

				GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Player").GetComponent<JoystickMovement>().sprites[0];
				gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(GameObject.Find("Player").GetComponent<JoystickMovement>().spawners[0]);
				//bulletAngle = -90f;
				gameObject.GetComponent<PlayerFireScript>().setBulletAngle(90f);
				//shootAngle = 0f;
				gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
				gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(-Vector2.right);
				GameObject.Find("Player").GetComponent<JoystickMovement>().lookingUp = false;
			}
			GameObject.Find("Player").GetComponent<JoystickMovement>().h = 0.7f;
		}

		if (Input.GetKey (KeyCode.W)) {
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Player").GetComponent<JoystickMovement>().sprites[2];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(GameObject.Find("Player").GetComponent<JoystickMovement>().spawners[2]);
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(0f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			GameObject.Find("Player").GetComponent<JoystickMovement>().lookingUp = true;
		}

		if (Input.GetKey (KeyCode.W) && Input.GetKey(KeyCode.A))
		{
			transform.localScale = new Vector3(-1,transform.localScale.y,transform.localScale.z);
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Player").GetComponent<JoystickMovement>().sprites[1];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(GameObject.Find("Player").GetComponent<JoystickMovement>().spawners[1]);
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(15f);
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(22f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			GameObject.Find("Player").GetComponent<JoystickMovement>().lookingUp = false;
		}

		if (Input.GetKey (KeyCode.W) && Input.GetKey(KeyCode.D))
		{
			transform.localScale = new Vector3(1,transform.localScale.y,transform.localScale.z);
			GameObject.Find("UpperBody").GetComponent<SpriteRenderer>().sprite = GameObject.Find("Player").GetComponent<JoystickMovement>().sprites[1];
			gameObject.GetComponent<PlayerFireScript>().setBulletSpawn(GameObject.Find("Player").GetComponent<JoystickMovement>().spawners[1]);
			gameObject.GetComponent<PlayerFireScript>().setBulletAngle(15f);
			gameObject.GetComponent<PlayerFireScript>().setShootAngle(22f);
			gameObject.GetComponent<PlayerFireScript>().setBulletDirectionForce(Vector2.up);
			GameObject.Find("Player").GetComponent<JoystickMovement>().lookingUp = false;
		}
	}
}
