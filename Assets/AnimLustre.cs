using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimLustre : MonoBehaviour {

    public GameObject Lustre;

    void Start()
    {
        Invoke("StartAnimeLustre", 2f);
    }
    void StartAnimeLustre()
    {
        Lustre.GetComponent<Animator>().SetBool("balance", true);
    }
}
