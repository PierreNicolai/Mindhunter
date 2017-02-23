using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Shooter : MonoBehaviour
{
    public LayerMask interactableLayer;

    private bool hasShot;

    void Start()
    {
        hasShot = false;
    }

    void Update()
    {
        if (!hasShot)
        {
            hasShot = true;
            StartCoroutine(ShooterCooldown());
            if (CrossPlatformInputManager.GetAxis("Fire1") > 0)
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
    }

    private IEnumerator ShooterCooldown()
    {
        yield return new WaitForSeconds(1f);
        hasShot = false;
    }
}
