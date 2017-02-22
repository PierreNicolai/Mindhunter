using UnityEngine;

public class KazhadDumSpawnPoint : SpawnPoint {

    public GameObject PostCollpaseToReload;
    public GameObject PostCollapseNewInstance;

    public GameObject PreCollpaseToReload;
    public GameObject PreCollapseNewInstance;

    public GameObject collapseParticles;

    public GameObject templePart1;
    public GameObject templePart2;

    private bool hasLoaded = false;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.tag == "Player")
        {
            if (!hasLoaded)
            {
                //close door;
                templePart1.SetActive(false);
                templePart2.SetActive(true);
                hasLoaded = true;
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
