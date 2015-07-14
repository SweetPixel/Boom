#pragma strict
var count  : int;
var touch : Touch;
private var startPos :Vector2; 
var minSwipeDistY : float;
var minSwipeDistX : float;
function Start()
	{
		count =0;
	}

function Update()
	{
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

						if (swipeValue < 0)//left
						{
							if (count ==0)
							{
								GetComponent.<Animation>().Play("move left one");
								count++;
							}
							else if (count ==1)
							{
								GetComponent.<Animation>().Play("MOVE left 2");
								count++;
							}
							else if (count ==2)
							{
								GetComponent.<Animation>().Play("move left 3");
								count++;
							} 
						
						}
						else if (swipeValue > 0)//right
						{	
							if (count ==1)
							{
								GetComponent.<Animation>().Play("move right 3");
								count--;
							}
							else if (count ==2)
							{
								GetComponent.<Animation>().Play("move right 2");
								count--;
							} 
							else if (count ==3)
							{
								GetComponent.<Animation>().Play("move right 1");
								count--;
							}
						}
					}
					break;
				}
			}	
	}