using UnityEngine;
using System.Collections;

public class ForceAspectRatio : MonoBehaviour {

	float forcedAspect = 5/2;
	//float currentAspect = Screen.height / Screen.width;

	Camera cam;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera> ();

		if (cam.aspect != forcedAspect) {
			cam.aspect = forcedAspect;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (cam.aspect != forcedAspect) {
			cam.aspect = forcedAspect;
		}
	}
}
