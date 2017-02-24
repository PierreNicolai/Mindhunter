using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class BossResolution : MonoBehaviour
{

    public AudioClip loseAudio;
    public AudioClip winAudio;
    public AudioClip creditsAudio;
    public MovieTexture loseMovie;
    public MovieTexture winMovie;
    public MovieTexture creditsMovie;

    public AudioSource movieAudio;

    public RawImage movieScreen;

    public bool win;

    private bool hasTriggered = false;

    // Use this for initialization

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered)
        {
            if (other.tag.Equals("Player"))
            {
                if (win)
                {
                    StartCoroutine(PlayVideoWin(winMovie.duration));
                }
                else {
                    StartCoroutine(PlayVideoLose(loseMovie.duration));
                }
                hasTriggered = true;
            }
        }
    }

    IEnumerator PlayVideoWin(float time)
    {
        // Set sounds and movies accordingly to resolution
        movieScreen.enabled = true;

        movieAudio.clip = winAudio;
        movieScreen.texture = winMovie;
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
        movieScreen.enabled = false;
        SceneManager.LoadScene("Menu");
    }

    IEnumerator PlayVideoLose(float time)
    {
        movieScreen.enabled = true;
        // Set sounds and movies accordingly to resolution

        movieAudio.clip = loseAudio;
        movieScreen.texture = loseMovie;
        loseMovie.Play();
        movieAudio.Play();

        yield return new WaitForSeconds(time);
        Debug.Log("Movie terminated");
        loseMovie.Stop();
        SpawnManager.Instance.Respawn();
        yield return new WaitForSeconds(1.5f);
        movieScreen.enabled = false;
        hasTriggered = false;
    }
}
