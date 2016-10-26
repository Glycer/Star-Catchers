using UnityEngine;
using System.Collections;
using System;

public class Cycler2 : MonoBehaviour {

	void OnTriggerEnter()
	{
		if (BackGroundFloors.CycleMidGround != null)
			BackGroundFloors.CycleMidGround ();
	}
}
