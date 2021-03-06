﻿using UnityEngine;
using System.Collections;

public class UpdateCloudCol : MonoBehaviour {

	private int elapsedTime;
	private Color tempCol;

	// Use this for initialization
	void Start () {
		elapsedTime = 0;

		StartCoroutine (Lighten());
	}

	IEnumerator Lighten()
	{
		while (elapsedTime <= StaticVariables.levelDuration) {

			tempCol = GetComponent<FadeToDawn>().tempCol;
			GetComponentInParent<CloudCol>().cloudCol = tempCol;

			yield return new WaitForSeconds (1);
			elapsedTime++;
		}
	}
}
