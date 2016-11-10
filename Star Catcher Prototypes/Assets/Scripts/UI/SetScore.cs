using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = StaticScore.finalScore.ToString();
	}
}
