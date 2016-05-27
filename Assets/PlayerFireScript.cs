using UnityEngine;
using System.Collections;

public class PlayerFireScript : MonoBehaviour {

	public GameObject bullet;
	private GameObject bulletSpawn;
	public GameObject[] spawners;
	private float nextFire;
	public float fireRate;
	private float bulletAngle = -90f;
	public Vector2 bulletDirectionForce;
	public float bulletSpeed = 1600f;
	private float shootAngle = 22f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Fire") !=0 && 
		   Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			StartCoroutine(Fire());
		}
	}

	public void setBulletSpawn(GameObject spawn)
	{
		bulletSpawn = spawn;
	}

	public void setBulletAngle(float angle)
	{
		bulletAngle = angle;
	}

	public void setShootAngle(float angle)
	{
		shootAngle = angle;
	}
	public void setBulletDirectionForce(Vector2 force)
	{
		bulletDirectionForce = force;
	}

	public void InitiateFire()
	{
		StartCoroutine (Fire ());
	}

	IEnumerator Fire()
	{
		GameObject game = BulletObjectPooledScript.current.GetPooledObject();

		if (gameObject.GetComponent<JoystickMovement>().isRight) {
			//GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,-bulletAngle));

			game.transform.position = bulletSpawn.transform.position;
			game.transform.rotation = Quaternion.Euler(0,0,-bulletAngle);
			game.SetActive(true);
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,-shootAngle) * bulletDirectionForce * bulletSpeed);
			yield return new WaitForSeconds(0.25f);
			
		} else {
			//GameObject game = (GameObject)Instantiate(bullet, bulletSpawn.transform.position, Quaternion.Euler(0,0,bulletAngle));

			game.transform.position = bulletSpawn.transform.position;
			game.transform.rotation = Quaternion.Euler(0,0,bulletAngle);
			game.SetActive(true);
			game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,shootAngle) * bulletDirectionForce * bulletSpeed);
			yield return new WaitForSeconds(0.25f);
		}
		GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ammoDecrement();
	}

}
