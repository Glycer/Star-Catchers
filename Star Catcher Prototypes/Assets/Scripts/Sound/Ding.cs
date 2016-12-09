using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ding : MonoBehaviour {

	public List<AudioClip> clips;

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
		aud.clip = clips[0];
		aud.Play ();
	}

	public void PlayHit()
	{
		aud.clip = clips[1];
		aud.Play ();
	}

	void Unsubscribe()
	{
		Collection.CollectStar -= PlayDing;
	}
}
