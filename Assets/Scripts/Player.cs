using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
    public float moveSpeed = 20f; //max speed
	public float moveScalar = 5f; //acceleration scalar
	//public float decelScalar = .5f; //scalar to decelerate by if no input
	public Bomb bomb;

	private Rigidbody2D rb2d;
	private Vector2 moveForce;

	private bool hasBomb = false; //player has picked up bombs
	public bool HasBomb {
		set {
			hasBomb = value;
		}
	}

	//bomb exists in world (forces 1 bomb limit)
	private bool bombOut = false; 
	public bool BombOut { //property (provides public access to bombOut)
		set {
			bombOut = value;
		}
	}

	void Start() {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		//get input vector
		float horizontal = Input.GetAxis("Horizontal") * moveScalar * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * moveScalar * Time.deltaTime;
		moveForce = new Vector2(horizontal,vertical);

		//activate bomb
		if (hasBomb && !bombOut && Input.GetKey(KeyCode.F)) {
			bombOut = true;
			Instantiate(bomb, transform.position, Quaternion.identity);
		}
    }

	void FixedUpdate() {
		//apply movement
		rb2d.velocity += moveForce;
		if (rb2d.velocity.magnitude > moveSpeed) { //if going too fast, slow down
			rb2d.velocity.Normalize(); //normalize to unit speed
			rb2d.velocity *= moveSpeed; //scale to max speed
		}

	}
}
