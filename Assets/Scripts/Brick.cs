using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	private static int _NumBreakables;

	private int _damage;

	public Sprite[] damageSprites;

	// Use this for initialization
	void Start () {
		if (tag == "Breakable") {
			++_NumBreakables;
		}

		_damage = 0;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (tag == "Breakable") {
			Damage();
		}
	}

	void Damage () {
		++_damage;
		int spriteI = _damage - 1;
		if (spriteI >= damageSprites.Length) {
			Destroy(gameObject);
			--_NumBreakables;

			var levelManager =
				GameObject.FindObjectOfType<LevelManager>();
			levelManager.BrickDestroyed(_NumBreakables);
		} else if (damageSprites[spriteI] != null) {
			var spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = damageSprites[spriteI];
		}
	}
}
