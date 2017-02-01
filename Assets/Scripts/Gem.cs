using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
	public static int NumGems;

	public static void LevelStarted () {
		NumGems = 0;
	}

	// Use this for initialization
	void Start () {
		++NumGems;
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D collision) {
		DestroyAndNotify();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		DestroyAndNotify();
	}

	void DestroyAndNotify() {
		Destroy(gameObject);
		--NumGems;

		var levelManager =
			GameObject.FindObjectOfType<LevelManager>();
		levelManager.CheckNextLevel();
	}
}
