using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitCollider : MonoBehaviour {

	public LevelManager levelManager;

	void OnTriggerEnter2D (Collider2D otherCollider) {
		print("Trigger");
		levelManager.LoadLevel("Win");
	}

	void OnCollisionEnter2D (Collision2D collision) {
		print("Collision");
	}
}
