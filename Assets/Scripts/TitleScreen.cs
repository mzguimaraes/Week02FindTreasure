using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

	public int nextScene = 1;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene(nextScene);
		}
	}
}
