using UnityEngine;
using System.Collections;

public class ComboScript : MonoBehaviour {

	public Sprite[] comboNumbers;
	public GameObject comboTen;
	public GameObject comboUnit;
	private SpriteRenderer comboTenRenderer;
	private SpriteRenderer comboUnitRenderer;
	GameObject gameController;
	GameController gc;

	// Use this for initialization
	void Start () {

		comboTenRenderer = comboTen.GetComponent<SpriteRenderer> ();
		comboUnitRenderer = comboUnit.GetComponent<SpriteRenderer> ();

		gameController = GameObject.FindGameObjectWithTag ("GameController");
		gc = gameController.GetComponent<GameController> ();
		int comboValue = gc.getComboValue ();

		Debug.Log ("ComboValue from GameController " + comboValue);

		if (comboValue >= 2 && comboValue < 10) 
		{
			comboTenRenderer.sprite = comboNumbers[comboValue];
			comboUnit.SetActive(false);
		}
		else if (comboValue >= 10 && comboValue < 100) 
		{
			comboUnit.SetActive(true);

			int ten = comboValue / 10;
			int unit = comboValue % 10;

			comboTenRenderer.sprite = comboNumbers[ten];
			comboUnitRenderer.sprite = comboNumbers[unit];
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
