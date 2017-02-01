using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public static int NumBreakables;

	public static void LevelStarted () {
		NumBreakables = 0;
	}

	public AudioClip crackSound;
	public Sprite[] damageSprites;

	private int _damage;

	void Awake () {
		foreach (Transform child in transform) {
			var body = child.GetComponent<Rigidbody2D>();
			if (body != null) {
				body.gravityScale = 0;
			}
		}
	}

	// Use this for initialization
	void Start () {
		if (tag == "Breakable") {
			++NumBreakables;
		}

		_damage = 0;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		AudioSource.PlayClipAtPoint(crackSound, transform.position);
		if (tag == "Breakable") {
			Damage();
		}
	}

	void Damage () {
		++_damage;
		int spriteI = _damage - 1;
		if (spriteI >= damageSprites.Length) {
			Destroy(gameObject);
			--NumBreakables;

			foreach (Transform child in transform) {
				child.parent = transform.parent;
				var body = child.GetComponent<Rigidbody2D>();
				if (body != null) {
					body.gravityScale = 1;
				}
			}

			var levelManager =
				GameObject.FindObjectOfType<LevelManager>();
			levelManager.CheckNextLevel();
		} else if (damageSprites[spriteI] != null) {
			var spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = damageSprites[spriteI];
		}
	}
}
