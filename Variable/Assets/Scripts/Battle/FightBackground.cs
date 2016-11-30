using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FightBackground : MonoBehaviour {

	public List<Sprite> backgrounds;

	//Better code:
	//public Dictionary<string, Sprite> dictBackgrounds;

	private Image bg;

	// Use this for initialization
	void Start () {
		bg = GetComponent<Image> ();

		SetBackground (StaticLocations.location);
	}

	private void SetBackground(string _bg)
	{
		switch (_bg) {
		case "Park":
			bg.sprite = backgrounds [0];
			break;
		case "Mall":
			bg.sprite = backgrounds [1];
			break;
		case "Graveyard":
			bg.sprite = backgrounds [2];
			break;
		default:
			bg.sprite = backgrounds [0];
			break;
		}


		//Better code:
		//bg.sprite = dictBackgrounds[_bg];
	}
}
