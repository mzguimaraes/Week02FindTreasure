using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class StartScreenAudioController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (SceneManager.GetActiveScene().buildIndex == 1 //if current scene is controls
			&& Input.GetKeyDown(KeyCode.Space)) { //if we're moving to main scene
			Destroy(gameObject);
		}
	}
}
