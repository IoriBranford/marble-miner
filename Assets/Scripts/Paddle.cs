using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public static int Lives = 2;

	public static void GameStarted () {
		Lives = 2;
	}

	public static void GiveLife () {
		++Lives;
	}

	public static bool IsGameOver () {
		return Lives < 0;
	}

	public bool autoPlay;
	public GameObject shatterParticles;
	public AudioClip crackSound;

	private float _xMin, _xMax;

	// Use this for initialization
	void Start () {
		float stageLeft = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
		float stageRight = Camera.main.ViewportToWorldPoint(Vector3.one).x;

		_xMin = stageLeft;
		_xMax = stageRight;

		foreach (var collider in GetComponents<Collider2D>()) {
			Bounds bounds = collider.bounds;
			_xMin = Mathf.Max(_xMin, stageLeft + bounds.extents.x);
			_xMax = Mathf.Min(_xMax, stageRight - bounds.extents.x);
		}
	}

	// Update is called once per frame
	void Update () {
		if (autoPlay) {
			AutoMove();
		} else {
			MouseMove();
		}
	}

	void AutoMove () {
		var ball = GameObject.FindObjectOfType<Ball>();
		float x = ball.transform.position.x;
		MoveTo(Random.Range(x - .5f, x + .5f));
	}

	void MouseMove () {
		Vector3 mouseWorldPos =
			Camera.main.ScreenToWorldPoint(Input.mousePosition);
		MoveTo(mouseWorldPos.x);
	}

	void MoveTo (float x) {
		x = Mathf.Clamp(x, _xMin, _xMax);

		Vector3 pos0 = transform.position;
		var pos1 = new Vector3 (x, pos0.y, pos0.z);
		transform.position = pos1;
	}

	public void Damage () {
		AudioSource.PlayClipAtPoint(crackSound,
				Camera.main.transform.position +
				(Camera.main.transform.rotation * Vector3.one));
		GameObject particleObject = Instantiate(shatterParticles,
			transform.position, Quaternion.identity);
		var particleSystem = particleObject.GetComponent<ParticleSystem>();
		var particleMain = particleSystem.main;
		var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		if (spriteRenderer) {
			particleMain.startColor = spriteRenderer.color;
		}

		--Lives;
		gameObject.SetActive(false);
	}

	public void Respawn () {
		gameObject.SetActive(true);
	}
}
