using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
    public bool isOpen;
	// Use this for initialization
	void Start () {
        isOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isOpen) {
            Destroy(this.gameObject);
        }
	}
}
