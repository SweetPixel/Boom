using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class VideoAds : MonoBehaviour {
	
	void Start () {
		#if UNITY_ANDROID
		Advertisement.Initialize ("62275", true);
		#endif
		#if UNITY_IOS
		Advertisement.Initialize ("62277", true);
		#endif
	}
	
	// Update is called once per frame
	public void loadAd () {
		StartCoroutine (ShowAdWhenReady());
	}
	IEnumerator ShowAdWhenReady()
	{
		while (!Advertisement.isReady ())
			yield return null;
		
		Advertisement.Show ();
	}
}
