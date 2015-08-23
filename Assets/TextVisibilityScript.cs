using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextVisibilityScript : MonoBehaviour {

	public Text coin;
	public Canvas CoinCanvas;
	public Text bullet;
	public Canvas BulletCanvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator showCanvas()
	{
		coin.GetComponent<Text>().enabled = true;
		CoinCanvas.GetComponent<Canvas>().enabled = true;

		yield return new WaitForSeconds(0.5f);
		bullet.GetComponent<Text>().enabled = true;
		BulletCanvas.GetComponent<Canvas>().enabled = true;
	}

}
