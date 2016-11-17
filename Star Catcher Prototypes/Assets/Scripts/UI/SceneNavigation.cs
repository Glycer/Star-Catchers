using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneNavigation : MonoBehaviour {

	public string sceneName;

	public void Navigate()
	{
		MainMenu.ChangeScene ();
		SceneManager.LoadScene (sceneName);
	}
}
