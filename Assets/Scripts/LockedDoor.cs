using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {

	public Transform player;
	public float activeDistance = 4f;

	// Update is called once per frame
	void Update () {
		if ((transform.position - player.position).magnitude < activeDistance
			&& player.GetComponent<Player>().HasKey) {
			gameObject.SetActive(false);
		}
	}
}
