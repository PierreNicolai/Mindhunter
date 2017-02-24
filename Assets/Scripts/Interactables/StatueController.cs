using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StatueController : Target {

    public GameObject Lustre;
    public GameObject chaine;

    public GameObject[] Woots;

    public GameObject deadWoot;

    public List<Vector3> deadWootsPositions;
        
    public override void OnShot()
    {
        deadWootsPositions = new List<Vector3>();
        StartCoroutine(LustreFall());
    }

    private IEnumerator LustreFall()
    {
        int iterator = 0;
        foreach(GameObject woot in Woots)
        {
            deadWootsPositions.Add(woot.transform.position - new Vector3(0, 0.2f, 0));
        }
        List<Transform> lustreSubObjects = Lustre.GetComponentsInChildren<Transform>().ToList();
        lustreSubObjects.Remove(Lustre.transform);
        lustreSubObjects.ForEach(lso => lso.GetComponent<Rigidbody>().isKinematic = false);
        Destroy(chaine);
        yield return new WaitForSeconds(1.5f);
       
        foreach(GameObject woot in Woots)
        { 
            GameObject go = Instantiate(deadWoot, deadWootsPositions.ToArray()[iterator], Quaternion.identity);
            go.transform.localRotation = Quaternion.Euler(-90f, 0, Random.Range(0, 360));
            Destroy(woot);
            iterator++;
        }
    }
}
