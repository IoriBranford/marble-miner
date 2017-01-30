using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	public void LoadLevel (string name) {
		Debug.Log("Loading level " + name);
		SceneManager.LoadScene(name);
	}

	public void LoadNextLevel () {
		int i = SceneManager.GetActiveScene().buildIndex + 1;
		Debug.Log("Loading level " + i);
		SceneManager.LoadScene(i);
	}

	public void Quit () {
		Debug.Log("Quitting");
		Application.Quit();
	}
}
