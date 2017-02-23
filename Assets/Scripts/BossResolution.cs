using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossResolution : MonoBehaviour {

	public AudioClip loseAudio;
	public AudioClip winAudio;
	public MovieTexture loseMovie;
	public MovieTexture winMovie;


	public AudioSource movieAudio;
	public RawImage movieScreen;

	public bool win;
	// Use this for initialization
	void Awake () {
		win = false;
		StartCoroutine(PlayVideoWin(winMovie.duration));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.Equals("Player")) {
			if(win) {
				StartCoroutine(PlayVideoWin(winMovie.duration));
			}else {
				StartCoroutine(PlayVideoLose(loseMovie.duration));
			}	
		}
	}

	IEnumerator PlayVideoWin(float time) {			
		// Set sounds and movies accordingly to resolution

		movieAudio.clip = winAudio;
		movieScreen.texture = winMovie as MovieTexture;
		winMovie.Play();
		movieAudio.Play();

		yield return new WaitForSeconds(time);
		Debug.Log("Movie terminated");
		// Restart to last checkpoint or launch Credtis
	}

	IEnumerator PlayVideoLose(float time) {	
		movieScreen.gameObject.SetActive(true);
		// Set sounds and movies accordingly to resolution

		movieAudio.clip = loseAudio;
		movieScreen.texture = loseMovie as MovieTexture;
		loseMovie.Play();
		movieAudio.Play();

		yield return new WaitForSeconds(time);
		Debug.Log("Movie terminated");
		// Restart to last checkpoint or launch Credtis
	}
}
