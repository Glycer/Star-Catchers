﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetRating : MonoBehaviour {

	const float DIVISOR = 6;

	private float baseNum;

	private Dictionary<int, string> ratings;
	private Text txt;

	// Use this for initialization
	void Start () {
		baseNum = StaticVariables.levelDuration / DIVISOR;
		txt = GetComponent<Text> ();

		ratings = new Dictionary<int, string> {
			{ (int)baseNum, "CRAP" },
			{ (int)baseNum * 2, "MEDIOCRE" },
			{ (int)baseNum * 3, "DECENT" },
			{ (int)baseNum * 5, "EXCELLENT" },
		};

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
