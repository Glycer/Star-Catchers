using UnityEngine;
using System.Collections;

public class WolfAttack : MonoBehaviour {

	private Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter()
	{
		anim.Play("Attack");
	}

	void Attack(GameObject target)
	{
		target.GetComponent<Animator>().Play("TakeHit");
	}
}
