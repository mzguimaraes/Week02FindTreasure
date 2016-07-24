using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class Character : MonoBehaviour {

	public Text text;

	void OnTriggerEnter2D(Collider2D other) {
		//check if other is the player
		if (other.GetComponent<Player>() != null) {
			//increment player speed
			other.GetComponent<Player>().moveScalar += 10;
			text.text = "Character found!  Movement speed increased!";
			//gameObject.SetActive(false);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		text.text = text.GetComponent<TextController>().defaultText;
		gameObject.SetActive(false);
	}


}
