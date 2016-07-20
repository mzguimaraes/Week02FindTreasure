using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float timer = 0.5f; //time this sprite exists

	private float countDown;

	// Use this for initialization
	void Start () {
		countDown = timer;
	}
	
	// Update is called once per frame
	void Update () {
		if(countDown <= 0) {
			Destroy(gameObject);
		}
		else {
			countDown -= Time.deltaTime;
		}
	}
}
