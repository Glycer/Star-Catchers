using UnityEngine;
using System.Collections;
using System;

public class MainMenu : MonoBehaviour {

	public static Action InitFade;
	public static Action FadeIn;
	public static Action ChangeScene;

	void Start()
	{
		InitFade += InitToFalse;

		if (StaticVariables.isGameInitializing)
			InitFade();
		else if (FadeIn != null)
			FadeIn ();
	}

	//For some reason, the delegates in this class both remain null if no function is assigned to them here
	void InitToFalse()
	{
		StaticVariables.isGameInitializing = false;
	}
}
