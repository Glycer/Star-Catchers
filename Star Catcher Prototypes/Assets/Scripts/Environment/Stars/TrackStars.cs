using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrackStars : MonoBehaviour {

	public int starsNum;
	private Text starsNumTxt;

	// Use this for initialization
	void Start () {
		Collection.CollectStar += IncrementStars;
		Collection.LoseStars += LoseStars;
		LevelTimer.EndLevel += SetScore;
		LevelTimer.EndLevel += Unsubscribe;

		starsNumTxt = GetComponent<Text> ();
		starsNumTxt.text = starsNum.ToString();
		starsNum = 0;
	}

	void IncrementStars()
	{
		starsNum++;
		UpdateStars ();
	}

	void LoseStars()
	{
		int rand = Random.Range (1, starsNum / 2);

		if (starsNum > 0) {
			starsNum -= rand;
			UpdateStars ();
		}
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
		LevelTimer.EndLevel -= SetScore;
	}

	void SetScore()
	{
		StaticScore.finalScore = starsNum;
	}
}
