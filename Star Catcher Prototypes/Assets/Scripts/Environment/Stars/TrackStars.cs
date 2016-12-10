using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TrackStars : MonoBehaviour {

	public int starsNum;
	public StarSpin starSpin;
	private Text starsNumTxt;
	private FlashDing flashDing;

	public int mileMarker;

	// Use this for initialization
	void Start () {
		Collection.CollectStar += IncrementStars;
		Collection.LoseStars += LoseStars;
		LevelTimer.EndLevel += SetScore;
		LevelTimer.EndLevel += Unsubscribe;

		starsNumTxt = GetComponent<Text> ();
		flashDing = GetComponent<FlashDing> ();
		starsNum = 0;
		mileMarker = (int)StaticVariables.levelDuration / 6;
		UpdateStars ();
	}

	void IncrementStars()
	{
		starsNum++;
		UpdateStars ();
	}

	void LoseStars(int _numStars)
	{
		if (starsNum > 0) {
			starsNum -= _numStars;
			starsNum = (starsNum >= 0) ? starsNum : 0;

			UpdateStars ();
		}
	}

	void UpdateStars()
	{
		if (starsNumTxt != null) {
			starsNumTxt.text = starsNum.ToString();
		}
		if (starsNum != 0 && starsNum % mileMarker == 0) {
			//flashDing.CheckCol (mileMarker / 10);
			flashDing.RunDing ();
			starSpin.FlashBlue ();
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

	public static int LostStars()
	{
		int _stars = Random.Range (3, 6);
		return _stars;
	}
}
