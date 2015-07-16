using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	
	private bool faceleft=false;
	bool isLeft = false;
	bool Samedirection = false;
	bool isHit = false;
	public float birdSpeed = 1.5f;

	public float x1 = 6.4f;
	public float x2 = 6.4f;
	public float y1 = 3.692791f;
	public float y2 = 2.0f;

	private GameObject hunter;
	private HunterMovement hm;
	public GameObject explosion;
	public GameObject gameOver;

	Animator anim;
	float count = 0;
	// Use this for initialization
	IEnumerator Start () {
		//rigidbody.velocity = transform.right * 2;

		hunter = GameObject.FindGameObjectWithTag("Player");
		hm = hunter.GetComponent<HunterMovement> ();

		anim = GetComponent<Animator> ();
		anim.SetBool ("isHit", false);

		Vector3 pointA = transform.position;
		//float time = 1.5f;

		x1 = 9.75f;
		x2 = 6.4f;
		y2 = Random.Range(-0.6f, 0.3f);
		
		yield return StartCoroutine(MoveObject(transform, new Vector2(5.1f, 0.3f), new Vector2(x1, 0.3f), birdSpeed));
		yield return StartCoroutine(MoveObject(transform, new Vector2(x1, 0.3f), new Vector2(x2, y2), birdSpeed));
		
		while (!isHit) {

			x1 = Random.Range(6.4f, 9.75f);
			y1 = Random.Range(-0.6f, 0.3f);
			
			yield return StartCoroutine(MoveObject(transform, new Vector2(transform.position.x, transform.position.y), new Vector2(x1, y1), birdSpeed)); //3.692791f
		}
	}
	
	// Update is called once per frame
	void Update () {
		count += Time.deltaTime;

	/*	if (count > 1f && isHit) {
			GetComponent<Rigidbody2D>().velocity = Vector2.up * -5;
				} */
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
						if (isHit) {
								break;
						}
						thisTransform.position = Vector2.Lerp (startPos, endPos, i);
						yield return null;
				}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Bird2D(Clone)") {
			return;
		}

		if(col.gameObject.name == "Bird2D-Enemy(Clone)") {
			return;
		}

		if(col.gameObject.name == "StartButton") {
			return;
		}
		
		if (col.gameObject.tag == "Bullet") {
			Destroy(col.gameObject);
			//Destroy (gameObject);
			isHit = true;
			BirdHit();
			//hm.lost();
			//Application.LoadLevel ("SecondLevelInfinite");

		} 
		//else {
			//Time.timeScale = 0;

		//}
	}

	private void BirdHit()
	{
		isHit = true;
		//anim.SetBool ("isHit", true);

		GameObject hunter = GameObject.FindGameObjectWithTag ("Player");
		HunterMovement hm = hunter.GetComponent<HunterMovement> ();

		hm.lost ();

		Instantiate(explosion, new Vector3(explosion.transform.position.x, explosion.transform.position.y, explosion.transform.position.z), Quaternion.identity);

		GameObject go = (GameObject)Instantiate (gameOver, new Vector2 (8.029126f, 1.784778f), Quaternion.identity);

		//rigidbody.velocity = Vector2.up * -2;
		//count = 0;
	}

	void Flip()
	{
		//Vector2 charScale = transform.localScale;
		//charScale.x *= -1;
		//transform.localScale = charScale;
		this.transform.Rotate (0,180,0);
		isLeft = !isLeft;
	}

}
