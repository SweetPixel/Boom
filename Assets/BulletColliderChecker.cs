using UnityEngine;
using System.Collections;

public class BulletColliderChecker : MonoBehaviour {

	private int counter = 0;

	public GameObject missOne;
	public GameObject missTwo;
	public GameObject missThree;

	private Animator rendererOne;
	private Animator rendererTwo;
	private Animator rendererThree;

	HunterMovement hm;
	public GameObject hunter;

	// Use this for initialization
	void Start () {
		/*counter  = 0;
		missOne.transform.renderer.enabled = true;
		missTwo.transform.renderer.enabled = true;
		missThree.transform.renderer.enabled = true;

		rendererOne = missOne.GetComponent<Animator> ();
		rendererTwo = missTwo.GetComponent<Animator> ();
		rendererThree = missThree.GetComponent<Animator> (); */

		hm = hunter.GetComponent<HunterMovement> ();

	}
	
	// Update is called once per frame
	void Update () {
		/* if (counter == 1) {
			//missOne.renderer.enabled = false;
			rendererOne.SetBool("isMissed", true);
				}
		else if (counter == 2) {
			//missTwo.renderer.enabled = false;
			rendererTwo.SetBool("isMissed", true);
		}
		else if (counter == 3) {
			//missThree.renderer.enabled = false;
			rendererThree.SetBool("isMissed", true);
			hm.lost();
		} */
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Bullet") {
			//counter++;
			//hm.setCounter();
			hm.decrementBirdCount();
			Destroy(col.gameObject);
				}
	}


}
