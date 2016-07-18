using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Yamato : MonoBehaviour {
    public Text UIText;
    public Transform player;

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
        //Debug.Log(distance);
	    if(distance < inboundDistance) {
            if (!inbound) {
                UIText.text = "Yamato Koki: You are heading the wrong way.\nGo back and follow the red ninja darts.\n";
                inbound = true;
            }
        } else if (inbound && distance > outboundDistance) {
            UIText.text = defaultText;
            inbound = false;
        }
	}
}
