using UnityEngine;
using System.Collections;

public class GroundCheckScrpit : MonoBehaviour {

	public bool grounded = true;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		gameObject.GetComponent<Animator>().SetBool("grounded", grounded);
	}
}
