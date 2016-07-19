using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
    public float moveSpeed = 20f;
	public Bomb bomb;

	private bool hasBomb = true;
	[HideInInspector] public bool bombOut = false;
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

		//TODO: redo movement to support bomb physics (use GetAxis/normalize method learned Monday)

        // use W,A,S,D to move the player around
        if (Input.GetKey(KeyCode.W)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(0, -moveSpeed) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(-moveSpeed, 0) * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            GetComponent<Rigidbody2D>().velocity += new Vector2(moveSpeed, 0) * Time.deltaTime;
        }

		if (hasBomb && !bombOut && Input.GetKey(KeyCode.F)) {
			bombOut = true;
			Instantiate(bomb, transform.position, Quaternion.identity);
		}
    }
}
