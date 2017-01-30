using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitCollider : MonoBehaviour {

	private LevelManager _levelManager;

	void Start () {
		_levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnTriggerEnter2D (Collider2D otherCollider) {
		print("Trigger");
		_levelManager.LoadLevel("Win");
	}

	void OnCollisionEnter2D (Collision2D collision) {
		print("Collision");
	}
}
