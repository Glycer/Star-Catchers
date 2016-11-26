using UnityEngine;
using System.Collections;

public class LogoFade : MonoBehaviour {

	public const int HOLD = 3;

	// Use this for initialization
	void Start () {
		MainMenu.InitFade += StartFade;
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
	}

	void Unsubscribe()
	{
		MainMenu.InitFade -= StartFade;
	}
}
