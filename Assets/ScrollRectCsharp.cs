﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectCsharp : MonoBehaviour {

	//Public Variables.
	public RectTransform panel;
	public Button[] btn;
	public RectTransform center;

	//Private Variables.
	private float[] distance;
	private bool dragging = false;
	private int btnDistance;
	private int minButtonNum;
	private bool isDragEnd = false;

	private GameObject scrollPanel;

	// Use this for initialization
	void Start () {
		int btnLength = btn.Length;
		distance = new float[btnLength];

		//Get distance between buttons
		btnDistance = (int)Mathf.Abs (btn [1].GetComponent<RectTransform> ().anchoredPosition.x - btn [0].GetComponent<RectTransform> ().anchoredPosition.x);
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i < btn.Length; i++) {
			distance[i] = Mathf.Abs(center.transform.position.x - btn [i].transform.position.x);
				}

		float minDistance = Mathf.Min (distance); 

		for (int a= 0; a < btn.Length; a++) 
		{
			if(minDistance == distance[a])
			{
				minButtonNum = a;
			}
		}

		if (!dragging) {
			LerpToButton(minButtonNum * -btnDistance);
				}
	}

	void LerpToButton(int position)
	{
		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;

		//Debug.Log("Anchored Position: " + panel.anchoredPosition);

		/*if (isDragEnd) 
		{
			if (minButtonNum == 0) {
				PlayerPrefs.SetInt ("gunIndex", 1);
			}
			else if (minButtonNum == 1) {
				PlayerPrefs.SetInt ("gunIndex", 2);
			}
			else if (minButtonNum == 2) {
				PlayerPrefs.SetInt ("gunIndex", 3);
			}
			else if (minButtonNum == 3) {
				PlayerPrefs.SetInt ("gunIndex", 4);
			}
		}*/
	}

	public void StartDrag()
	{
		dragging = true;
		isDragEnd = false;
	}

	public void EndDrag()
	{
		dragging = false;
		//isDragEnd = true;
	}

	public void reset(int num)
	{
		float newX = panel.anchoredPosition.x + 1950f;
		Debug.Log ("Panel X: " + newX);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);
		panel.anchoredPosition = newPosition;
		/*if (num > 4) 
		{
			num --;
		} 
		else if (num < 0) {
			num++;
		}
		//float newX = panel.anchoredPosition.x + (num * 650f);
		float newX = Mathf.Lerp (panel.anchoredPosition.x, panel.anchoredPosition.x - (num * 650f), Time.deltaTime * 10f);
		Debug.Log ("Panel X: " + newX);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);
		panel.anchoredPosition = newPosition;*/
	}

	public float panelAnchoredPosition()
	{
		return panel.anchoredPosition.x;
	}

}
