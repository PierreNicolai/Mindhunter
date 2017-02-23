using UnityEngine;
using System.Collections;
using MindHunter.Managers;

public class PlateTrigger : MonoBehaviour
{
	void OnTriggerEnter(Collider collider)
    {
        print("Trigger enter");
        if(collider.tag == "Player")
        {
            print("And it's the player");
            NotifyTrigger();
        }
    }

    private void NotifyTrigger()
    {
        PlatesRiddleController.Instance.PlateTriggered(this.gameObject);
    }

    public void DestroyPlate()
    {
        Destroy(gameObject);
    }
}
