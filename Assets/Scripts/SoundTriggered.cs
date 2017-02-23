using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggered : MonoBehaviour {

	public AudioClip soundToPlay;

	public float volume;
	public float pitch;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			 GetComponent<BoxCollider>().enabled = false;		
			 SoundManager.Instance.PlayAudioAtPoint(soundToPlay, transform.position);
		}
	}

	// Reset the collider to future use (loading after dead)
	public void ReactivateBoxCollider() {
		GetComponent<BoxCollider>().enabled = true;
	}
}
