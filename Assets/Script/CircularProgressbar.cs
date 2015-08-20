using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CircularProgressbar : MonoBehaviour {

	public Image circularSilder;            //Drag the circular image i.e Slider in our case
	public float time; //In how much time the progress bar will fill/empty
	bool i=true;
	public Sprite[] numbers;
	private float timer;
	private bool start=true;
	public Image counter;
	int count = 8;
	public Text num;

	void Start() {
		circularSilder.fillAmount=1f;   // Initally progress bar is empty
		timer = 0.5f;
	}
	void Update () {

		if (start) {
			circularSilder.fillAmount -= ((Time.deltaTime / time) + 0.11f);  
			if(count > -1)
			{
				//counter.sprite = numbers[count];
				num.text = count.ToString();
			}
			count--;
			start=false;
				}

		if (!start) {
			timer -= Time.deltaTime;
			if(timer < 0)
			{
				timer = 1f;
				start = true;
			}
		}

		if ((circularSilder.fillAmount == 0)&&(i)) 
		{
			i=false;
			//gameover();
			Debug.Log("Gameover");
		}
	}

}