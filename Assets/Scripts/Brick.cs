using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int maxHealth;
	private int _health;

	private LevelManager _levelManager;

	// Use this for initialization
	void Start () {
		_health = maxHealth;
		_levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		--_health;
		if (_health <= 0) {
			Destroy(gameObject);
			_levelManager.LoadNextLevel();
		}
	}
}
