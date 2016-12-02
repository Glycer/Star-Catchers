using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterSelect : MonoBehaviour {

	public Image charImage;
	public List<Sprite> lstChars;

	private Dropdown dropDown;

	// Use this for initialization
	void Start () {
		dropDown = GetComponent<Dropdown> ();
	}

	public void SelectCharacter()
	{
		string _charName = dropDown.itemText.text;

		//Note: make this a dictionary later
		switch (_charName) {
		case "Ivan":
			charImage.sprite = lstChars [0];
			break;
		case "Janice":
			charImage.sprite = lstChars [1];
			break;
		case "Rowan":
			charImage.sprite = lstChars [2];
			break;
		case "Moira":
			charImage.sprite = lstChars [3];
			break;
		default:
			break;
		}
	}
}
