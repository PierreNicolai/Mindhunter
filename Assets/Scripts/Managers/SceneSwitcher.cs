using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitcher : MonoBehaviour
{
    public int SceneIndex;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider col)
    {
        if (!hasTriggered)
        {
            if (col.tag == "Player")
            {
                hasTriggered = true;
                StartCoroutine(LoadScene(SceneIndex+1));
            }
        }
    }

    private IEnumerator LoadScene(int index)
    {
        AsyncOperation task = SceneManager.LoadSceneAsync(index);
        yield return task;
    }
}


