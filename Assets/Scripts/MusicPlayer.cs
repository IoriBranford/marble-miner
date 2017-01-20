using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer _instance;

	void Awake () {
		if (_instance == null) {
			GameObject.DontDestroyOnLoad(gameObject);
			_instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	// Between Awake and Start is when an audio source starts playing

	void Start () {
	}

	void Update () {
	}
}
