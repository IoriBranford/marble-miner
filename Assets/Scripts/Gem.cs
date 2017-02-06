using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
	public static int NumGems;
	public GameObject sparkleParticles;
	public AudioClip pickupSound;

	public static void LevelStarted () {
		NumGems = 0;
	}

	// Use this for initialization
	void Start () {
		GameObject particleObject = Instantiate(sparkleParticles,
				transform.position, Quaternion.identity);
		particleObject.transform.SetParent(transform);

		++NumGems;
	}

	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
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
