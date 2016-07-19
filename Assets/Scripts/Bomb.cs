using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

	public float fuseTime = 3f;
	public float blastRadius = 3f;
	public float blastForce = 500f;

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

	void detonate() {

		//get array of colliders in range
		Vector2 pos2d = new Vector2(transform.position.x, transform.position.y);
		Collider2D[] targets = Physics2D.OverlapCircleAll(pos2d, blastRadius);

		//iterate through objects hit.  if destructible, then deactivate.  if player, push back
		foreach (Collider2D obj in targets) {
			if ( obj.gameObject.GetComponent<Destructible>() != null  ) {
				obj.gameObject.SetActive(false);
			}
			else if  (obj.gameObject.GetComponent<Player>() != null) {
				Vector2 blastDir = obj.gameObject.transform.position - 
					transform.position; //vector from bomb to player

				blastDir = blastDir / blastDir.magnitude; //normalize
				blastDir = blastDir * blastForce; //give magnitude of blastForce

				obj.attachedRigidbody.AddForce(blastDir);
			}
		}
		GameObject.FindObjectOfType<Player>().bombOut = false;
		Destroy(this.gameObject);
	}

}
