using UnityEngine;
using System.Collections;

public class SelectLevelDuration : MonoBehaviour {

	public const float LEVEL_SHORT = 60;
	public const float LEVEL_MEDIUM = 120;
	public const float LEVEL_LONG = 180;

	private float duration;

	// Use this for initialization
	void Start () {
		duration = LEVEL_SHORT;

		StaticVariables.levelDuration = duration;
	}

	public void SetDuration(int selected)
	{
		switch (selected) {
		case 0:
			duration = LEVEL_SHORT;
			break;
		case 1:
			duration = LEVEL_MEDIUM;
			break;
		case 2:
			duration = LEVEL_LONG;
			break;
		default:
			break;
		}

		StaticVariables.levelDuration = duration;
	}
}
