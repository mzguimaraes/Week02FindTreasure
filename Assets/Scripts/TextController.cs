using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    public string defaultText = "You are a starving ninja.\nYou need some Organic Sushi!";

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = defaultText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
