using UnityEngine;
using System.Collections;

public class WolfAnimLogic : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void Fall()
	{
		anim.speed = 0;
	}

	public void Land()
	{
		anim.speed = 1;
	}

	void OnCollisionEnter()
	{
		Land ();
	}
}
