using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Yamato : MonoBehaviour {
    public Text UIText;
    public Transform player;
	public GameObject appearingDoor;

    public float inboundDistance = 1.5f;
    public float outboundDistance = 4f;

    // Use this for initialization
    string defaultText;
    bool inbound;
	void Start () {
        defaultText = UIText.GetComponent<TextController>().defaultText;
        inbound = false;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = (player.position - transform.position).magnitude;
	    if(distance < inboundDistance) {
            if (!inbound) {
                UIText.text = "These bombs will aid your in your quest!  Press [F] to use them!\n";
				player.GetComponent<Player>().HasBomb = true;
				appearingDoor.SetActive(true);
                inbound = true;
            }
        } else if (inbound && distance > outboundDistance) {
            UIText.text = defaultText;
            inbound = false;
        }
	}
}
