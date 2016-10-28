using UnityEngine;
using System.Collections;

public class WolfAI : MonoBehaviour {

	public float runSpeed;

	private bool canRun;
	private Rigidbody rigidBody;
	private Vector3 jumpForce = new Vector3(0, 300, 0);

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		canRun = true;
		
		StartCoroutine(Run());
	}

	public void Jump()
	{
		rigidBody.AddForce (jumpForce);
	}
	
	public void Stop()
	{
		canRun = false;
	}
	
	IEnumerator Run()
	{
		while (canRun)
		{
			transform.Translate (runSpeed * Time.deltaTime, 0, 0);
			yield return;
		}
	}
}

//Make this a separate script
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
