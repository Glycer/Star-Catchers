using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LevelTimer : MonoBehaviour {

	//public static Action TickTock;
	public static Action EndLevel;
	public static Action FadeOut;

	public const float LEVEL_DURATION = 60;
	public Text timer;

	public Light dirLight;

	private int elapsedTime = 0;
	private float colIncrement;

	private Color colTemp;
	private Color tempLightCol;
	private SpriteRenderer sprite;

	const float MAX_LIGHT_INTENSITY = 2;
	private float incrementLightCol;
	private float incrementLightIntensity;
	private float baseLightIntensity;

	// Use this for initialization
	void Start () {
		colTemp = new Color (1, 1, 1, 0);
		tempLightCol = dirLight.color;

		colIncrement = 1f/LEVEL_DURATION;
		incrementLightCol = ((1f - dirLight.color.r) / LEVEL_DURATION);
		incrementLightIntensity = (MAX_LIGHT_INTENSITY - dirLight.intensity) / LEVEL_DURATION;
		sprite = GetComponent<SpriteRenderer> ();
		timer.text = LEVEL_DURATION.ToString ();

		StartCoroutine (Tick());
	}

	IEnumerator Tick()
	{
		while (elapsedTime <= LEVEL_DURATION) {
			if (elapsedTime == LEVEL_DURATION - WhiteInOut.FADE_DURATION_OUT) {
				FadeOut ();
			}
			else if (elapsedTime == LEVEL_DURATION) {
				EndLevel ();
				SceneManager.LoadScene ("Start Screen");
			}

			FadeBackground ();
			FadeLight ();

			yield return new WaitForSeconds (1);
			elapsedTime++;
			timer.text = (LEVEL_DURATION - elapsedTime).ToString ();
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
}
