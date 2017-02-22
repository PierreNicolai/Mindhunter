using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StatueController : Target {

    public GameObject Lustre;
    public GameObject chaine;

    public GameObject[] Woots;
        
    public override void OnShot()
    {
        StartCoroutine(LustreFall());
    }

    private IEnumerator LustreFall()
    {
        List<Transform> lustreSubObjects = Lustre.GetComponentsInChildren<Transform>().ToList();
        lustreSubObjects.Remove(Lustre.transform);
        lustreSubObjects.ForEach(lso => lso.GetComponent<Rigidbody>().isKinematic = false);
        Destroy(chaine);
        yield return new WaitForSeconds(1f);
        //Kill woots
    }
}
