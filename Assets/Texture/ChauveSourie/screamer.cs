using UnityEngine;
using System.Collections;

public class screamer : MonoBehaviour {

	public ParticleSystem particle;
	public AudioSource audio;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			particle.Play ();
			audio.Play();
			audio.loop = false;
			this.gameObject.SetActive(false);

		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
