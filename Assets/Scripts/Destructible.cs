using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	//TODO: change behavior so that Destructibles move away from bomb on impact

	private Rigidbody2D rb2d;

	public bool IsKinematic {
		set {
			rb2d.isKinematic = value;
		}
		get {
			return rb2d.isKinematic;
		}
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
