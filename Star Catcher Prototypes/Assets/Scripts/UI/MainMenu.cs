using UnityEngine;
using System.Collections;
using System;

public class MainMenu : MonoBehaviour {

	public static Action FadeIn;
	public static Action ChangeScene;

	void Start()
	{
		ChangeScene += JunkFunction;

		if (FadeIn != null)
			FadeIn ();
	}

	//For some reason, the delegates in this class both remain null if no function is assigned to them here
	void JunkFunction()
	{
	}
}
