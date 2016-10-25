using UnityEngine;
using System.Collections;

public class StarBehaviour : MonoBehaviour {

	const int LIFESPAN = 5;

	// Use this for initialization
	void Start () {		
		Destroy (gameObject, LIFESPAN);
	}
}
