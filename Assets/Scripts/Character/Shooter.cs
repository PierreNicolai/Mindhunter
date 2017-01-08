using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public LayerMask interactableLayer;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("clicked");
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
            {
                print("ray hit something");
                GameObject collidedObj = hit.collider.gameObject;
                print("it's : " + collidedObj.name);
                if(collidedObj.GetComponent<Target>() != null)
                {
                    print("has a target component, invoking OnShot method");
                    collidedObj.GetComponent<Target>().OnShot();
                }
            }
        }
    }
}
