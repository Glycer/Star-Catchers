using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlideControl : MonoBehaviour {

	private Slider slide;

	// Use this for initialization
	void Start () {
		slide = GetComponent<Slider> ();


		slide.value = (MainMenuBGM.menuVolume) / (MainMenuBGM.BASE_MENU * MainMenuBGM.MAX_VOLUME);
	}
}
