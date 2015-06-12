#pragma strict

var amplitude:float;
var frequency:float;

function Start () {
//del();
}

function Update () {
transform.position += amplitude*(Mathf.Sin(2*Mathf.PI*frequency*Time.time) - Mathf.Sin(2*Mathf.PI*frequency*(Time.time - Time.deltaTime)))*transform.up;
//GetComponent.<Rigidbody>().AddForce(-transform.right*5);
}

/*function del()
	{
		yield WaitForSeconds(2f);
		Destroy(this.gameObject);
	}*/