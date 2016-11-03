using UnityEngine;
using System.Collections;

public class StarCoreBehaviour : MonoBehaviour {

	void OnTriggerEnter()
	{
		if (Collection.CollectStar != null)
			Collection.CollectStar ();

		Destroy (transform.parent.gameObject);
	}
}
