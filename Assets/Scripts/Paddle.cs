using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	public bool autoPlay;

	float X_ScreenToWorld (float x_screen) {
		return x_screen * 32f / Screen.width;
	}

	// Use this for initialization
	void Start () {
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
		float x = X_ScreenToWorld(Input.mousePosition.x);
		MoveTo(x);
	}

	void MoveTo (float x) {
		x = Mathf.Clamp(x, 1, 31);

		Vector3 pos0 = transform.position;
		var pos1 = new Vector3 (x, pos0.y, pos0.z);
		transform.position = pos1;
	}
}
