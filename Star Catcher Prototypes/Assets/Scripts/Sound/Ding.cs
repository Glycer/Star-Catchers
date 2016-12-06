using UnityEngine;
using System.Collections;

public class Ding : MonoBehaviour {

	AudioSource aud;

	// Use this for initialization
	void Start () {
		Collection.CollectStar += PlayDing;
		LevelTimer.EndLevel += Unsubscribe;

		aud = GetComponent<AudioSource> ();
		aud.volume = MainMenuBGM.gameVolume / 2;
	}

	void PlayDing()
	{
		aud.Play ();
	}

	void Unsubscribe()
	{
		Collection.CollectStar -= PlayDing;
	}
}
