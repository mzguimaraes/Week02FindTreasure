using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class LockedDoor : MonoBehaviour {

	public Transform player;
	public float activeDistance = 4f;
	public AudioSource audioSource; //located at door's location.
	public Text text;

	private string defaultText;

	void Start() {
		defaultText = text.GetComponent<TextController>().defaultText;
	}

	// Update is called once per frame
	void Update () {
		if ((transform.position - player.position).magnitude < activeDistance
			&& player.GetComponent<Player>().HasKey) {
			if (audioSource != null && !audioSource.isPlaying)
				audioSource.Play();

			//update defaultText
			defaultText = "Keep going!  Find the hacker!";
			text.GetComponent<TextController>().defaultText = defaultText;
			text.text = defaultText;

			gameObject.SetActive(false);
		}
	}
}
