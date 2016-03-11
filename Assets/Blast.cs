using UnityEngine;
using System.Collections;

public class Blast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destroyObject ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator destroyObject()
	{
		yield return new WaitForSeconds(0.4f);
		Destroy (gameObject);
	}

}
