using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillSwitch : MonoBehaviour {

	void OnTriggerEnter()
	{
		CameraMotion.ResetAll();
		Collection.LoseStars (TrackStars.LostStars());
	}
}
