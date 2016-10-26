using UnityEngine;
using System.Collections;
using System;

public class CameraMotion : MonoBehaviour {

	//public static Action<CameraMotion> ResetAll;
	public delegate void Reset();
	public static Reset ResetAll;

	public float speed = 1;
	private Vector3 tempPos;
	private Vector3 resetPos;

	void Start()
	{
		Screen.SetResolution (1000, 400, false);
		resetPos = transform.position;
		ResetAll += ResetCam;
		LevelTimer.EndLevel += Unsubscribe;
	}

	// Update is called once per frame
	void Update () {
		tempPos.x = speed * Time.deltaTime;
		transform.Translate (tempPos);
	}

	void ResetCam()
	{
		transform.position = resetPos;
	}

	void Unsubscribe()
	{
		ResetAll -= ResetCam;
	}
}
