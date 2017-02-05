using UnityEngine;

public class DeathManager : MonoBehaviour
{
	void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Lethal")
        {
            SceneSwitcher.Instance.ReloadLevel();
        }
    }
}
