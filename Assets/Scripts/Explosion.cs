using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	public float timer = 0.5f; //time this sprite exists

	private float countDown;
	private SpriteRenderer sprite;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		countDown = timer;
		sprite = GetComponent<SpriteRenderer>();
		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(countDown <= 0) {
			//Destroy(gameObject);
			sprite.enabled = false;
			if (source.isPlaying == false) { //sound clip is done
				Destroy(gameObject);
			}
		}
		else {
			countDown -= Time.deltaTime;
		}
	}
}
