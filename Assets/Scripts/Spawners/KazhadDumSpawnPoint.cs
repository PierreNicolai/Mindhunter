﻿using UnityEngine;

public class KazhadDumSpawnPoint : SpawnPoint {

    public GameObject PostCollpaseToReload;
    public GameObject PostCollapseNewInstance;

    public GameObject PreCollpaseToReload;
    public GameObject PreCollapseNewInstance;

    public GameObject porte;

    public GameObject collapseParticles;

    private bool hasTriggered = false;

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (!hasTriggered)
        {
            porte.SetActive(true);
            porte.GetComponent<Animator>().Play("AppearAndClose");
            hasTriggered = true;
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
