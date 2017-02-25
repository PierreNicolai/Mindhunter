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

    private int lastSpawnIndex;

    void Start()
    {
        player = Player.Instance;
        isSpawnTriggered = false;
        canRespawn = true;
        CurrentRoom = 0;
        lastSpawnIndex = 0;
        player.CurrentRoom = CurrentRoom;
        StartCoroutine(SpawnPlayer());
        GlowManager.Instance.Reload();
    }

    private IEnumerator SpawnPlayer()
    {
        player.transform.position = DefaultSpawnPoint.position;
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(0.5f);
        player.gameObject.GetComponent<FirstPersonController>().enabled = true;
        player.transform.localRotation = DefaultSpawnPoint.rotation;
    }

    public void SetCurrentSpawn(SpawnPoint point)
    {
        if (!isSpawnTriggered)
        {
            print("Entering room");
            if (point.SpawnPointIndex > lastSpawnIndex) 
            {
                lastSpawnIndex = point.SpawnPointIndex;
                currentSpawn = point;
                print("You have reached next spawner");
            }
            player.CurrentRoom = point.SpawnPointIndex;
            GlowManager.Instance.Reload();
            print("You are now in room " + player.CurrentRoom);
        }
    }

    public void OnSpawnExit()
    {
        player.CurrentRoom = 0;
        GlowManager.Instance.Reload();
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
        Player.Instance.CurrentRoom = 0;
        UIManager.Instance.UIFadeIn();
        yield return new WaitForSeconds(0.5f);
        player.gameObject.GetComponent<FirstPersonController>().enabled = true;
        yield return new WaitForSeconds(1f);
        canRespawn = true;
        
    }
}
