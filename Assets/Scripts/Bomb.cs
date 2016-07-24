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

	private float countDown;

	// bomb dropped
	void Start () {
		countDown = fuseTime;
		GetComponent<AudioSource>().Play();
	}
	
	// Update is called once per frame
	void Update () {
		if (countDown <= 0) {
			GetComponent<AudioSource>().Stop();
			detonate();
		}
		else if (countDown % flashRate <= flashRate / 3.0f) { //flash
			gameObject.GetComponent<SpriteRenderer>().color = Color.red;
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
						Destroy(obj.gameObject);
					}
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
