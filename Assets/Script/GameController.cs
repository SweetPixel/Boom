using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private GameObject guiHealth;
	private HealthController healthBarScript;

	void Start()
	{
		guiHealth = GameObject.Find("Health");
		healthBarScript = guiHealth.GetComponent<HealthController>();
		
		healthBarScript.healthWidth = 188;
	}

	void Update()
	{

	}

}
