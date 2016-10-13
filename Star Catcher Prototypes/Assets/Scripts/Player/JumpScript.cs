using UnityEngine;
using System.Collections;

public class JumpScript : MonoBehaviour {

	//Variables for jump control
	private Vector3 jumpForce = new Vector3 (0, 400, 0);
	private Animator anim;
	private Vector3 nullForce = new Vector3(0, 0, 0);
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rigidBody = GetComponent<Rigidbody> ();
	}

	void OnCollisionStay()
	{
		UnPause ();
		anim.SetBool ("Jump2", false);
	}

	public void Hop()
	{
		anim.Play ("BunnyShortJump");
		rigidBody.velocity = nullForce;
		GetComponent<Rigidbody> ().AddForce (jumpForce);
	}

	public void Hop2()
	{
		UnPause ();
		anim.SetBool ("Jump2", true);
		rigidBody.velocity = nullForce;
		GetComponent<Rigidbody> ().AddForce (jumpForce);
	}

	public void Pause()
	{
		anim.speed = 0;
	}

	public void UnPause()
	{
		anim.speed = 1;
	}
}
