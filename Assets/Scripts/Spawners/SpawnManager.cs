using MindHunter.Managers;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class SpawnManager : PersistentSingleton<SpawnManager>
{
    public SpawnPoint currentSpawn { get; private set; }
    public int CurrentRoom { get; private set; }

    private bool canRespawn;

    [HideInInspector]
    public bool isSpawnTriggered;

    void Start()
    {
        isSpawnTriggered = false;
        canRespawn = true;
        CurrentRoom = 0;
    }

    public void SetCurrentSpawn(SpawnPoint point)
    {
        if (!isSpawnTriggered)
        {
            currentSpawn = point;
            CurrentRoom = (point.SpawnPointIndex == CurrentRoom) ? CurrentRoom - 1 : point.SpawnPointIndex;
            print("enter in room : " + CurrentRoom);
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

    private IEnumerator InvokeRespawn()
    {
        UIManager.Instance.UIFadeOut();
        yield return new WaitForSeconds(0.5f);
        Player.Instance.gameObject.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(1f);
        currentSpawn.UpdatePrefabs();
        Player.Instance.gameObject.transform.position = currentSpawn.transform.position;
        Player.Instance.gameObject.transform.localRotation = currentSpawn.transform.rotation;
        GlowManager.Instance.Reload();
        CurrentRoom -= 1;
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(0.5f);
        Player.Instance.gameObject.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(1f);
        canRespawn = true;
    }
}
