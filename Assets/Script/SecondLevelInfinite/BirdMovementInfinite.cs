using UnityEngine;
using System.Collections;

public class BirdMovementInfinite : MonoBehaviour {

	public Vector3 pointB;
	public float x1 = 3f;
	public float x2 = 5.2f;
	public float y1 = 3.692791f;
	public float y2 = 3.0f;

	bool isLeft = false;
	public bool isHit = false;

	Animator anim;

	public float birdSpeed = 1.5f;

	private float prevX1;
	private float prevX2;
	private bool faceleft=false;

	bool Samedirection = false;

	private GameObject hunter;
	private HunterMovement hm;

	private GameObject treeLeft;

	IEnumerator Start () {

		treeLeft = GameObject.Find ("ObstacleTreeLeft");

		hunter = GameObject.Find ("Object");
		hm = hunter.GetComponent<HunterMovement> ();

		anim = GetComponent<Animator> ();
		anim.SetBool ("isHit", false);

		Vector3 pointA = transform.position;
		//float time = 1.5f;

		x1 = 9.5f;

		yield return StartCoroutine(MoveObject(transform, new Vector2(4.1f, 2.958249f), new Vector2(x1, 2.958249f), birdSpeed));
		yield return StartCoroutine(MoveObject(transform, new Vector2(x1, 2.958249f), new Vector2(x2, y2), birdSpeed));

		while (!isHit) {
			//yield return StartCoroutine(MoveObject(transform, pointA, pointB, 3.0f));
			//yield return StartCoroutine(MoveObject(transform, pointB, pointA, 3.0f));

			x1 = Random.Range(5.3f, 9.5f);
			y1 = Random.Range(0.8f, 4f);

			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, y1), birdSpeed)); //3.692791f

			//if(!isHit)
			//{
				
			//	x2 = Random.Range(5.2f, 9.5f);
			//	y2 = Random.Range(1.5f, 4f);

			//	yield return StartCoroutine(MoveObject(transform, new Vector2(x1, y1), new Vector2(x2, y2), birdSpeed));
			//	prevX2 = x2;
			//}
		}
	}
	
	IEnumerator MoveObject (Transform thisTransform, Vector2 startPos, Vector2 endPos, float time) {
		float i=0.0f;
		float rate = 1.0f / time;
		if((startPos.x<endPos.x)&&(faceleft==true))
		{
			//Debug.Log ("moving right");
			Flip();
			faceleft=false;
		}
		else if((startPos.x>endPos.x)&&(faceleft==false))
		{
			Flip();
			faceleft=true;
			//Debug.Log ("moving left");
		}
		while (i < 1.0f) {
			i += Time.deltaTime * rate;
			if(isHit)
			{
				//yield return new WaitForSeconds(0.4f);
				hm.gotHit();
				break;
			}
		thisTransform.position = Vector2.Lerp(startPos, endPos, i);
		yield return null;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.y < -3.176471f) {
			Destroy(gameObject);
				}


	}

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
		//charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
		isLeft = !isLeft;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Debug.Log (col.gameObject.name);

		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}

		if(col.gameObject.name == "StartButton") {
			return;
		}

		if (col.gameObject.name == "Bullets(Clone)") {
						//Destroy(gameObject);
						BirdHit ();
						Destroy (col.gameObject);
				} 


	}

	private void BirdHit()
	{
		isHit = true;
		anim.SetBool ("isHit", true);
		anim.SetBool("isLeft", isLeft);
		//rigidbody.velocity = Vector2.up * -2;
		rigidbody2D.velocity = Vector2.up * -5;
	}


	public bool getIsHit()
	{
		return isHit;
	}

}
