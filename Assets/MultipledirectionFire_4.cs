using UnityEngine;
using System.Collections;

public class MultipledirectionFire_4 : MonoBehaviour {

	public GameObject bomb;
	public float distance = 1f;
	public int num = 4;
	public Transform spawn;
	public float[] shootAngle;
	public float bulletSpeed = 1600f;
	public float delay = 2f;

	// Use this for initialization
	void Start () {
		StartCoroutine (Fire());
	}

	IEnumerator Fire()
	{
		while (true) {
			for (int i =0; i<num; i++){
				Quaternion target = Quaternion.AngleAxis ((distance * (i - (num / 2))), -transform.up);
				GameObject game = (GameObject)Instantiate (bomb, spawn.position, target * spawn.rotation);
				game.GetComponent<Rigidbody2D>().AddForce(Quaternion.Euler(0,0,shootAngle[i]) * Vector2.right * bulletSpeed);
			}
			yield return new WaitForSeconds (delay);
		}

	}

}
