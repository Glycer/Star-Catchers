using UnityEngine;
using System.Collections;

public class WolfAI : MonoBehaviour {

	public float runSpeed;

	private bool canRun;
	private Rigidbody rigidBody;
	private Animator anim;

	private Vector3 jumpForce = new Vector3(0, 1000, 0);
	private Vector3 nullForce = new Vector3(0, 0, 0);

	// Use this for initialization
	void Start () {		
		rigidBody = GetComponent<Rigidbody> ();
		anim = GetComponentInChildren<Animator> ();

		canRun = true;
		Run ();
	}

	public void Jump()
	{
		anim.Play ("WolfJump");
		rigidBody.velocity = nullForce;
		rigidBody.AddForce (jumpForce);
	}

	/*
	public void Stop()
	{
		canRun = false;
	}
	*/

	public void Run()
	{
		StartCoroutine (IRun());
	}

	IEnumerator IRun()
	{
		while (canRun)
		{
			transform.Translate (runSpeed * Time.deltaTime, 0, 0);
			yield return new WaitForEndOfFrame ();
		}
	}
}