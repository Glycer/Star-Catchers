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
		starsNum = 0;
		UpdateStars ();
	}

	void IncrementStars()
	{
		starsNum++;
		UpdateStars ();
	}

	void LoseStars(int _numStars)
	{
		/*int rand = Random.Range (1, starsNum / 2);

		if (starsNum > 0) {
			starsNum -= rand;
			UpdateStars ();
		}
		*/

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
