using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        const float moveSpeed = 7.5f;
        // use W,A,S,D to move the player around
        if (Input.GetKey(KeyCode.W)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, moveSpeed);
        }
        if (Input.GetKey(KeyCode.S)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, -moveSpeed);
        }
        if (Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(-moveSpeed, 0);
        }
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(moveSpeed, 0);
        }
    }
}
