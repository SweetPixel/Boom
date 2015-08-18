using UnityEngine;
using System.Collections;

public class CanvasCenterScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("CanvasCenterScript");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log (col.gameObject.name);
		if (col.gameObject.name == "RifleCenter") 
		{
			Debug.Log("RifleCenter");
		}
		else if (col.gameObject.name == "SmgCenter") 
		{
			Debug.Log("SmgCenter");
		}
		else if (col.gameObject.name == "ShotgunCenter") 
		{
			Debug.Log("ShotgunCenter");
		}
		else if (col.gameObject.name == "SniperCenter") 
		{
			Debug.Log("SniperCenter");
		}
	}

}
