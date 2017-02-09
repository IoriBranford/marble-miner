using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	private bool _finished;

	void Start () {
		_finished = false;
	}

	void Update () {
		if (_finished) {
			if (Input.GetMouseButtonDown(0)) {
				LoadNextLevel();
			}
		}
	}

	public void LoadLevel (string name) {
		Debug.Log("Loading level " + name);
		SceneManager.LoadScene(name);
		StartLevel();
	}

	public void LoadNextLevel () {
		int i = SceneManager.GetActiveScene().buildIndex + 1;
		Debug.Log("Loading level " + i);
		SceneManager.LoadScene(i);
		StartLevel();
	}

	public void Quit () {
		Debug.Log("Quitting");
		Application.Quit();
	}

	void StartLevel () {
		Brick.LevelStarted();
		Gem.LevelStarted();
	}

	public void CheckNextLevel () {
		if (Brick.NumBreakables == 0) {// && Gem.NumGems == 0) {
			_finished = true;
			var ball = GameObject.FindObjectOfType<Ball>();
			ball.gameObject.SetActive(false);

			var canvas = GameObject.FindObjectOfType<Canvas>();
			Transform clearUI = canvas.transform.FindChild("ClearUI");

			if (clearUI) {
				clearUI.gameObject.SetActive(true);
			}
		}
	}
}
