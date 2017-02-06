using System.Collections;
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
	public GameObject shatterParticles;

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

		for (int i = 0; i < damageSprites.Length; ++i) {
			if (damageSprites[i] == null) {
				Debug.LogError(gameObject.name + " missing damage sprite " + i);
			}
		}
		_damage = 0;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (tag == "Breakable") {
			AudioSource.PlayClipAtPoint(crackSound,
					Camera.main.transform.position +
					(Camera.main.transform.rotation * Vector3.one));
			Damage();
		}
	}

	void Damage () {
		var spriteRenderer = GetComponent<SpriteRenderer>();

		GameObject particleObject = Instantiate(shatterParticles,
				transform.position, Quaternion.identity);
		var particleSystem = particleObject.GetComponent<ParticleSystem>();
		var particleMain = particleSystem.main;
		particleMain.startColor = spriteRenderer.color;

		++_damage;
		int spriteI = _damage - 1;
		if (spriteI >= damageSprites.Length) {
			if (transform.childCount > 0) {
				AudioSource.PlayClipAtPoint(itemDropSound,
					Camera.main.transform.position +
					(Camera.main.transform.rotation * Vector3.one));
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
			}

			Destroy(gameObject);
			--NumBreakables;

			var levelManager =
				GameObject.FindObjectOfType<LevelManager>();
			levelManager.CheckNextLevel();
		} else if (damageSprites[spriteI] != null) {
			spriteRenderer.sprite = damageSprites[spriteI];
		}
	}
}
