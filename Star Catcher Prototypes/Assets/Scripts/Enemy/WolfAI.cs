using UnityEngine;
using System.Collections;

public class WolfAI : MonoBehaviour {

	public float runSpeed;

	private Rigidbody rigidBody;
	private Vector3 jumpForce = new Vector3(0, 50, 0);

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Update () {
		transform.Translate (runSpeed * Time.deltaTime, 0, 0);
	}

	public void Jump()
	{
		rigidBody.AddForce (jumpForce);
	}
}
