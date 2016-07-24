using UnityEngine;
using System.Collections;

public class LockedDoor : MonoBehaviour {

	public Transform player;

	// Update is called once per frame
	void Update () {
		if ((transform.position - player.position).magnitude < 1.5f 
			&& player.GetComponent<Player>().HasKey) {
			gameObject.SetActive(false);
		}
	}
}
