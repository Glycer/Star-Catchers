using UnityEngine;
using System.Collections;

public class JumpPoint : MonoBehaviour {

	void OnTriggerEnter(Collider _col)
	{
		_col.transform.GetComponent<WolfAI> ().Jump ();
	}

}
