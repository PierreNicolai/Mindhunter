using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeScream : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other) {
        if(other.tag=="Player") {
            GetComponentInParent<Enemy>().targetRangeToScream = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag=="Player") {
            GetComponentInParent<Enemy>().targetRangeToScream = false;
        }
    }
}
