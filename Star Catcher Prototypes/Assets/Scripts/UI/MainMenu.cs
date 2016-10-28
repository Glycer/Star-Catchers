using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class MainMenu : MonoBehaviour {

	public static Action FadeIn;
	public static Action ChangeScene;

	void Start()
	{
		FadeIn ();
	}

	public void ToGame()
	{
		ChangeScene ();
		SceneManager.LoadScene ("Prototype One");
	}
}
