using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void ToGame()
	{
		SceneManager.LoadScene ("Prototype One");
	}
}
