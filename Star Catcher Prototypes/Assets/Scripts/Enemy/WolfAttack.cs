using UnityEngine;
using System.Collections;

public class WolfAttack : MonoBehaviour {

	//private Animator anim;

	void Start()
	{
		//anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(/*Collider col*/)
	{
		Collection.LoseStars ();
		//anim.Play("Attack");
		//Attack(col.gameObject);
	}

	void Attack(GameObject target)
	{
		target.GetComponent<Animator>().Play("TakeHit");
	}
}
