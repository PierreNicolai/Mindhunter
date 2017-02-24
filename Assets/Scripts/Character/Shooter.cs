using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Shooter : MonoBehaviour
{
    public LayerMask interactableLayer;

    private bool canAttack;

    void Start()
    {
        canAttack = true;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1"))
            Fire();
        if (canAttack)
        {
            canAttack = false;
            if (CrossPlatformInputManager.GetAxis("Fire1") > 0)
            {
                Fire();
            }
        }
        if (CrossPlatformInputManager.GetAxis("Fire1") == 0)
            canAttack = true;
    }

    private void Fire()
    {
        Player.Instance.AttackAnimation();
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, interactableLayer))
        {
            print("ray hit something");
            GameObject collidedObj = hit.collider.gameObject;
            print("it's : " + collidedObj.name);
            if (collidedObj.GetComponent<Target>() != null)
            {
                print("has a target component, invoking OnShot method");
                collidedObj.GetComponent<Target>().OnShot();
            }
        }
    }
}
