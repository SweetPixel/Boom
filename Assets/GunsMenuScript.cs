using UnityEngine;
using System.Collections;

public class GunsMenuScript : MonoBehaviour {

	private Vector3 screenpoint;
	private Vector3 offset;
	float height;
	float width;

	// Use this for initialization
	void Start () {
		height = Camera.main.GetComponent<Camera>().orthographicSize;
		width = height * Screen.width / Screen.height;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		//score.GetComponent<TextOutline>().enabled = true;
		screenpoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
			new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5));
	}
	
	
	void OnMouseDrag()
	{
		if(Input.mousePosition.x > width || Input.mousePosition.x < (-width)){
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y,5);
			
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}

}
