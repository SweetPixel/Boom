using UnityEngine;
using System.Collections;

public class CanvasButtonSlider : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(this.GetComponent<RectTransform>().anchoredPosition.x < 320)
		{
			this.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.GetComponent<RectTransform>().anchoredPosition.x + 22f, this.GetComponent<RectTransform>().anchoredPosition.y);
		}
	}
}
