using UnityEngine;
using System.Collections;

public class TrackingScript : MonoBehaviour {

	public Transform target;
	public Texture2D trackIcon;
	
	void Awake(){
		
	}
	
	void Start(){
		
	}
	
	void Update () {
		if(target != null)
		{
			Vector3 screenPos  = Camera.main.WorldToScreenPoint (target.position);
		}
	}
	
	void OnGUI(){
		if(target != null)
		{
			Vector3 screenPos  = Camera.main.WorldToScreenPoint (target.position);
			float reverse = Screen.height;
			var clampX = Mathf.Clamp(screenPos.x, 0, Screen.width);
			var clampY = Mathf.Clamp(reverse - screenPos.y, 0, Screen.height);
			
			//GUI.DrawTexture(new Rect(clampX, clampY, trackIcon.width / 2, trackIcon.height / 2), trackIcon);
		}
	}

}
