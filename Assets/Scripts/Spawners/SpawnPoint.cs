using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [TestButton("ReloadPlates", "UpdatePrefabs", isActiveInEditor = false)]
    public GameObject newPrefabInstance;
    public GameObject prefabToReload;  


	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("New spawn defined : " + gameObject.name);
            SpawnManager.Instance.currentSpawn = this;
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
