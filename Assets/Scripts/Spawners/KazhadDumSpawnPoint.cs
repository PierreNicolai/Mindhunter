using UnityEngine;

public class KazhadDumSpawnPoint : SpawnPoint {

    public GameObject PostCollpaseToReload;
    public GameObject PostCollapseNewInstance;

    public GameObject PreCollpaseToReload;
    public GameObject PreCollapseNewInstance;

    public GameObject templePart1;
    public GameObject templePart2;

    public GameObject collapseParticles;

    private bool hasTriggered = false;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.tag == "Player")
        {
            if (!hasTriggered)
            {
                hasTriggered = true;
                //Close door;
                templePart1.SetActive(false);
                templePart2.SetActive(true);
                GlowManager.Instance.Reload();
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
