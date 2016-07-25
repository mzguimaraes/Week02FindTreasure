using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Genocide : MonoBehaviour {
    public Text UIText;
    public Transform player;

    public float inboundDistance = 1.5f;
    public float outboundDistance = 4f;

    bool inbound = false;
	
	// Update is called once per frame
	void Update () {
        float distance = (player.position - transform.position).magnitude;
	    if(distance < inboundDistance) {
            if (!inbound) {
                UIText.text = "Anger Ninja: This sushi isn't organic!  You can't eat this trash!" +
                	"\nLeave it for me, I'll eat it all so you don't have to.";
                inbound = true;
            }
        } else if (inbound && distance > outboundDistance) {
			UIText.text = UIText.GetComponent<TextController>().defaultText;
            inbound = false;
        }
	}
}
