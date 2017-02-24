using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTriggerCollapse : MonoBehaviour {

	public AudioClip soundToPlay;

	public float volume;
	public float pitch;

	public string tag;

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals(tag)) {
			 GetComponent<BoxCollider>().enabled = false;		
			 SoundManager.Instance.PlayAudioAtPoint(soundToPlay, transform.position);
		}
	}

	// Reset the collider to future use (loading after dead)
	public void ReactivateBoxCollider() {
		GetComponent<BoxCollider>().enabled = true;
	}
}
