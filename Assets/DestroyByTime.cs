using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

	public float destroyTime = 3f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, destroyTime);
	}
}
