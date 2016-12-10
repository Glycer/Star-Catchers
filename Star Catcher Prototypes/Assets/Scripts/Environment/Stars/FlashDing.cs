using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlashDing : MonoBehaviour {
	
	private AudioSource aud;

	// Use this for initialization
	void Start () {
		aud = GetComponent<AudioSource> ();
	}

	public void RunDing()
	{
		StartCoroutine (DingDingDing());
	}

	IEnumerator DingDingDing()
	{
		for (int i = 0; i < 3; i++) {
			aud.Play ();
			yield return new WaitForSeconds(.15f);
			if (i != 2)
				aud.Stop ();
		}
	}
}
