using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    public GameObject newPrefabInstance;
    public GameObject prefabToReload;
    
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SpawnManager.Instance.currentSpawn = this;
        }
    }

    public virtual void UpdatePrefabs()
    {
        Vector3 instanciationPosition = prefabToReload.transform.position;
        Destroy(prefabToReload);
        prefabToReload = Instantiate(newPrefabInstance, instanciationPosition, Quaternion.identity);
    }
}
