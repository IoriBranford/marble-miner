using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
	public static int NumGems;
	public static int MaxGems;
	public static int CaughtGems;

	public static void LevelStarted () {
		NumGems = 0;
		MaxGems = 0;
		CaughtGems = 0;
	}

	public GameObject sparkleParticles;
	public AudioClip pickupSound;

	private GameObject _hudSlot;

	// Use this for initialization
	void Start () {
		GameObject particleObject = Instantiate(sparkleParticles,
				transform.position, Quaternion.identity, transform);

		++NumGems;
		++MaxGems;

		var hud = GameObject.FindObjectOfType<HUD>();
		var spriteRenderer = GetComponent<SpriteRenderer>();
		_hudSlot = hud.AppendGemSlot(spriteRenderer.color);
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			var hud = GameObject.FindObjectOfType<HUD>();
			hud.FillGemSlot(_hudSlot);

			++CaughtGems;
			if (CaughtGems == MaxGems) {
				Paddle.GiveLife();
			}

			AudioSource.PlayClipAtPoint(pickupSound,
					Camera.main.transform.position +
					(Camera.main.transform.rotation * Vector3.one));
		}
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
