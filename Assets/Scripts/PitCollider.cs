using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitCollider : MonoBehaviour {
	IEnumerator DeathAndRespawn () {
		var paddle = GameObject.FindObjectOfType<Paddle>();
		var ball = GameObject.FindObjectOfType<Ball>();
		paddle.Damage();

		yield return new WaitForSeconds(.5f);

		if (Paddle.Lives > 0) {
			paddle.Respawn();
			ball.Respawn();
		} else {
			LevelManager levelManager =
				GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("Lose");
		}
	}

	void OnTriggerEnter2D (Collider2D otherCollider) {
		if (otherCollider.gameObject.tag == "Ball") {
			StartCoroutine("DeathAndRespawn");
		}
	}
}
