using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetRating : MonoBehaviour {

	private Dictionary<int, string> ratings = new Dictionary<int, string> {
		{ 10, "CRAP" },
		{ 20, "MEDIOCRE" },
		{ 30, "DECENT" },
		{ 50, "EXCELLENT" },
	};
	private Text txt;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();

		txt.text = Set (StaticScore.finalScore);
	}

	string Set(int _score)
	{
		foreach (var pair in ratings) {
			if (_score <= pair.Key) {
				return pair.Value;
			}
		}
		return "INCREDIBLE!";
	}
}
