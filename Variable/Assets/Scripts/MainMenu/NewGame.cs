using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewGame : MonoBehaviour {

	/// <summary>
	/// Starts the game.
	/// </summary>
	public void StartGame()
	{
		SceneManager.LoadScene ("Main");
	}
}
