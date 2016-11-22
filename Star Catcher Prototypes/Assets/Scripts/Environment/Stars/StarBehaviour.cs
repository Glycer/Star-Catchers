using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour {

	const int LIFESPAN = 5;

	private Vector3 torqueForce = new Vector3(0, 0, 100);

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddTorque (torqueForce);
		//Destroy (gameObject, LIFESPAN);
		StartCoroutine(Flash());
	}

	void OnTriggerEnter()
	{
		if (Collection.CollectStar != null)
			Collection.CollectStar ();

		Destroy (gameObject);
	}

	IEnumerator Flash()
	{
		for (int i = 0; i <= LIFESPAN; i++) {
			if (i == LIFESPAN) {
				GetComponent<Animator> ().Play ("StarDeath");
			}
			yield return new WaitForSeconds (1);
		}
	}
}
