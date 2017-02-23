using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class JungleSpawnPoint : MonoBehaviour
{
    public bool TriggersNextScene;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print("Poof");
            JungleSpawnManager.Instance.SetCurrentSpawn(this);
            JungleSpawnManager.Instance.isSpawnTriggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            JungleSpawnManager.Instance.isSpawnTriggered = false;
        }
    }

}
