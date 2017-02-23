using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using MindHunter.Managers;

public class SpawnManager : PersistentSingleton<SpawnManager>
{
    public Transform DefaultSpawnPoint;

    public SpawnPoint currentSpawn { get; private set; }
    public int CurrentRoom { get; private set; }
   
    private bool canRespawn;
    private Player player;

    [HideInInspector]
    public bool isSpawnTriggered;

    void Start()
    {
        player = Player.Instance;
        isSpawnTriggered = false;
        canRespawn = true;
        CurrentRoom = 0;
        player.CurrentRoom = CurrentRoom;
        StartCoroutine(SpawnPlayer());
        GlowManager.Instance.Reload();
    }

    private IEnumerator SpawnPlayer()
    {
        player.transform.position = DefaultSpawnPoint.position;
        player.transform.localRotation = DefaultSpawnPoint.rotation;
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(0.5f);
        player.gameObject.GetComponent<FirstPersonController>().enabled = true;
    }

    public void SetCurrentSpawn(SpawnPoint point)
    {
        if (!isSpawnTriggered)
        {
            currentSpawn = point;
            CurrentRoom = (point.SpawnPointIndex == CurrentRoom) ? CurrentRoom - 1 : point.SpawnPointIndex;
            player.CurrentRoom = CurrentRoom;
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
        player.gameObject.GetComponent<FirstPersonController>().enabled = false;
        yield return new WaitForSeconds(1f);
        currentSpawn.UpdatePrefabs();
        player.gameObject.transform.position = currentSpawn.transform.position;
        player.gameObject.transform.localRotation = currentSpawn.transform.rotation;
        GlowManager.Instance.Reload();
        CurrentRoom -= 1;
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(0.5f);
        player.gameObject.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(1f);
        canRespawn = true;
    }
}
