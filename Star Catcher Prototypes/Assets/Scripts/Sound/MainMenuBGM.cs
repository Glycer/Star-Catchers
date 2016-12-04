using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuBGM : MonoBehaviour {

	public const float MAX_VOLUME = 2f;
	public const float BASE_MENU = .05f;
	public const float BASE_GAME = .075f;

	public static float menuVolume = .05f;
	public static float gameVolume = .075f;

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

	public void VolumeControl(Slider slide)
	{
		menuVolume = slide.value * BASE_MENU * MAX_VOLUME;
		gameVolume = slide.value * BASE_GAME * MAX_VOLUME;

		aud.volume = menuVolume;
	}
}
