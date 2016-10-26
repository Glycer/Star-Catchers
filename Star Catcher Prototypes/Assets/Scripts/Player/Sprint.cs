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
	private int sprintNum = 0;
	private int sprintMax = 25;
	private float fillDelay = .1f;
	private float drainDelay = .05f;

	private float boostSpeed;

	// Use this for initialization
	void Start () {
		boostSpeed = GetComponent<PlayerMotion> ().speed;

		PlayerMotion.StartSprint += Boost;
		PlayerMotion.ResetSprint += Stop;
		LevelTimer.EndLevel += Unsubscribe;
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
			meter.text = sprintNum.ToString ();
			yield return new WaitForSeconds (fillDelay);
		}
	}

	//Drain the sprint meter
	IEnumerator ChannelSprint()
	{
		GetComponent<PlayerMotion> ().speed += boostSpeed;

		while (sprintNum > 0) {
			sprintNum -= 1;
			meter.text = sprintNum.ToString ();
			yield return new WaitForSeconds (drainDelay);
		}
		ResetSpeed ();
	}

	//Reset speed whenever sprinting ceases
	void ResetSpeed()
	{
		GetComponent<PlayerMotion> ().speed = boostSpeed;
	}

	void Unsubscribe()
	{
		PlayerMotion.StartSprint -= Boost;
		PlayerMotion.ResetSprint -= Stop;
	}
}
