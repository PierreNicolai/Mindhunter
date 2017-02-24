﻿using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BossResolution : MonoBehaviour {

	public AudioClip loseAudio;
	public AudioClip winAudio;
    public AudioClip creditsAudio;
	public MovieTexture loseMovie;
	public MovieTexture winMovie;
    public MovieTexture creditsMovie;

	public AudioSource movieAudio;
	public RawImage movieScreen;

	public bool win;
	// Use this for initialization
	void Start () {
        movieScreen = UIManager.Instance.movieTexture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag.Equals("Player")) {
			if(win) {
				StartCoroutine(PlayVideoWin(winMovie.duration));
			}else {
				StartCoroutine(PlayVideoLose(loseMovie.duration));
			}	
		}
	}

	IEnumerator PlayVideoWin(float time) {
        // Set sounds and movies accordingly to resolution
        UIManager.Instance.SetMovieTextureActive(true);

        movieAudio.clip = winAudio;
		movieScreen.texture = winMovie as MovieTexture;
		winMovie.Play();
		movieAudio.Play();

		yield return new WaitForSeconds(time);
		Debug.Log("Movie terminated");
        //Lauch credits :

        float creditsDuration = creditsMovie.duration;
        movieAudio.clip = creditsAudio;
        movieScreen.texture = creditsMovie;
        creditsMovie.Play();
        movieAudio.Play();

        yield return new WaitForSeconds(creditsDuration);
        UIManager.Instance.SetMovieTextureActive(false);
        SceneManager.LoadScene("Menu");
    }

	IEnumerator PlayVideoLose(float time) {
        UIManager.Instance.SetMovieTextureActive(true);
		// Set sounds and movies accordingly to resolution

		movieAudio.clip = loseAudio;
		movieScreen.texture = loseMovie as MovieTexture;
		loseMovie.Play();
		movieAudio.Play();

		yield return new WaitForSeconds(time);
		Debug.Log("Movie terminated");
        SpawnManager.Instance.Respawn();
        UIManager.Instance.SetMovieTextureActive(false);
    }
}
