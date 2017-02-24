using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class KazhadDumSpawnPoint : SpawnPoint
{

    public GameObject PostCollpaseToReload;
    public GameObject PostCollapseNewInstance;

    public GameObject PreCollpaseToReload;
    public GameObject PreCollapseNewInstance;

    public GameObject porte;
    public GameObject porte_navmeshobstacle;

    public GameObject collapseParticles;

    private bool hasTriggered = false;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (!hasTriggered)
        {
            if (other.tag == "Player")
            {
                porte.SetActive(true);
                porte.GetComponent<Animator>().Play("AppearAndClose");
                porte_navmeshobstacle.SetActive(true);
                hasTriggered = true;
            }
        }
    }

    public override void UpdatePrefabs()
    {
        PreCollpaseToReload = ReloadPrefab(PreCollpaseToReload, PreCollapseNewInstance, true);
        PostCollpaseToReload = ReloadPrefab(PostCollpaseToReload, PostCollapseNewInstance, false);
        collapseParticles.SetActive(false);
        PreCollpaseToReload.GetComponentInChildren<CollapseController>().preCollapseEnvironment = PreCollpaseToReload;
        PreCollpaseToReload.GetComponentInChildren<CollapseController>().postCollapseEnvironment = PostCollpaseToReload;
        PreCollpaseToReload.GetComponentInChildren<CollapseController>().CollapseParticles = collapseParticles;
    }

}
