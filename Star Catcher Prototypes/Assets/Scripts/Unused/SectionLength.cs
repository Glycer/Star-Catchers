using UnityEngine;
using System.Collections;

public class SectionLength : MonoBehaviour {
	/*
	 * This class converts an object's length in Maya units to Unity units
	 * When moving from Maya, the length of an object becomes:
	 * l = ((m * s) / 2) * 0.1
	 * Where l = final length in Unity, m = length in Maya, and s = scale in Unity
	*/

	public int mayaLength;
	public float finalLength;

	void Start()
	{
		finalLength = ((mayaLength * transform.localScale.x) / 2) * .1f;
	}
}