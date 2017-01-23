using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
	float X_ScreenToWorld (float x_screen) {
		return x_screen * 32f / Screen.width;
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		float x = X_ScreenToWorld(Input.mousePosition.x);
		x = Mathf.Clamp(x, 1, 31);

		Vector3 pos0 = transform.position;
		var pos1 = new Vector3 (x, pos0.y, pos0.z);
		transform.position = pos1;
	}
}
