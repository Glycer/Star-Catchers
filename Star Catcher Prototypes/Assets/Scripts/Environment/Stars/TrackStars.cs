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
		LevelTimer.EndLevel += Unsubscribe;
	}

	void IncrementStars()
	{
		starsNum++;
		UpdateStars ();
	}

	void LoseStars()
	{
		int rand = Random.Range (1, starsNum / 2);

		starsNum -= rand;
		UpdateStars ();
	}

	void UpdateStars()
	{
		if (starsNumTxt != null) {
			starsNumTxt.text = starsNum.ToString();
		}
	}

	void Unsubscribe()
	{
		Collection.CollectStar -= IncrementStars;
		Collection.LoseStars -= LoseStars;
	}
}
