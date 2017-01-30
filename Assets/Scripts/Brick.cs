using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public int maxDamage;
	private int _damage;

	private LevelManager _levelManager;

	public Sprite[] damageSprites;

	// Use this for initialization
	void Start () {
		_damage = 0;
		_levelManager = GameObject.FindObjectOfType<LevelManager>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		++_damage;
		if (_damage >= maxDamage) {
			Destroy(gameObject);
			_levelManager.LoadNextLevel();
		} else {
			SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.sprite = damageSprites[_damage - 1];
		}
	}
}
