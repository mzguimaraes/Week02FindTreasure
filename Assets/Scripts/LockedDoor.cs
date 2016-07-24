using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {

	public Transform player;
	public float activeDistance = 4f;
	public AudioSource audioSource; //located at door's location.

	// Update is called once per frame
	void Update () {
		if ((transform.position - player.position).magnitude < activeDistance
			&& player.GetComponent<Player>().HasKey) {
			if (audioSource != null && !audioSource.isPlaying)
				audioSource.Play();
			gameObject.SetActive(false);
		}
	}
}
