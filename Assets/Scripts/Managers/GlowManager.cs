using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using MindHunter.Managers;

public class GlowManager : PersistentSingleton<GlowManager>
{
    private List<GlowObject> glowObjects = new List<GlowObject>();
    private List<GlowObject> realtimeList = new List<GlowObject>();

    private bool isGlowing;

    // Use this for initialization
    void Start()
    {
        Reload();
    }

    public void Reload()
    {
        List<GlowObject> temp = FindObjectsOfType<GlowObject>().ToList();
       foreach(GlowObject g in temp)
        {
            if (g.roomIndex == SpawnManager.Instance.CurrentRoom)
                glowObjects.Add(g);
        }
        isGlowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            realtimeList = UpdateGlowList();
            if (!isGlowing)
            {
                realtimeList.ForEach(g => g.Glow());
                isGlowing = true;
            }
            else
            {
                realtimeList.ForEach(g => g.UnGlow());
                isGlowing = false;
            }
        }
    }

    private List<GlowObject> UpdateGlowList()
    {
        List<GlowObject> tempList = new List<GlowObject>();

        foreach (GlowObject g in glowObjects)
        {
            if (g != null)
                tempList.Add(g);
        }
        return tempList;
    }
}
