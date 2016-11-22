using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Toggle screens. This is designed to be placed on an object, such as a canvas,
/// 	with its children organized into self-contained screens.
/// </summary>
public class ToggleScreen : MonoBehaviour {

	//For toggling between scenes
	public string sceneName;

	//For toggling between views in a single scene
	public List<GameObject> screens;

	// Use this for initialization
	void Start () {
		//Fill screens List with this object's children
		for (int i = 0; i < transform.childCount; i++) {
			screens.Add (transform.GetChild(i).gameObject);
		}
		
	}

	/// <summary>
	/// Toggle between scenes.
	/// </summary>
	/// <param name="sceneName">String, refers to the name of the scene to be loaded.</param>
	public void Toggle (string sceneName)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
	}

	/// <summary>
	/// Toggle between views in a single scene.
	/// </summary>
	/// <param name="activeScreenIndex">Int, refers to the index of an object in screens.</param>
	public void Toggle(int activeScreenIndex)
	{
		foreach (GameObject child in screens) {
			if (screens[activeScreenIndex] == child) {
				child.SetActive (true);
			} else {
				child.SetActive (false);
			}
		}
	}
}