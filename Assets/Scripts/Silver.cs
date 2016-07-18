using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Silver : MonoBehaviour {
    public Text UIText;
    public Transform player;

    public float inboundDistance = 2f;
    public float outboundDistance = 8f;
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
                UIText.text = "Silver Ninja: Go back and head north at the white dart.\nAsk the Genocide Ninja about it.\n";
                inbound = true;
            }
        } else if (inbound && distance > outboundDistance) {
            UIText.text = defaultText;
            inbound = false;
        }
	}
}
