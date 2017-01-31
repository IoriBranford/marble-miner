using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public float launchForce;

	private Paddle _paddle;
	private Vector3 _fromPaddle;
	private bool _started = false;

	// Use this for initialization
	void Start () {
		_paddle = GameObject.FindObjectOfType<Paddle>();
		_fromPaddle = transform.position - _paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_started) {
			transform.position = _paddle.transform.position
				+ _fromPaddle;

			if (Input.GetMouseButtonDown(0)) {
				var body = GetComponent<Rigidbody2D>();
				body.AddForce(new Vector2(0f, launchForce),
						ForceMode2D.Impulse);
				_started = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (_started) {
			var audioSource = GetComponent<AudioSource>();
			audioSource.Play();
		}
	}
}
