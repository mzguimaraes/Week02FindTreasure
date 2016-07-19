using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	//TODO: add sound and animation

	public float fuseTime = 3f;
	public float blastRadius = 3f;
	public float blastForce = 500000f;

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
		else {
			countDown -= Time.deltaTime;
		}
	}

	/*
	 * Detonates bomb, destroying it and all Destructibles in range while pushing the player away
	 */
	void detonate() {

		//get array of colliders in range
		Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, blastRadius);

		//iterate through objects hit.  if destructible, then deactivate.  if player, push back
		foreach (Collider2D obj in targets) {
			//Debug.Log(obj.name);
			if ( obj.gameObject.GetComponent<Destructible>() != null  ) { //destructible
				//obj.gameObject.SetActive(false);
				Destroy(obj.gameObject);
			}
			else if  (obj.gameObject.GetComponent<Player>() != null) { //player
				Vector2 blastDir = obj.gameObject.transform.position - transform.position; //vector from bomb to player

				blastDir /= blastDir.magnitude; //normalize
				blastDir *= blastForce; //give magnitude of blastForce

				obj.attachedRigidbody.AddForce(blastDir);
			}
		}
		GameObject.FindObjectOfType<Player>().BombOut = false;
		Destroy(this.gameObject);
	}

}
