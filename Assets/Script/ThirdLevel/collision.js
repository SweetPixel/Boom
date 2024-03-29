﻿#pragma strict
private var LeftTreeOne : GameObject;
private var LeftTreeTwo : GameObject;
private var RightTreeOne : GameObject;
private var RightTreeTwo : GameObject;
function Start () {

	if(Application.loadedLevel == 2)
	{
		LeftTreeOne=GameObject.Find("ObstacleTreeLeft");
		LeftTreeTwo=GameObject.Find("ObstacleTreeLeftSecond");
		RightTreeOne=GameObject.Find("ObstacleTreeRight");
		RightTreeTwo=GameObject.Find("ObstacleTreeRightSecond");


		LeftTreeOne.GetComponent.<Collider2D>().enabled=false;
		LeftTreeTwo.GetComponent.<Collider2D>().enabled=false;
		RightTreeOne.GetComponent.<Collider2D>().enabled=false;
		RightTreeTwo.GetComponent.<Collider2D>().enabled=false;
	}

}

function OnTriggerEnter2D (col : Collider2D) {
if(col.gameObject.name=="ObstacleTreeLeft")
{
LeftTreeOne.GetComponent.<Collider2D>().enabled=true;
}

if(col.gameObject.name=="ObstacleTreeLeftSecond")
{
LeftTreeTwo.GetComponent.<Collider2D>().enabled=true;
}

if(col.gameObject.name=="ObstacleTreeRight")
{
RightTreeOne.GetComponent.<Collider2D>().enabled=true;
}

if(col.gameObject.name=="ObstacleTreeRightSecond")
{
RightTreeTwo.GetComponent.<Collider2D>().enabled=true;
}

}
function OnTriggerExit2D (col : Collider2D) {
if(col.gameObject.name=="ObstacleTreeLeft")
{
	LeftTreeOne.GetComponent.<Collider2D>().enabled=false;
}

if(col.gameObject.name=="ObstacleTreeLeftSecond")
{
	LeftTreeTwo.GetComponent.<Collider2D>().enabled=false;
}

if(col.gameObject.name=="ObstacleTreeRight")
{
	RightTreeOne.GetComponent.<Collider2D>().enabled=false;
}

if(col.gameObject.name=="ObstacleTreeRightSecond")
{
	RightTreeTwo.GetComponent.<Collider2D>().enabled=false;
}

}