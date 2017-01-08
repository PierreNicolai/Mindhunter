using UnityEngine;
using System.Collections;

public class PowerController : MonoBehaviour {

	public GameObject XRayScript;

	bool xray;
	// Use this for initialization
	void Start () {
		xray = false;
		XRayScript.SetActive(xray);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Power")) {
			if(!xray) {
				XRayScript.SetActive(true);
				xray = true;
			}else {
				XRayScript.SetActive(false);
				xray = false;
			}
		}
	}

}
