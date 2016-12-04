using UnityEngine;
using System.Collections;

public class VolumeControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<AudioSource> ().volume = MainMenuBGM.gameVolume;
	}
}
