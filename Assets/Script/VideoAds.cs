using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class VideoAds : MonoBehaviour {

	public GameObject videoGift;
	public Sprite[] score;

	void Start () {
		#if UNITY_ANDROID
		Advertisement.Initialize ("62275", true);
		#endif
		#if UNITY_IOS
		//Advertisement.Initialize ("62277", true);
		#endif
	}
	
	// Update is called once per frame
	/*public void loadAd () {
		StartCoroutine (ShowAdWhenReady());
	}
	IEnumerator ShowAdWhenReady()
	{
		while (!Advertisement.isReady ())
			yield return null;
		
		//Advertisement.Show ();
		Advertisement.Show(null, new ShowOptions {
			pause = false,
			// Handle the various result callback states.
			resultCallback = result => {
				switch (result)
				{
				case ShowResult.Finished:


					GameObject gtemp = (GameObject)Instantiate (videoGift, new Vector2 (videoGift.transform.position.x, videoGift.transform.position.y), Quaternion.identity);
					gtemp.SetActive(true);
					
					//images = GameObject.Find ("GiftPanel").GetComponentsInChildren<Image> ();
					
					Image hundred = GameObject.FindGameObjectWithTag ("gc-hundred").GetComponent<Image> ();
					Image ten = GameObject.FindGameObjectWithTag ("gc-ten").GetComponent<Image> ();
					Image unit = GameObject.FindGameObjectWithTag ("gc-unit").GetComponent<Image> ();
					
					int val = Random.Range(50, 100);
					Debug.Log(val);
					if (val < 100) {
						int t = val / 10;
						int u = val % 10;
						
						ten.sprite = score [t];
						unit.sprite = score [u];
						
					} else {
						
						int h = val / 100;
						int ht = val % 100;
						
						int t = ht / 10;
						int u = ht % 10;
						
						hundred.sprite = score[h];
						ten.sprite = score [t];
						unit.sprite = score [u];
					}

					GameObject gcc = GameObject.FindGameObjectWithTag("GameController");
					GameController gc = gcc.GetComponent<GameController>();
					gc.resetGiftTimer();
					int sc = PlayerPrefs.GetInt ("Score");
					sc = sc + 250;
					PlayerPrefs.SetInt ("Score", sc);
					
					GameObject giftButton = GameObject.FindGameObjectWithTag ("GreenStripeButton");
					giftButton.SetActive(false);
					//GameOverVisibility(false);
					
					GameOverScript go_script = GameObject.FindGameObjectWithTag("GameOver").GetComponent<GameOverScript>();
					go_script.calculateTotalCoins();

					Debug.Log("Finished");
					///Your code if it viewed
					break;
				case ShowResult.Skipped:
					Debug.Log("Skipped");
					///Your code if it skipped
					break;
				case ShowResult.Failed:
					Debug.Log("Failed");
					///Your code if it fails
					break;
				}
			}
		});
	}*/
	
	
	
}
