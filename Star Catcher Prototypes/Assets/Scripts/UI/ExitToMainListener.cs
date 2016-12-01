using UnityEngine;
using System.Collections;

public class ExitToMainListener : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			LevelTimer.EndLevel ();
			MainMenu.ChangeScene ();
			UnityEngine.SceneManagement.SceneManager.LoadScene ("Start Screen");
		}
	}
}
