using UnityEngine;
using System.Collections;

public class MainMenuBGM : MonoBehaviour {

	AudioSource aud;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();

		if (StaticVariables.isGameInitializing) {
			StartCoroutine (DelayedPlay());
		} else {
			aud.Play ();
		}
	}

	IEnumerator DelayedPlay()
	{
		yield return new WaitForSeconds (LogoFade.HOLD);
		aud.Play ();
	}
}
