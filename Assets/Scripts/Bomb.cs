using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Bomb : MonoBehaviour {

	public float fuseTime = 3f;
	public float blastRadius = 3f;
	public float blastForce = 500000f;
	public float flashRate = 0.33f; //rate at which the bomb flashes
	public Explosion explosion;
	public static bool isPoweredUp = false;
//	public Text UIText;

	private float countDown;

	// bomb dropped
	void Start () {
		countDown = fuseTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (countDown <= 0) {
			detonate();
		}
		else if (countDown % flashRate <= flashRate / 3.0f) { //flash
			gameObject.GetComponent<SpriteRenderer>().color = Color.red;
			//flashRate -= 0.1f * flashRate; //make flashes closer as bomb nears explosion TODO
		}
		else {
		gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
		countDown -= Time.deltaTime;
		
	}

	/*
	 * Detonates bomb, destroying it and all Destructibles in range while pushing the player away
	 */
	void detonate() {

		Debug.Log(isPoweredUp);

		//get array of colliders in range
		Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, blastRadius);

		//iterate through objects hit.  if destructible, then deactivate.  if player, push back
		foreach (Collider2D obj in targets) {
			if ( obj.gameObject.GetComponent<Destructible>() != null  ) { //destructible
				if (!obj.GetComponent<Destructible>().isStrongWall){
					Destroy(obj.gameObject);
				}
				else { //isStrongWall == true
					if (isPoweredUp) {
						Debug.Log("strong destroy");
						Destroy(obj.gameObject);
					}
//					else {
//						if (UIText != null)
//							UIText.text = "This door is too strong!  You need to find a master hacker to power up your bombs!";
//					}
				}
			}
			else if  (obj.gameObject.GetComponent<Player>() != null) { //player
				Vector2 blastDir = obj.gameObject.transform.position - transform.position; //vector from bomb to player

				if (blastDir.magnitude > 0){
					blastDir /= blastDir.magnitude; //normalize
				}
				blastDir *= blastForce; //give magnitude of blastForce

				obj.attachedRigidbody.AddForce(blastDir);
			}
		}
		GameObject.FindObjectOfType<Player>().BombOut = false;
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}

}
