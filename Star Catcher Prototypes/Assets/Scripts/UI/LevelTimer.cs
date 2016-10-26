using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class LevelTimer : MonoBehaviour {

	//public static Action TickTock;
	public static Action EndLevel;

	public const float LEVEL_DURATION = 60;

	public Light dirLight;

	private int elapsedTime = 0;
	private float colIncrement;

	private Color colTemp;
	private Color tempLightCol;
	private SpriteRenderer sprite;

	private float incrementLight;

	// Use this for initialization
	void Start () {
		colTemp = new Color (1, 1, 1, 0);
		tempLightCol = dirLight.color;

		colIncrement = 1f/LEVEL_DURATION;
		incrementLight = ((1f - dirLight.color.r) / LEVEL_DURATION);
		sprite = GetComponent<SpriteRenderer> ();

		StartCoroutine (Tick());
	}

	IEnumerator Tick()
	{
		while (elapsedTime <= LEVEL_DURATION) {
			if (elapsedTime == LEVEL_DURATION) {
				EndLevel ();
				SceneManager.LoadScene ("Start Screen");
			}

			FadeBackground ();
			FadeLight ();

			yield return new WaitForSeconds (1);
			elapsedTime++;
		}
	}


	void FadeBackground()
	{
		colTemp.a += colIncrement;
		sprite.color = colTemp;
	}

	void FadeLight()
	{
		tempLightCol.r += incrementLight;
		tempLightCol.g += incrementLight;
		tempLightCol.b += incrementLight;
		dirLight.color = tempLightCol;
	}
}
