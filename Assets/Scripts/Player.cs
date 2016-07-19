using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
    public float moveSpeed = 20f; //max speed
	//public float decelScalar = .5f; //scalar to decelerate by if no input
	public Bomb bomb;

	private bool hasBomb = true; //player has picked up bombs
	private Rigidbody2D rb2d;

	private bool bombOut = false; //bomb exists in world (forces 1 bomb limit)
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
        //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		//TODO: redo movement to support bomb physics (use GetAxis/normalize method learned Monday)

        // use W,A,S,D to move the player around
//        if (Input.GetKey(KeyCode.W)) {
//            GetComponent<Rigidbody2D>().velocity += new Vector2(0, moveSpeed) * Time.deltaTime;
//        }
//        if (Input.GetKey(KeyCode.S)) {
//            GetComponent<Rigidbody2D>().velocity += new Vector2(0, -moveSpeed) * Time.deltaTime;
//        }
//        if (Input.GetKey(KeyCode.A)) {
//            GetComponent<Rigidbody2D>().velocity += new Vector2(-moveSpeed, 0) * Time.deltaTime;
//        }
//        if (Input.GetKey(KeyCode.D)) {
//            GetComponent<Rigidbody2D>().velocity += new Vector2(moveSpeed, 0) * Time.deltaTime;
//        }

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");
		Vector2 newForce = new Vector2(horizontal,vertical);

		rb2d.velocity += newForce;
		if (rb2d.velocity.magnitude > moveSpeed) { //if going too fast, slow down
			rb2d.velocity.Normalize(); //normalize to unit speed
			rb2d.velocity *= moveSpeed; //scale to max speed
		}


		if (hasBomb && !bombOut && Input.GetKey(KeyCode.F)) {
			bombOut = true;
			Instantiate(bomb, transform.position, Quaternion.identity);
		}
    }
}
