using UnityEngine;
using System.Collections;

public class CloudCol : MonoBehaviour {

	public Color cloudCol = new Color(0, 0, 0);
	public Color cloudColIncrement;

	private Color cloudColTarget = new Color (.16f, .35f, .55f);
	private float red;
	private float green;
	private float blue;

	// Use this for initialization
	void Start () {
		red = cloudColTarget.r / LevelTimer.LEVEL_DURATION;
		green =  cloudColTarget.g / LevelTimer.LEVEL_DURATION;
		blue =  cloudColTarget.b / LevelTimer.LEVEL_DURATION;
		cloudColIncrement = new Color (red, green, blue);
	}
}