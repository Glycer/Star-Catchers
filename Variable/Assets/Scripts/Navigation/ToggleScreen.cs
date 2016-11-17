using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ToggleScreen : MonoBehaviour {

	public List<GameObject> screens;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			screens.Add (transform.GetChild(i));
		}
		
	}

	public void Toggle(GameObject activeScreen)
	{
		foreach (GameObject child in screens) {
			if (child == activeScreen) {
				activeScreen.SetActive (true);
			} else {
				activeScreen.SetActive (false);
			}
		}
	}
}