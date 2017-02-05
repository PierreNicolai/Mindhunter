using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
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
        FirstPersonController.Instance.SetMovePermissions(false);
        UIManager.Instance.UIFadeOut();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(index);
        FirstPersonController.Instance.SetMovePermissions(false);
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(2f);
        FirstPersonController.Instance.SetMovePermissions(true);
    }
}


