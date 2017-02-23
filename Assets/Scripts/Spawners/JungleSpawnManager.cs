using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine;

public class JungleSpawnManager : MonoBehaviour {

    public JungleSpawnPoint currentSpawn { get; private set; }
    public int CurrentRoom { get; private set; }

    public static JungleSpawnManager Instance { get; private set; }

    private bool canRespawn;

    [HideInInspector]
    public bool isSpawnTriggered;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isSpawnTriggered = false;
        canRespawn = true;
        Player.Instance.CurrentRoom = 0;
    }

    public void SetCurrentSpawn(JungleSpawnPoint point)
    {
        if (!isSpawnTriggered)
        {
            if (point.TriggersNextScene)
                StartCoroutine(LoadTemple());
            else
                currentSpawn = point;
        }
    }

    public void Respawn()
    {
        if (canRespawn)
        {
            StartCoroutine(InvokeRespawn());
            canRespawn = false;
        }
    }

    private IEnumerator LoadTemple()
    {
        UIManager.Instance.UIFadeOut();
        yield return new WaitForSeconds(0.5f);
        Player.Instance.gameObject.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadSceneAsync("Main_scene");
    }

    private IEnumerator InvokeRespawn()
    {
        UIManager.Instance.UIFadeOut();
        yield return new WaitForSeconds(0.5f);
        Player.Instance.gameObject.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(1f);
        Player.Instance.gameObject.transform.position = currentSpawn.transform.position;
        Player.Instance.gameObject.transform.localRotation = currentSpawn.transform.rotation;
        GlowManager.Instance.Reload();
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(0.5f);
        Player.Instance.gameObject.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(1f);
        canRespawn = true;
    }
}
