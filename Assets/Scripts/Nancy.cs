using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nancy : MonoBehaviour {
    public Text UIText;
    public Transform player;
    public Transform door;

    public float inboundDistance = 4.5f;
    public float outboundDistance = 12f;
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
        //Debug.Log(distance);
	    if(distance < inboundDistance) {
            if (!inbound) {
                UIText.text = "Nancy Lee: OK, I've hacked your bombs--they're stronger now!";

				//update defaultText
				defaultText = "Use the strong bombs to blast your way to sushi!";
				UIText.GetComponent<TextController>().defaultText = defaultText;

				inbound = true;
				if (!Bomb.isPoweredUp) {
					Bomb.isPoweredUp = true;
                }
                
            }
        } else if (inbound && distance > outboundDistance) {
            UIText.text = defaultText;
            inbound = false;
        }
	}
}
