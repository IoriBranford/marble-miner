using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesText : MonoBehaviour {
	void Update () {
		var text = GetComponent<Text>();
		if (text != null) {
			text.text = Mathf.Max(0, Paddle.Lives).ToString();
		}
	}
}
