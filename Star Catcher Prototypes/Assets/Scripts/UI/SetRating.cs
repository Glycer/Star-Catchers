using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetRating : MonoBehaviour {
	
	private Text txt;

	// Use this for initialization
	void Start () {
		txt = GetComponent<Text> ();

		txt.text = Set (StaticScore.finalScore);
	}

	string Set(int _score)
	{
		return "NONE";
	}
}
