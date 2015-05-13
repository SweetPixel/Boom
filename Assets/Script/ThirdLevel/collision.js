#pragma strict
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


		LeftTreeOne.collider2D.enabled=false;
		LeftTreeTwo.collider2D.enabled=false;
		RightTreeOne.collider2D.enabled=false;
		RightTreeTwo.collider2D.enabled=false;
	}

}

function OnTriggerEnter2D (col : Collider2D) {
if(col.gameObject.name=="ObstacleTreeLeft")
{
LeftTreeOne.collider2D.enabled=true;
}

if(col.gameObject.name=="ObstacleTreeLeftSecond")
{
LeftTreeTwo.collider2D.enabled=true;
}

if(col.gameObject.name=="ObstacleTreeRight")
{
RightTreeOne.collider2D.enabled=true;
}

if(col.gameObject.name=="ObstacleTreeRightSecond")
{
RightTreeTwo.collider2D.enabled=true;
}

}
function OnTriggerExit2D (col : Collider2D) {
if(col.gameObject.name=="ObstacleTreeLeft")
{
	LeftTreeOne.collider2D.enabled=false;
}

if(col.gameObject.name=="ObstacleTreeLeftSecond")
{
	LeftTreeTwo.collider2D.enabled=false;
}

if(col.gameObject.name=="ObstacleTreeRight")
{
	RightTreeOne.collider2D.enabled=false;
}

if(col.gameObject.name=="ObstacleTreeRightSecond")
{
	RightTreeTwo.collider2D.enabled=false;
}

}