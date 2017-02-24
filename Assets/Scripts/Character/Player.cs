using MindHunter.Managers;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public enum PlayerVisibility
{
    VISIBLE,
    HIDDEN
}

public class Player : PersistentSingleton<Player>
{

    public PlayerVisibility playerVisibility { get; private set; }
    public GameObject brasMalinal;
    private FirstPersonController fpsController;

    public int CurrentRoom;

    public Animator _anim { get; private set; }

    void Start()
    {
	fpsController  = GetComponent<FirstPersonController>();
        CurrentRoom = 0;
        _anim = brasMalinal.GetComponent<Animator>();
        playerVisibility = PlayerVisibility.VISIBLE;

    }

    public void AttackAnimation()
    {
        _anim.Play("Shoot");
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
                if (JungleSpawnManager.Instance != null)
                    JungleSpawnManager.Instance.Respawn();
                else
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

   public void DisableFPSController() {
    	fpsController.enabled = false;
    }

    public void EnableFPSController() {
	fpsController.enabled = true;
    }
}
