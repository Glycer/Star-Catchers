using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrackStars : MonoBehaviour {

	private int starsNum = 0;
	private Text starsNumTxt;

	// Use this for initialization
	void Start () {
		starsNumTxt = GetComponent<Text> ();
		starsNumTxt.text = starsNum.ToString();

		Collection.CollectStar += IncrementStars;
		Collection.LoseStars += LoseStars;
	}

	void IncrementStars()
	{
		starsNum++;
		starsNumTxt.text = starsNum.ToString ();
	}

	void LoseStars()
	{
		int rand = Random.Range (1, starsNum / 2);

		starsNum -= rand;
		starsNumTxt.text = starsNum.ToString();
	}
}
