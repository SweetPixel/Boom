


#pragma strict
private var startPos :Vector2; 
var minSwipeDistY : float;
var minSwipeDistX : float;
//var Swipe : GUIText;
var jump : int = 0 ;
var force : float;
var angle: float;
var dir :Vector3;
var cube :GameObject;
var touch : Touch;


var prevTransform: Transform;
var isLeft: boolean = false;
var isRight: boolean = false;

	//var timeElapsed : float ;
//	var spawnCycle : float;
var canjump : boolean;
	
	function Start () {
		force = 15f;
		angle = 45f;
	//timeElapsed= 0;
	//spawnCycle=.4f;
	canjump=true;
	}
	
	
	function Update () 
	{
	//timeElapsed += Time.deltaTime;
//	if(timeElapsed > spawnCycle)
//	{
		if(Input.GetKeyDown(KeyCode.Space)&&canjump)
		
		Jump();
		//timeElapsed-= spawnCycle;
		
		if (Input.touchCount > 0) 
		{
			if (Input.touchCount == 1)
				touch = Input.touches[0];
			else if (Input.touchCount > 1)
				touch = Input.touches[1];
			switch (touch.phase) 

				{

				case TouchPhase.Began:

				startPos = touch.position;

				break;


				case TouchPhase.Ended:
				var swipeDistVertical : float;
				swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

					if (swipeDistVertical > minSwipeDistY) 
					{
						var swipeValue : float;
						swipeValue = Mathf.Sign(touch.position.y - startPos.y);

						/*if (swipeValue > 0)//up
						{	
							Jump ();

							Swipe.text = "Up Swipe";
						}
						else if (swipeValue < 0)//down
						{	
							Shrink ();
							Swipe.text = "Down Swipe";
						} */
					}
				var swipeDistHorizontal : float;

					swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;

					if (swipeDistHorizontal > minSwipeDistX) 
					{
						swipeValue = Mathf.Sign(touch.position.x - startPos.x);

						if (swipeValue > 0)//right
						{
							
							//MoveCameraRight ();
							MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - swipeDistHorizontal, transform.position.y), 3f);

							//Swipe.text = "Right Swipe";
							
							
						}
						else if (swipeValue < 0)//left
						{	
							
							//MoveCameraLeft ();
							MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + swipeDistHorizontal, transform.position.y), 3f);

							//Swipe.text = "Left Swipe";
							
							
						}
					}
					break;
				}
			}	
//}
	}
	function MoveCameraLeft(){
		/*for(var i : float = 3.5f; i > 0.0f; i = i-0.001f) 
		{
		gameObject.transform.position.x = gameObject.transform.position.x - 0.001f;
		//transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 3.5f, transform.position.y), Time.deltaTime * 4f);
		}*/
		//MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x - 3.5f, transform.position.y), 3f);
		//transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x - 3.5f, transform.position.y), Time.time * 4f);
	}
	
	function  MoveCameraRight(){
		for(var i : float = 0f; i < 3.5f; i = i+0.001f) 
		{
		gameObject.transform.position.x = gameObject.transform.position.x + 0.001f;
		//transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + 3.5f, transform.position.y), Time.deltaTime * 4f);
		}
		//MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(transform.position.x + 3.5f, transform.position.y), 3f);
		//transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x + 3.5f, transform.position.y), Time.time * 4f);
	}

	function MoveObject (thisTransform : Transform,  startPos : Vector2, endPos : Vector2, time : float) 
	{
		var  i: float = 0.0f;
		var rate: float = 1.0f / time;
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
		thisTransform.position = Vector2.Lerp(startPos, endPos, i);
		}

	}

	function Jump(){
	canjump=false;
		dir = Quaternion.AngleAxis(angle,Vector3.forward) * Vector3.one;
		cube.GetComponent.<Rigidbody2D>().AddForce(dir*force);
		cube.GetComponent.<Rigidbody2D>().gravityScale = 0; 
		yield WaitForSeconds(.3);
		cube.GetComponent.<Rigidbody2D>().gravityScale =2;
		canjump=true;
	}
	function Shrink(){
		}
		