using UnityEngine;
using System.Collections;

public class ExitUI : MonoBehaviour
{
	public string decidelabel1, closelabel1, cancellabel1;
	// Use this for initialization
	void Start ()
	{
		
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		#if UNITY_ANDROID
		if (Input.GetKeyDown(KeyCode.Escape)) {
			DialogManager.Instance.SetLabel(decidelabel1,cancellabel1,closelabel1);
			DialogManager.Instance.ShowSelectDialog("Exit","Are you sure you want to exit?",(bool result) =>{
				if(result)
					Application.Quit();
			});
		}
		#endif 
	}
}