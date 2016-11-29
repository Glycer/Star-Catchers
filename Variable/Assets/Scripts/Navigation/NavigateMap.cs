using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class NavigateMap : MonoBehaviour {

	public static Action<string> LoadLocation;

	public static List<string> locations = new List<string> {"Park", "Graveyard", "Mall"};

	// Use this for initialization
	void Start () {
		LoadLocation += SetLocation;
	}

	public void SelectLocation(string _location)
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Battle");

		LoadLocation (_location);
	}

	private void SetLocation(string _location)
	{
		StaticLocations.location = _location;
	}
}
