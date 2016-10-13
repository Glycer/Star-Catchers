using UnityEngine;
using System.Collections;

public class KillSwitch : MonoBehaviour {

	void OnTriggerEnter()
	{
		CameraMotion.ResetAll();
	}
}
