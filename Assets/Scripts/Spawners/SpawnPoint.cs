using UnityEngine;

public class SpawnPoint : MonoBehaviour {

    [TestButton("ReloadPlates", "UpdatePrefabs", isActiveInEditor = false)]
    public GameObject newPrefabInstance;
    public GameObject prefabToReload;  


    void Awake() {
//        prefabToReload = Instantiate(newPrefabInstance);
    }
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
        DestroyImmediate(prefabToReload, true);
        prefabToReload =  Instantiate(newPrefabInstance, instanciationPosition, Quaternion.identity);       
    } 
}
