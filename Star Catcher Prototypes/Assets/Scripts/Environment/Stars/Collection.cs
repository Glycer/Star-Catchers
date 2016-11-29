using UnityEngine;
using System.Collections;
using System;

public class Collection : MonoBehaviour {
	
	// Takes functions from the player when they collect stars, and the Text object tracking stars collected.
	public static Action CollectStar;

	public static Action<int> LoseStars;
}
