using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int maxHealth;
	private int _health;

	// Use this for initialization
	void Start () {
		_health = maxHealth;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		--_health;
		if (_health <= 0) {
			Destroy(gameObject);
		}
	}
}
