using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour {

	const int LIFESPAN = 5;

	private Vector3 torqueForce = new Vector3(0, 0, 100);

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddTorque (torqueForce);
		Destroy (gameObject, LIFESPAN);
	}

	void OnTriggerEnter()
	{
		if (Collection.CollectStar != null)
			Collection.CollectStar ();

		Destroy (gameObject);
	}
}
