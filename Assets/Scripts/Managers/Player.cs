using MindHunter.Managers;
using UnityEngine;

public enum PlayerVisibility
{
    VISIBLE,
    HIDDEN
}

public class Player : PersistentSingleton<Player>
{

    public PlayerVisibility playerVisibility { get; private set; }

    void Start()
    {
        playerVisibility = PlayerVisibility.VISIBLE;
    }

    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Cloaking":
                playerVisibility = PlayerVisibility.HIDDEN;
                print("hidden");
                break;
            case "Lethal":
                SpawnManager.Instance.Respawn();
                break;
        }
    }

    void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Cloaking":
                playerVisibility = PlayerVisibility.VISIBLE;
                print("visible !");
                break;
        }
    }

    void OnTriggerStay(Collider other)
    {
        switch (other.tag)
        {
            case "Cloaking":
                playerVisibility = PlayerVisibility.HIDDEN;
                print("hidden");
                break;
        }
    }
}
