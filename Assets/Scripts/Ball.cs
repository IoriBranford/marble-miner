using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	public Vector2 launchForce;

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

			if (_paddle.autoPlay || Input.GetMouseButtonDown(0)) {
				var body = GetComponent<Rigidbody2D>();
				body.AddForce(launchForce, ForceMode2D.Impulse);
				_started = true;
			}
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (_started && collision.gameObject.tag != "Breakable") {
			var audioSource = GetComponent<AudioSource>();
			audioSource.Play();
		}

		if (collision.gameObject == _paddle.gameObject) {
			var body = GetComponent<Rigidbody2D>();

			Vector2 newVelocity = body.position
				- collision.rigidbody.position;
			newVelocity *= body.velocity.magnitude
				/ newVelocity.magnitude;

			body.AddForce(body.mass * (newVelocity - body.velocity),
					ForceMode2D.Impulse);
		}
	}
}
