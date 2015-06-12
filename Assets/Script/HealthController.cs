using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture  foregroundTexture;
	//public Texture frameTexture;
	
	public float healthWidth = 188f;
	public int healthHeight = 22;
	
	public int healthMarginLeft = 10;
	public int healthMarginTop = 10;
	
	public int frameWidth = 188;
	public int frameHeight = 13;
	
	public int frameMarginLeft = 10;
	public int frameMarginTop = 10;
	
	void OnGUI () {
		
		GUI.DrawTexture(new Rect(frameMarginLeft,frameMarginTop, frameMarginLeft + frameWidth, frameMarginTop + frameHeight), backgroundTexture, ScaleMode.ScaleToFit, true, 0 );
		
		GUI.DrawTexture(new Rect(healthMarginLeft,healthMarginTop,healthWidth + healthMarginLeft, healthHeight), foregroundTexture, ScaleMode.ScaleAndCrop, true, 0 );
		
		//GUI.DrawTexture( Rect(frameMarginLeft,frameMarginTop, frameMarginLeft + frameWidth,frameMarginTop + frameHeight), frameTexture, ScaleMode.ScaleToFit, true, 0 );
		
	}

}
