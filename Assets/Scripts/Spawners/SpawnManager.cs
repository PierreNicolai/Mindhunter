using MindHunter.Managers;
using System.Collections;
using UnityEngine;

public class SpawnManager : PersistentSingleton<SpawnManager>
{
    public SpawnPoint currentSpawn;

    private bool canRespawn;

    void Start()
    {
        canRespawn = true;
    }

    public void Respawn()
    {
        if (canRespawn)
        {
            StartCoroutine(InvokeRespawn());
            canRespawn = false;
        }
    }

    private IEnumerator InvokeRespawn()
    {
        print("J'y passe wesh");
        UIManager.Instance.UIFadeOut();
        yield return new WaitForSeconds(1.5f);
        currentSpawn.UpdatePrefabs();
        Player.Instance.gameObject.transform.position = currentSpawn.transform.position;
        Player.Instance.gameObject.transform.localRotation = currentSpawn.transform.rotation;
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(1.5f);
        canRespawn = true;
    }
}
