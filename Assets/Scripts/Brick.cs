﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public static int NumBreakables;

	public static void LevelStarted () {
		NumBreakables = 0;
	}

	public AudioClip crackSound;
	public AudioClip itemDropSound;
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
		if (tag == "Breakable") {
			AudioSource.PlayClipAtPoint(crackSound,
					Camera.main.transform.position);
			Damage();
		}
	}

	void Damage () {
		++_damage;
		int spriteI = _damage - 1;
		if (spriteI >= damageSprites.Length) {
			Destroy(gameObject);
			--NumBreakables;

			if (transform.childCount > 0) {
				AudioSource.PlayClipAtPoint(itemDropSound,
						Camera.main.transform.position);
			}

			foreach (Transform child in transform) {
				child.SetParent(transform.parent);
				child.position.Set(
						child.position.x,
						child.position.y,
						-child.position.z);
				var body = child.GetComponent<Rigidbody2D>();
				if (body != null) {
					body.gravityScale = 1;
				}

				//workaround for bug
				//https://fogbugz.unity3d.com/default.asp?877192_lfjq5e35puc7div9
				{
					foreach (var childCollider 
						in child.GetComponents<Collider2D>()) {
						childCollider.enabled = true;
					}

					foreach (var childBehaviour
						in child.GetComponents<MonoBehaviour>()) {
						childBehaviour.enabled = true;
					}
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
