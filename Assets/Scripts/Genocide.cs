using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Genocide : MonoBehaviour {
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
                UIText.text = "Anger Ninja: I only have bio sushi, you should ask Nancy Lee." +
                	"\nHead back and go west at the white dart, then follow the orange darts.  " +
                	"Wait--where did I leave that key?";
                inbound = true;
            }
        } else if (inbound && distance > outboundDistance) {
            UIText.text = defaultText;
            inbound = false;
        }
	}
}
