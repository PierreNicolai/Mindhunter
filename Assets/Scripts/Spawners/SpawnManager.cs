using MindHunter.Managers;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
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
        
        UIManager.Instance.UIFadeOut();
        yield return new WaitForSeconds(0.5f);
        Player.Instance.gameObject.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(1f);
        currentSpawn.UpdatePrefabs();
        Player.Instance.gameObject.transform.position = currentSpawn.transform.position;
        Player.Instance.gameObject.transform.localRotation = currentSpawn.transform.rotation;
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(0.5f);
        Player.Instance.gameObject.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(1f);
        canRespawn = true;
    }
}
