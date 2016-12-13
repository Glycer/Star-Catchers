using UnityEngine;
using System.Collections;

public class Swirl : MonoBehaviour {

	private GameObject effect;

	// Use this for initialization
	void Start () {
		Collection.CollectStar += StartSwirl;
		LevelTimer.EndLevel += Unsubscribe;
	}

	void StartSwirl()
	{
		effect = Instantiate (Resources.Load("2D/Effects/SwirlEffect")) as GameObject;
		effect.transform.SetParent(transform);
		effect.transform.localPosition = new Vector3 (0, 0, 0);
	}

	void Unsubscribe()
	{
		Collection.CollectStar -= StartSwirl;
	}
}
