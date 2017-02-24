using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuManager : MonoBehaviour {

    public RawImage movieScreen;
    public AudioClip creditsAudio;
    public MovieTexture creditsMovie;
    public AudioSource movieAudio;

    public void QuitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Jungle");
    }

    public void CreditsButton()
    {
        StartCoroutine(PlayVideoWin());
    }

    IEnumerator PlayVideoWin()
    {
        movieScreen.enabled = true;

        float creditsDuration = creditsMovie.duration;
        movieAudio.clip = creditsAudio;
        movieScreen.texture = creditsMovie;
        creditsMovie.Play();
        movieAudio.Play();

        yield return new WaitForSeconds(creditsDuration);
        movieScreen.enabled = false;
        creditsMovie.Stop();
    }
}
