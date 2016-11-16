using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LevelTimer : MonoBehaviour {

	//public static Action TickTock;
	public static Action EndLevel;
	public static Action FadeOut;

	public SpriteRenderer sprite;

	public Light dirLight;

	const int SECONDS_IN_MINUTE = 60;
	private int elapsedTime = 0;
	private float colIncrement;

	private Color colTemp;
	private Color tempLightCol;
	private Text timer;

	const float MAX_LIGHT_INTENSITY = 1;
	private float incrementLightCol;
	private float incrementLightIntensity;
	private float baseLightIntensity;

	// Use this for initialization
	void Start () {
		colTemp = new Color (1, 1, 1, 0);
		tempLightCol = dirLight.color;

		colIncrement = .8f/StaticVariables.levelDuration;
		incrementLightCol = ((1f - dirLight.color.r) / StaticVariables.levelDuration);
		incrementLightIntensity = (MAX_LIGHT_INTENSITY - dirLight.intensity) / StaticVariables.levelDuration;
		timer = GetComponent<Text> ();
		timer.text = FormatSeconds((int)(StaticVariables.levelDuration));

		StartCoroutine (Tick());
	}

	IEnumerator Tick()
	{
		while (elapsedTime <= StaticVariables.levelDuration) {
			if (elapsedTime == StaticVariables.levelDuration - WhiteInOut.FADE_DURATION_OUT) {
				FadeOut ();
			}
			else if (elapsedTime == StaticVariables.levelDuration) {
				EndLevel ();
				SceneManager.LoadScene ("Level Summary");
			}

			FadeBackground ();
			FadeLight ();

			yield return new WaitForSeconds (1);
			elapsedTime++;
			timer.text = FormatSeconds((int)(StaticVariables.levelDuration - elapsedTime));
		}
	}


	void FadeBackground()
	{
		colTemp.a += colIncrement;
		sprite.color = colTemp;
	}

	void FadeLight()
	{
		dirLight.intensity += incrementLightIntensity;

		tempLightCol.r += incrementLightCol;
		tempLightCol.g += incrementLightCol;
		tempLightCol.b += incrementLightCol;
		dirLight.color = tempLightCol;
	}

	string FormatSeconds(int seconds)
	{
		if (seconds % SECONDS_IN_MINUTE < 10) {
			return ((seconds / SECONDS_IN_MINUTE) + ":0" + seconds % SECONDS_IN_MINUTE);
		}
		else {
			return ((seconds / SECONDS_IN_MINUTE) + ":" + seconds % SECONDS_IN_MINUTE);
		}
	}
}
