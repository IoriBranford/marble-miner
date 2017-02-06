using UnityEngine;

public class TempParticles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var particleSystem = GetComponent<ParticleSystem>();
		float t = particleSystem.main.duration
			+ particleSystem.main.startLifetime.constant;
		Destroy(gameObject, t);
	}
}
