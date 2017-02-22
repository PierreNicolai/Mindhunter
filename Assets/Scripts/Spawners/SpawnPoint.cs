using UnityEngine;

public class SpawnPoint : MonoBehaviour {
    
    public GameObject newPrefabInstance;
    public GameObject prefabToReload;

    public int SpawnPointIndex;

	public virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SpawnManager.Instance.SetCurrentSpawn(this);
            SpawnManager.Instance.isSpawnTriggered = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnManager.Instance.isSpawnTriggered = false;
        }
    }

    public virtual void UpdatePrefabs()
    {
        prefabToReload = ReloadPrefab(prefabToReload, newPrefabInstance, true);   
    }
    
    protected GameObject ReloadPrefab(GameObject currentPrefab, GameObject newPrefab, bool visibleOnInstanciation)
    {
        Vector3 instanciationPosition = currentPrefab.transform.position;
        Quaternion instanciationRotation = currentPrefab.transform.rotation;
        DestroyImmediate(currentPrefab, true);
        currentPrefab = Instantiate(newPrefab, instanciationPosition, Quaternion.identity);
        currentPrefab.transform.localRotation = instanciationRotation;
        currentPrefab.SetActive(visibleOnInstanciation);
        return currentPrefab;
    }
}
