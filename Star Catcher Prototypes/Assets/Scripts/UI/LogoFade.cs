using UnityEngine;
using System.Collections;

public class LogoFade : MonoBehaviour {

	public const int HOLD = 3;
	public AudioSource bgm;

	// Use this for initialization
	void Start () {
		MainMenu.InitFade += StartFade;

		if (!StaticVariables.isGameInitializing) {
			gameObject.SetActive (false);
			Unsubscribe ();
		}
	}

	void StartFade()
	{
		StartCoroutine (Fade());
		StaticVariables.isGameInitializing = false;
	}

	IEnumerator Fade()
	{
		yield return new WaitForSeconds (HOLD);
		GetComponent<WhiteInOut> ().enabled = true;
		GetComponent<WhiteInOut> ().FadeIn();
		bgm.Play ();
	}

	void Unsubscribe()
	{
		MainMenu.InitFade -= StartFade;
	}
}
