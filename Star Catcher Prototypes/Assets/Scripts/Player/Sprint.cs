using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Sprint : MonoBehaviour {

	/*Variables for sprint control: a reference to another object in the scene that indicates how much sprint power is available;
	 * an integer representing the current amount of sprint energy; an integer representing the sprint energy cap;
	 * and two floats to control how quickly sprint energy passively fills or drains when active.
	*/
	public Text meter;
	public Image star;
	public bool canSprint = false;

	private int sprintNum = 0;
	private int sprintMax = 50;
	private float fillDelay = .1f;
	private float drainDelay = .05f;

	private float originSpeed;
	private float boostSpeed;
	private Color tempCol;

	// Use this for initialization
	void Start () {
		originSpeed = GetComponent<PlayerMotion> ().speed;
		boostSpeed = GetComponent<PlayerMotion> ().speed * 2.5f;

		PlayerMotion.StartSprint += Boost;
		PlayerMotion.ResetSprint += Stop;
		LevelTimer.EndLevel += Unsubscribe;

		tempCol = new Color (1, 1, 1, 0);
		star.color = tempCol;
		meter.text = "";
	}

	void Boost()
	{
		StopAllCoroutines ();
		StartCoroutine (ChannelSprint());
	}

	void Stop()
	{
		ResetSpeed ();
		StopAllCoroutines ();
		StartCoroutine (RefillSprint());
	}

	//Passively fill the sprint meter
	public IEnumerator RefillSprint()
	{
		while (sprintNum < sprintMax) {
			sprintNum++;
			UpdateStarTransparency ();
			IsMaxed ();
			yield return new WaitForSeconds (fillDelay);
		}
	}

	//Drain the sprint meter
	IEnumerator ChannelSprint()
	{
		GetComponent<PlayerMotion> ().speed = boostSpeed;
		meter.text = "";

		while (sprintNum > 0) {
			sprintNum -= 2;
			UpdateStarTransparency ();
			yield return new WaitForSeconds (drainDelay);
		}
		ResetSpeed ();
	}

	//Reset speed whenever sprinting ceases
	void ResetSpeed()
	{
		GetComponent<PlayerMotion> ().speed = originSpeed;
	}

	void IsMaxed()
	{
		if (sprintNum == sprintMax) {
			canSprint = true;
			meter.text = "Sprint!";
		}
	}

	void UpdateStarTransparency()
	{
		tempCol.a = (float)sprintNum / (float)sprintMax;
		star.color = tempCol;
	}

	void Unsubscribe()
	{
		PlayerMotion.StartSprint -= Boost;
		PlayerMotion.ResetSprint -= Stop;
	}
}
