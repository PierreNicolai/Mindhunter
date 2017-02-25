using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TransitionSound : MonoBehaviour
{	
	public AudioSource inSource;
	public AudioSource outSource;
	public float transitionTime;

	private bool use;

	public void Awake() {
		use = false;
	}

	// Debug purposes
//	void Update() {
//		if(Input.GetKey(KeyCode.A) && !use) {
//			use = true;
//			Fade();
//		}
//	}

	void OnTriggerEnter (Collider other)
	{
		if(other.tag.Equals("Player") && !use) {			
			use = true;
			if(outSource.volume > 0.1f)
				return;
			Fade();
			Destroy(gameObject, transitionTime);
		}
	}


	public void Fade() {		
		StartCoroutine(FadeBGM(inSource ,1f, 0f, transitionTime));
		StartCoroutine(FadeBGM(outSource, 0f, 1f, transitionTime));
	}

	IEnumerator FadeBGM (AudioSource audio, float startVolume, float endVolume, float duration)
	{
		float elapsed = 0f;
		while (duration > 0) {
			float t = (elapsed / duration);
			float volume = Mathf.Lerp (startVolume, endVolume, t);
			audio.volume = volume;
			elapsed += Time.deltaTime;
			yield return 0;
		}
		audio.volume = endVolume;
	}



}
