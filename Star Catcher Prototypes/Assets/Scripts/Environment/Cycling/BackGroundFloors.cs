using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BackGroundFloors : MonoBehaviour {

	public static Action CycleMidGround;

	const float FLOOR_LENGTH = 32;

	public List<GameObject> cyclableSections;
	public List<GameObject> nonCyclableSections;
	public List<GameObject> allSections;

	public Color cloudCol = new Color(0, 0, 0);
	public Color cloudColIncrement;
	private Color cloudColTarget = new Color (.16f, .35f, .55f);
	private float red;
	private float green;
	private float blue;

	private int rand;
	private GameObject tempObj;

	private Vector3 tempPos;
	private Vector3 basePos;

	// Use this for initialization
	void Start () {
		CameraMotion.ResetAll += Reset;
		CycleMidGround += Cycle;
		LevelTimer.EndLevel += Unsubscribe;

		red = cloudColTarget.r / LevelTimer.LEVEL_DURATION;
		green =  cloudColTarget.g / LevelTimer.LEVEL_DURATION;
		blue =  cloudColTarget.b / LevelTimer.LEVEL_DURATION;
		cloudColIncrement = new Color (red, green, blue);

		basePos = new Vector3 (-20, -20, 0);
		tempPos = new Vector3 (-41, -1, 9.5f);

		InitLists ();
	}

	void Cycle()
	{
		//Set variables
		rand = UnityEngine.Random.Range(0, cyclableSections.Count);
		GameObject _newPiece = cyclableSections [rand];
		GameObject _backEdge = nonCyclableSections [0];
		if (transform != null)
			_newPiece.transform.parent = transform;

		//Switch pieces on lists
		nonCyclableSections.Add(_newPiece);
		cyclableSections.Remove(_newPiece);

		cyclableSections.Add(_backEdge);
		nonCyclableSections.Remove(_backEdge);

		//Set new position
		_newPiece.transform.localPosition = tempPos;
		tempPos.x += FLOOR_LENGTH;
	}

	void Reset()
	{
		for (int i = 0; i < transform.childCount; i++) {
			if (transform.GetChild (i) != null)
				Destroy (transform.GetChild (i).gameObject);
		}

		cyclableSections.Clear ();
		nonCyclableSections.Clear ();
		tempPos.x = -41;

		InitLists ();
	}

	void InitLists()
	{
		for (int i = 0; i < 4; i++) {
			tempObj = Instantiate (allSections[i]);
			tempObj.GetComponent<SpriteRenderer> ().color = cloudCol;
			nonCyclableSections.Add (tempObj);

			tempObj.transform.parent = transform;
			tempObj.transform.localPosition = tempPos;
			tempPos.x += FLOOR_LENGTH;
		}

		for (int i = 4; i < 8; i++) {
			tempObj = Instantiate (allSections[i]);
			tempObj.GetComponent<SpriteRenderer> ().color = cloudCol;
			cyclableSections.Add (tempObj);

			tempObj.transform.parent = transform;
			tempObj.transform.localPosition = basePos;
		}
	}

	void Unsubscribe()
	{
		CameraMotion.ResetAll -= Reset;
		CycleMidGround -= Cycle;
	}
}
