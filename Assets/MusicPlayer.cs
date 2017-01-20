using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer _instance;

	// Use this for initialization
	void Start () {
		if (_instance == null) {
			GameObject.DontDestroyOnLoad(gameObject);
			_instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	}
}
