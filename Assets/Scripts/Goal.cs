using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour {
    bool didPlayerWin = false;
    public Text UIText;
    public Transform player;
    public float inboundDistance = 2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float distance = (player.position - transform.position).magnitude;
        if (distance < inboundDistance) {
            UIText.text = "Press [SPACE] to start eating organic sushi!";
            if (Input.GetKeyDown(KeyCode.Space)) {
                didPlayerWin = true;
            }
        }
        if (didPlayerWin) {
			SceneManager.LoadScene(2);
        }
	}
}
