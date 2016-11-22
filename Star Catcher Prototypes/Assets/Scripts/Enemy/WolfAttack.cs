using UnityEngine;
using System.Collections;

public class WolfAttack : MonoBehaviour {

	//private Animator anim;
	private GameObject sprayEffect;

	void Start()
	{
		//anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider col)
	{
		Collection.LoseStars ();
		sprayEffect = Instantiate (Resources.Load("2D/Effects/SprayEffect")) as GameObject;
		sprayEffect.transform.position = col.transform.position;
		//anim.Play("Attack");
		//Attack(col.gameObject);
	}

	void Attack(GameObject target)
	{
		target.GetComponent<Animator>().Play("TakeHit");
	}
}
