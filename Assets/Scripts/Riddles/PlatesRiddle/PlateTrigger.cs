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
        StartCoroutine(DestroyPlateRoutine());
    }

    public IEnumerator DestroyPlateRoutine()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
}
