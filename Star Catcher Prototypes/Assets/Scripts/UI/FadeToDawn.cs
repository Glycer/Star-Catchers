using UnityEngine;
using System.Collections;

public class FadeToDawn : MonoBehaviour {

	public Color tempCol;

	private int elapsedTime;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		elapsedTime = 0;
		sprite = GetComponent<SpriteRenderer> ();
		tempCol = GetComponentInParent<CloudCol>().cloudCol;

		StartCoroutine (Fade());
	}
	
	IEnumerator Fade()
	{
		while (elapsedTime <= LevelTimer.LEVEL_DURATION) {

			tempCol += GetComponentInParent<CloudCol>().cloudColIncrement;
			sprite.color = tempCol;

			yield return new WaitForSeconds (1);
			elapsedTime++;
		}
	}
}
