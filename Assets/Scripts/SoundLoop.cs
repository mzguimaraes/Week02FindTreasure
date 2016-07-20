using UnityEngine;
using System.Collections;

public class SoundLoop : MonoBehaviour {

	private AudioSource audioLoop;

	// Use this for initialization
	void Start () {
		audioLoop = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.L)) {
			if ( audioLoop.isPlaying ) {
				audioLoop.Stop();
			}
			else {
				audioLoop.loop = true;
				audioLoop.Play();
			}
		}
	}
}
