using UnityEngine;
using System.Collections;

public class DestroyParticleSystem : MonoBehaviour {

	private float time = 0;
	public float thresholdTime = 0.1f;

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > thresholdTime) {
			//Debug.Log("Destroy Particle System");
			Destroy(gameObject);
				}
	}
}
