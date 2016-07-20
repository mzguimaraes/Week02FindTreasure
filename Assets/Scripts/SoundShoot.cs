using UnityEngine;
using System.Collections;

public class SoundShoot : MonoBehaviour {

	public AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			myAudioSource.PlayOneShot(myAudioSource.clip);
		}
	}
}
