using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        StartCoroutine(LustreFall());
        
    }

    private IEnumerator LustreFall()
    {
        List<Transform> lustreSubObjects = AnimatedLustre.GetComponentsInChildren<Transform>().ToList();
        lustreSubObjects.Remove(AnimatedLustre.transform);
        lustreSubObjects.ForEach(lso => lso.GetComponent<Rigidbody>().isKinematic = false);
        yield return new WaitForSeconds(2f);
        StartCoroutine(Collapse());
    }

    private IEnumerator Collapse()
    {
        //Reset & replay Particles System
        CollapseParticles.GetComponent<ParticleSystem>().time = 0;
        CollapseParticles.GetComponent<ParticleSystem>().Play();
        CollapseParticles.SetActive(true);
        //Shake effect on the camera
        Camera.main.GetComponent<CameraShaker>().Shake(2.5f);
        //Wait 2s
        yield return new WaitForSeconds(2f);
        postCollapseEnvironment.SetActive(true);
        preCollapseEnvironment.SetActive(false);
        GlowManager.Instance.UnglowAll();
        GlowManager.Instance.Reload();
    }
}
