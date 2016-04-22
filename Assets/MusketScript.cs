using UnityEngine;
using System.Collections;

public class MusketScript : MonoBehaviour {

	public float thresholdTime = 1f;

	void OnEnable()
	{
		Invoke("Destroy", thresholdTime);
	}

	void Destroy()
	{
		gameObject.SetActive(false);
	}

	void OnDisable()
	{
		CancelInvoke();
	}
}
