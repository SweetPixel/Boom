using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour{
	public Texture2D deathFlash;
	
	void Start(){
		iTween.CameraFadeAdd(deathFlash,100);	
	}
	
	void OnTriggerEnter(Collider other){
		iTween.CameraFadeTo(iTween.Hash("amount",.6,"time",.05));
		iTween.CameraFadeTo(iTween.Hash("amount",0,"time",1.6,"delay",.05,"easetype","linear"));
		other.rigidbody.Sleep();
		other.transform.position=new Vector3(0,8,0);
		other.rigidbody.velocity=Vector3.zero;
		other.rigidbody.WakeUp();
	}
}

