using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToggleInstructions : MonoBehaviour {

	public GameObject instructions;

	// Use this for initialization
	void Start () {
		instructions.SetActive (false);
	}

	public void Pop()
	{
		if (instructions.activeInHierarchy) {
			instructions.SetActive (false);
		} else {
			instructions.SetActive (true);
		}
	}
}
