using UnityEngine;
using System.Collections;

public class JumpPoint : MonoBehaviour {

	void OnTriggerEnter(Collider _col)
	{
		if (_col.transform.GetComponent<WolfAI> () != null)
			_col.transform.GetComponent<WolfAI> ().Jump ();
	}

}
