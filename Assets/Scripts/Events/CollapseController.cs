using UnityEngine;
using System.Collections;

public class CollapseController : MonoBehaviour
{

    public GameObject preCollapseEnvironment;
    public GameObject postCollapseEnvironment;

    public GameObject CollapseParticles;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print("clicked");
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                print("ray hit something");
                GameObject collidedObj = hit.collider.gameObject;
                print("it's : " + collidedObj.name);
                if(collidedObj == this.gameObject)
                {
                    print("object hit, collapsing");
                    
                    StartCoroutine(Collapse());
                }
            }
        }
       
    }

    private IEnumerator Collapse()
    {
        //Reset & replay Particles System
        CollapseParticles.GetComponent<ParticleSystem>().time = 0;
        CollapseParticles.GetComponent<ParticleSystem>().Play();
        CollapseParticles.SetActive(true);
        //Shake effect on the camera
        Camera.main.GetComponent<CameraShaker>().Shake(3.0f);
        //Wait 0.5s
        yield return new WaitForSeconds(0.5f);
        //Chadelier is now affected by gravity, let it fall
        GetComponent<Rigidbody>().isKinematic = false;
        //Wait 1.5s
        yield return new WaitForSeconds(1.5f);
        postCollapseEnvironment.SetActive(true);
        preCollapseEnvironment.SetActive(false);
    }
}
