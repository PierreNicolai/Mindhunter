using UnityEngine;
using System.Collections;

public class CollapseController : Target
{

    public GameObject preCollapseEnvironment;
    public GameObject postCollapseEnvironment;

    public GameObject CollapseParticles;

    public GameObject StaticLustre;
    public GameObject AnimatedLustre;

    public override void OnShot()
    {
        StaticLustre.SetActive(false);
        AnimatedLustre.SetActive(true);
        AnimatedLustre.GetComponent<Animator>().Play("Balance");
        //StartCoroutine(Collapse());
    }

    private IEnumerator Collapse()
    {
        //Reset & replay Particles System
        CollapseParticles.GetComponent<ParticleSystem>().time = 0;
        CollapseParticles.GetComponent<ParticleSystem>().Play();
        CollapseParticles.SetActive(true);
        //Shake effect on the camera
        Camera.main.GetComponent<CameraShaker>().Shake(3.0f);
        //Wait 2s
        yield return new WaitForSeconds(2f);
        postCollapseEnvironment.SetActive(true);
        preCollapseEnvironment.SetActive(false);
    }
}
